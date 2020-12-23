using System.Collections.Generic;
using System.Linq;

namespace CSharpToPythonConverter.Methods
{
    public class MethodCall : ICSharpObject
    {
        public string FullName { get; set; }
        public string Name { get; set; }
        public List<string> Parameters { get; set; }
        
        public MethodCall(string details)
        {
            Parameters = new List<string>();
            LoadDetails(details);
        }

        public MethodCall()
        {
            Parameters = new List<string>();
        }

        public bool IsMatch(string details)
        {
            var items = details.Split(' ');
            return details.EndsWith(";")
                && details.Contains("(")
                && details.Contains(")")
                && !items.Any(x => string.Equals(x, "new"));
        }

        public void LoadDetails(string details)
        {
            var parameterStartIndex = details.IndexOf("(");
            var parameterEndIndex = details.IndexOf(")");
            var parameters = details.Substring(parameterStartIndex + 1, (parameterEndIndex - parameterStartIndex) - 1);

            foreach (var parameter in parameters.Split(','))
            {
                Parameters.Add(parameter);
            }

            var methodNameStartIndex = details.LastIndexOf('.');
            Name = details.Substring(methodNameStartIndex + 1, (parameterStartIndex - methodNameStartIndex) - 1).Trim();
            FullName = details.Substring(0, parameterStartIndex).Trim();
        }

        public string GetPythonEquivalent()
        {
            return MethodCallConverter.Convert(this);
        }
    }
}