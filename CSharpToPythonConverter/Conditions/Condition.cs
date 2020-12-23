namespace CSharpToPythonConverter.Conditions
{
    public class Condition : ICSharpObject
    {
        public string RightValue { get; set; }
        private string _leftValue;
        private string _logicalCondition;

        public Condition(string details)
        {
            LoadDetails(details);
        }

        public Condition()
        {
        }

        public void LoadDetails(string details)
        {
            var condition = string.Empty;
            
            if (details.Contains("<="))
            {
                condition = "<=";
            }
            else if (details.Contains(">="))
            {
                condition = ">=";
            }
            else if (details.Contains("=="))
            {
                condition = "==";
            }
            else if (details.Contains("!="))
            {
                condition = "!=";
            }
            else if (details.Contains("<"))
            {
                condition = "<";
            }
            else if (details.Contains(">"))
            {
                condition = ">";
            }

            _leftValue = details.Substring(0, details.IndexOf(condition)).Trim();
            var startIndex = details.IndexOf(condition) + condition.Length;
            RightValue = details.Substring(startIndex, details.Length - startIndex).Trim();
            _logicalCondition = details;
        }

        public string GetPythonEquivalent()
        {
            return _logicalCondition.Replace("&&", "and").Replace("||", "or");
        }

        public bool IsMatch(string details)
        {
            return false;
        }
    }
}
