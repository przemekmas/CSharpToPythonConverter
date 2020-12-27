using System.Text.RegularExpressions;

namespace CSharpToPythonConverter.Processor
{
    public static class EvaluateKeywordProcessor
    {
        public static string Evaluate(string line)
        {
            var modifiedCode = line;

            if (Regex.IsMatch(line, "( true )")
                || Regex.IsMatch(line, "( true:)"))
            {
                modifiedCode = modifiedCode.Replace("true", "True");
            }
            if (line.StartsWith("//"))
            {
                modifiedCode = modifiedCode.Replace("//", "");
            }
            if (line.StartsWith("/*"))
            {
                modifiedCode = modifiedCode.Replace("/*", "");
            }
            if (line.EndsWith("*/"))
            {
                modifiedCode = modifiedCode.Replace("*/", "");
            }
            if (line.Contains("//") 
                && !line.StartsWith("//")
                && line.Contains(";"))
            {
                var semicolonIndex = line.IndexOf(";");
                var commentIndex = line.IndexOf("//", semicolonIndex);
                modifiedCode = modifiedCode.Remove(commentIndex, 2);
                modifiedCode = modifiedCode.Insert(commentIndex, "#");
            }

            return modifiedCode;
        }
    }
}
