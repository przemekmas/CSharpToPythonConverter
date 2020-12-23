using CSharpToPythonConverter.Arithmetic_Operators;
using CSharpToPythonConverter.Conditions;
using CSharpToPythonConverter.Types;
using System.Text;

namespace CSharpToPythonConverter.Loops
{
    public class ForLoop : ICSharpObject
    {
        private Initializer _initializer;
        private Condition _condition;
        private Operator _operator;

        public ForLoop(string details)
        {
            LoadDetails(details);
        }

        public ForLoop()
        {
        }

        public void LoadDetails(string details)
        {
            var startIndex = details.IndexOf('(');
            var endIndex = details.IndexOf(')');
            var code = details.Substring(startIndex, endIndex - startIndex);

            var seperatedCode = code.Split(';');
            _initializer = new Initializer(seperatedCode[0].Trim());
            _condition = new Condition(seperatedCode[1].Trim());
            _operator = new Operator(seperatedCode[2].Trim());
        }

        public string GetPythonEquivalent()
        {
            var codeBuilder = new StringBuilder("for");
            codeBuilder.Append(" ");
            codeBuilder.Append(_initializer.Name);
            codeBuilder.Append(" ");
            codeBuilder.Append("in range");
            codeBuilder.Append(" ");
            codeBuilder.Append("(");

            if (string.Equals(_operator.Type, "++")
                && string.Equals(_operator.Name, _initializer.Name))
            {
                codeBuilder.Append(_initializer.Value);
                codeBuilder.Append(",");
                codeBuilder.Append(_condition.RightValue);
                codeBuilder.Append(",");
                codeBuilder.Append("1");
            }
            else if (string.Equals(_operator.Type, "--")
                && string.Equals(_operator.Name, _initializer.Name))
            {
                codeBuilder.Append(_initializer.Value);
                codeBuilder.Append(",");
                codeBuilder.Append(_condition.RightValue);
                codeBuilder.Append(",");
                codeBuilder.Append("-1");
            }

            codeBuilder.Append("):");

            return codeBuilder.ToString();
        }

        public bool IsMatch(string details)
        {
            return details.TrimStart().StartsWith("for")
                && !details.Contains("foreach");
        }
    }
}