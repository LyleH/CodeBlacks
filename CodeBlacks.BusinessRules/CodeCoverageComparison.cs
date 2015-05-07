using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace CodeBlacks.BusinessRules
{
    public sealed class CodeCoverageComparison
    {
        private readonly IDirectoryReader directoryReader;
        private readonly IFileReader fileReader;

        public CodeCoverageComparison(IDirectoryReader directoryReader, IFileReader fileReader)
        {
            this.directoryReader = directoryReader;
            this.fileReader = fileReader;
        }

        public IEnumerable<FileDifferences> CompareDirectories(string oldDirectory, string newDirectory)
        {
            List<string> fileNames = new List<string>();
            List<FileDifferences> differences = new List<FileDifferences>();
            foreach (string newFile in directoryReader.GetFiles(newDirectory, "*.htm"))
            {
                string newFileName = Path.GetFileName(newFile);
                string oldFile = Path.Combine(oldDirectory, newFileName);
                fileNames.Add(oldFile);
                if (newFileName == "index.htm")
                {
                    continue;
                }

                string oldFileContent = fileReader.Exists(oldFile) ? fileReader.ReadAllText(oldFile) : string.Empty;
                string newFileContent = fileReader.ReadAllText(newFile);
                SideBySideDiffModel model = CompareFileContent(oldFileContent, newFileContent);
                if (model != null)
                {
                    differences.Add(new FileDifferences(newFileName, model));
                }
            }

            AddDeletedFileComparisons(oldDirectory, newDirectory, fileNames, differences);
            return differences;
        }

        public SideBySideDiffModel CompareFiles(string oldFile, string newFile)
        {
            return CompareFileContent(fileReader.ReadAllText(oldFile), fileReader.ReadAllText(newFile));
        }

        public static SideBySideDiffModel CompareFileContent(string oldFileContent, string newFileContent)
        {
            if (oldFileContent == null || newFileContent == null)
            {
                Trace.WriteLine("One of the file content is null");
                return null;
            }

            if (oldFileContent == newFileContent)
            {
                Trace.WriteLine("Files are identical");
                return null;
            }

            const string matchText = "<tr><th>Coverage:</th><td>0%</td></tr>";
            if (oldFileContent.Contains(matchText) && newFileContent.Contains(matchText))
            {
                Trace.WriteLine("Both files have no coverage.");
                return null;
            }
            
            oldFileContent = RemoveLineNumbers(oldFileContent);
            newFileContent = RemoveLineNumbers(newFileContent);
            SideBySideDiffBuilder sideBySideDiffer = new SideBySideDiffBuilder(new Differ());
            SideBySideDiffModel diff = sideBySideDiffer.BuildDiffModel(oldFileContent, newFileContent);
            DiffPiece[] newLines = diff.NewText.Lines.Where(DoesLineHaveDifferentCoverage).ToArray();
            if (!diff.OldText.Lines.Where(DoesLineHaveDifferentCoverage).Concat(newLines).Any())
            {
                Trace.WriteLine("No changes to code coverage");
                return null;
            }
            
            return diff;
        }

        private static string RemoveLineNumbers(string fileContent)
        {
            const string lineNumberPattern = @"(?<Prefix>(?:<td[^<]+</td>){2})(?:<td class=""rightmargin right""><code>\d+</code></td>)";
            return Regex.Replace(fileContent, lineNumberPattern, "${Prefix}");
        }

        private static bool DoesLineHaveDifferentCoverage(DiffPiece line)
        {
            return line.Type != ChangeType.Unchanged && line.Text != null && Regex.IsMatch(line.Text, @"'VC':\s*'\d+'");
        }

        private void AddDeletedFileComparisons(
            string oldDiectory,
            string newDirectory,
            IEnumerable<string> existingFiles,
            List<FileDifferences> differences)
        {
            foreach (string oldFile in directoryReader.GetFiles(oldDiectory, "*.htm").Except(existingFiles))
            {
                CompareFileContent(fileReader.ReadAllText(oldFile), string.Empty);
            }
        }
    }
}
