using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CodeBlacks.BusinessRules
{
    public static class FileDifferencesSerializer
    {
        public static string ToString(IEnumerable<FileDifferences> fileDifferences)
        {
            return JsonConvert.SerializeObject(fileDifferences, Formatting.Indented);
        }

        public static void ToFile(string fileName, IEnumerable<FileDifferences> fileDifferences)
        {
            File.WriteAllText(fileName, ToString(fileDifferences));
        }
    }
}
