using System.Text;

namespace CSharpToPythonConverter.Methods
{
    public static class MethodCallConverter
    {
        public static string Convert(MethodCall method)
        {
            var codeBuilder = new StringBuilder();

            if (string.Equals(method.FullName, "Console.WriteLine"))
            {
                codeBuilder.Append("print");
            }
            else if (string.Equals(method.FullName, "Console.Write"))
            {
                codeBuilder.Append("print");
            }
            else
            {
                codeBuilder.Append(method.FullName);
            }

            codeBuilder.Append("(");
            var count = 0;
            foreach (var parameter in method.Parameters)
            {
                if (count > 0)
                {
                    codeBuilder.Append(",");
                }
                codeBuilder.Append(parameter);
                count++;
            }

            codeBuilder.Append(")");
            return codeBuilder.ToString();
        }
    }
}
