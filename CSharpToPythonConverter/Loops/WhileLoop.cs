using CSharpToPythonConverter.Conditions;

namespace CSharpToPythonConverter.Loops
{
    public class WhileLoop : ICSharpObject
    {
        private Condition _condition;

        public string GetPythonEquivalent()
        {
            return $"while {_condition.GetPythonEquivalent()}:";
        }

        public bool IsMatch(string details)
        {
            return details.TrimStart().StartsWith("while");
        }

        public void LoadDetails(string details)
        {
            var startIndex = details.IndexOf("(");
            var endIndex = details.IndexOf(")");
            _condition = new Condition(details.Substring(startIndex + 1, endIndex - startIndex - 1));
        }
    }
}
