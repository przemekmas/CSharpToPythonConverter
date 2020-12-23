using System.Collections.Generic;
using System.Text;

namespace CSharpToPythonConverter.Types
{
    public class List : ICSharpObject
    {
        private string _type;
        private string _name;
        private List<object> _values;

        public string GetPythonEquivalent()
        {
            var codeBuilder = new StringBuilder(_name);
            codeBuilder.Append(" = ");
            codeBuilder.Append("[");
            var count = 0;
            foreach (var value in _values)
            {
                if (count > 0)
                {
                    codeBuilder.Append(',');
                }
                codeBuilder.Append(value);
                count++;
            }
            codeBuilder.Append("]");

            return codeBuilder.ToString();
        }

        public bool IsMatch(string details)
        {
            return (details.StartsWith("var")
                || details.StartsWith("List<"))
                && details.Contains("List<")
                && details.Contains("new");
        }

        public void LoadDetails(string details)
        {
            _values = new List<object>();
            var startIndex = details.IndexOf(' ');
            var endIndex = details.IndexOf('=');
            _name = details.Substring(startIndex + 1, endIndex - startIndex - 1);

            startIndex = details.IndexOf('<');
            endIndex = details.IndexOf('>');
            _type = details.Substring(startIndex + 1, endIndex - startIndex - 1);

            startIndex = details.IndexOf("{");
            endIndex = details.IndexOf("}");
            if (startIndex > -1
                && endIndex > -1)
            {
                foreach (var value in details.Substring(startIndex + 1, endIndex - startIndex - 1).Split(','))
                {
                    _values.Add(value.Trim());
                }
            }
        }
    }
}
