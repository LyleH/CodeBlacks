using CodeBlacks.BusinessRules;
using System;
using System.IO;

namespace CodeBlacks.Harness
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ////CodeCoverageComparison.CompareFiles(args[0], args[1]);
            string baseDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\.."));
            (new CodeCoverageRunner()
            {
                PathToOpenCover = Path.Combine(baseDirectory, @"RestSharp\packages\OpenCover.4.5.3723\OpenCover.Console.exe"),
                PathToReportGenerator = Path.Combine(baseDirectory, @"RestSharp\packages\ReportGenerator.2.1.4.0\ReportGenerator.exe"),
                PathToTestRunner = Path.Combine(baseDirectory, @"RestSharp\packages\xunit.runner.console.2.0.0\tools\xunit.console.exe"),
                TestRunnerArguments = "\"\"" + Path.Combine(baseDirectory, @"RestSharp\RestSharp.IntegrationTests\bin\Debug\RestSharp.IntegrationTests.dll") + @""""" -method RestSharp.IntegrationTests.FileTests.Handles_Binary_File_Download -noshadow",
                PathToCodeCoverageXmlFile = Path.Combine(baseDirectory, @"RestSharp\Coverage2.xml"),
                PathToCodeCoverageReportDirectory = Path.Combine(baseDirectory, @"RestSharp\Coverage2"),
                CodeCoverageFilter = @"+[RestSharp*]*"
            }).RunCodeCoverage();
        }
    }
}
