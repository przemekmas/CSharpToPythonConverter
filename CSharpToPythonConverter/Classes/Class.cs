using System.Linq;

namespace CSharpToPythonConverter.Classes
{
    public class Class : ICSharpObject
    {
        private string _name;

        public Class()
        {
        }

        public string GetPythonEquivalent()
        {
            return $"class {_name}:";
        }

        public void LoadDetails(string details)
        {
            var classDetail = details.Split(' ');
            _name = classDetail[2];
        }

        public bool IsMatch(string details)
        {
            var lines = details.Split(' ');
            return details.Contains("class")
                && lines.Any()
                && lines[1] == "class";
        }
    }
}
