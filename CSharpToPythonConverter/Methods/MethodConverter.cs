using System.Text;

namespace CSharpToPythonConverter.Methods
{
    public static class MethodCallConverter
    {
        public static string Convert(MethodCall method)
        {
            var codeBuilder = new StringBuilder();
            var appendCode = new StringBuilder();

            if (string.Equals(method.FullName, "Console.WriteLine"))
            {
                codeBuilder.Append("print");
            }
            else if (string.Equals(method.FullName, "Console.Write"))
            {
                LibraryImport.Instance.Add("__future__", "print_function");
                codeBuilder.Append("print");
                appendCode.Append("end=''");
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

            if (!string.IsNullOrEmpty(appendCode.ToString()))
            {
                codeBuilder.Append(',');
                codeBuilder.Append(' ');
                codeBuilder.Append(appendCode.ToString());
            }

            codeBuilder.Append(")");
            
            return codeBuilder.ToString();
        }
    }
}
