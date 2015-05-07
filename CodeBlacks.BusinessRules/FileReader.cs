using System.IO;

namespace CodeBlacks.BusinessRules
{
    public sealed class FileReader : IFileReader
    {
        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
