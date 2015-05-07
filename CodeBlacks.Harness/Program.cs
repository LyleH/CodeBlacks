using CodeBlacks.BusinessRules;

namespace CodeBlacks.Harness
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ////CodeCoverageComparison.CompareFiles(args[0], args[1]);
            (new CodeCoverageRunner()
            {
                PathToOpenCover = @""
            })
        }
    }
}
