using System.Collections.Generic;
using System.Linq;

namespace CSharpToPythonConverter.Methods
{
    public class MethodCall : ICSharpObject
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public List<string> Parameters { get; set; }

        public bool IsMatch(string details)
        {
            var containsNewKeyWord = false;
            var parameterStartIndex = details.IndexOf("(");
            if (parameterStartIndex > -1)
            {
                var detailsExcludingParameters = details.Substring(0, parameterStartIndex);
                var items = detailsExcludingParameters.Split(' ');
                containsNewKeyWord = items.Any(x => string.Equals(x, "new"));
            }

            return details.Contains("(")
                && details.Contains(")")
                && details.IndexOf(";", details.LastIndexOf(")")) > -1
                && !containsNewKeyWord;
        }

        public void LoadDetails(string details)
        {
            Parameters = new List<string>();
            var parameterStartIndex = details.IndexOf("(");
            var parameterEndIndex = details.IndexOf(")");
            var parameters = details.Substring(parameterStartIndex + 1, (parameterEndIndex - parameterStartIndex) - 1);

            foreach (var parameter in parameters.Split(','))
            {
                Parameters.Add(parameter);
            }

            var detailsExcludingParameters = details.Substring(0, details.IndexOf("("));
            var methodNameStartIndex = detailsExcludingParameters.LastIndexOf('.');
            Name = details.Substring(methodNameStartIndex + 1, (parameterStartIndex - methodNameStartIndex) - 1).Trim();
            FullName = details.Substring(0, parameterStartIndex).Trim();
        }

        public string GetPythonEquivalent()
        {
            return MethodCallConverter.Convert(this);
        }
    }
}