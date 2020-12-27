namespace CSharpToPythonConverter.Conditions
{
    public class ConditionalOperator : ICSharpObject
    {
        private string _operator;

        public void LoadDetails(string details)
        {
            if (details.Contains("&&")
                || details.Contains("&"))
            {
                _operator = "and";
            }
            else if (details.Contains("||")
                || details.Contains("|"))
            {
                _operator = "or";
            }
        }

        public string GetPythonEquivalent()
        {
            return _operator;
        }

        public bool IsMatch(string details)
        {
            return false;
        }
    }
}
