using CSharpToPythonConverter.Conditions;

namespace CSharpToPythonConverter.Statements
{
    public class SelectionStatement : ICSharpObject
    {
        private string _statementType;
        private Condition _condition;

        public void LoadDetails(string details)
        {
            if (details.StartsWith("else")
                && !details.Contains("else if"))
            {
                _statementType = "else";
            }
            else
            {
                var startIndex = details.IndexOf("(");
                var endIndex = details.IndexOf(")");
                var conditionDetail = details.Substring(startIndex + 1, (endIndex - startIndex) - 1);
                _condition = new Condition(conditionDetail);

                var statementType = details.Substring(0, startIndex);
                if (statementType.StartsWith("else if"))
                {
                    _statementType = "elif";
                }
                else
                {
                    _statementType = statementType;
                }
            }
        }

        public string GetPythonEquivalent()
        {
            return $"{_statementType} {_condition?.GetPythonEquivalent()}:";
        }

        public bool IsMatch(string details)
        {
            return (details.StartsWith("if")
                || details.StartsWith("else if"))
                && details.EndsWith(")")
                && details.Contains("(")
                || details.StartsWith("else");
        }
    }
}
