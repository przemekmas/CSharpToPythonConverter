using CSharpToPythonConverter.Global_Storage;

namespace CSharpToPythonConverter.Types
{
    public class Initializer : ICSharpObject
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public Initializer(string details)
        {
            LoadDetails(details);
        }

        public Initializer()
        {
        }

        public void LoadDetails(string details)
        {
            details = details.Trim();
            var type = details.Split(' ')[0];
            var bracketIndex = type.IndexOf("(");
            if (bracketIndex > -1)
            {
                type = type.Remove(bracketIndex, 1);
            }
            Type = type;

            var propertyName = details.Substring(0, details.IndexOf('='));
            var pname = propertyName.Trim().Split(' ');
            var name = pname[pname.Length - 1];
            Name = name;

            var startIndex = details.IndexOf('=');
            var endIndex = details.IndexOf(';') > -1 ? details.IndexOf(';') : details.Length;

            var propertyValue = details.Substring(startIndex + 1, endIndex - startIndex - 1);
            Value = propertyValue.Trim();
        }

        public bool IsMatch(string details)
        {
            var hasType = false;
            foreach (var type in CSharpTypes.ListOfTypes)
            {
                if (details.Contains(type))
                {
                    hasType = true;
                }
            }
            return details.Contains("=")
                && (hasType || details.Contains("var"))
                && !details.Contains("new")
                && !details.StartsWith("for");
        }

        public string GetPythonEquivalent()
        {
            return $"{Name} = {Value}";
        }
    }
}
