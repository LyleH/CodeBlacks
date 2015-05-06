using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DiffPlex;
using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace CodeBlacks.BusinessRules
{
    public static class CodeCoverageComparison
    {
        public static SideBySideDiffModel CompareFiles(string oldFile, string newFile)
        {
            string oldFileContent = File.ReadAllText(oldFile);
            string newFileContent = File.ReadAllText(newFile);
            if (oldFileContent == newFileContent)
            {
                // Files are identical
                return null;
            }

            const string matchText = "<tr><th>Coverage:</th><td>0%</td></tr>";
            if (oldFileContent.Contains(matchText) && newFileContent.Contains(matchText))
            {
                // Both files have no coverage
                return null;
            }

            oldFileContent = RemoveLineNumbers(oldFileContent);
            newFileContent = RemoveLineNumbers(newFileContent);
            SideBySideDiffBuilder sideBySideDiffer = new SideBySideDiffBuilder(new Differ());
            SideBySideDiffModel diff = sideBySideDiffer.BuildDiffModel(oldFileContent, newFileContent);
            DiffPiece[] newLines = diff.NewText.Lines.Where(DoesLineHaveDifferentCoverage).ToArray();
            if (!diff.OldText.Lines.Where(DoesLineHaveDifferentCoverage).Concat(newLines).Any())
            {
                // No changes to code coverage
                return null;
            }

            return diff;
        }

        private static string RemoveLineNumbers(string fileContent)
        {
            const string lineNumberPattern = @"(?<Prefix><td[^>]*>(?:<td[^<]+</td>){2})(?:<td class=""rightmargin right""><code>\d+</code></td>)";
            return Regex.Replace(fileContent, lineNumberPattern, "${Prefix}");
        }

        private static bool DoesLineHaveDifferentCoverage(DiffPiece line)
        {
            return line.Type != ChangeType.Unchanged && Regex.IsMatch(line.Text, @"'VC':\s*'\d+'");
        }
    }
}
