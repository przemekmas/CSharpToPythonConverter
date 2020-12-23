using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharpToPythonConverter.Processor
{
    public static class CSharpCodeReadOperations
    {
        public static void Read(string code)
        {
            var codeBuilder = new StringBuilder();
            var currentIndent = string.Empty;

            using (var reader = new StringReader(code))
            {
                string line;
                var isCommentedOut = false;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (string.IsNullOrEmpty(line))
                    {
                        codeBuilder.AppendLine();
                    }
                    if (SetCurrentIndentation(ref currentIndent, line))
                    {
                        continue;
                    }
                    var foundMatchForLineOfCode = false;

                    if (line.StartsWith("/*"))
                    {
                        isCommentedOut = true;
                    }
                    if (line.EndsWith("*/"))
                    {
                        isCommentedOut = false;
                    }
                    
                    foreach (var type in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                        .Where(mytype => mytype.GetInterfaces().Contains(typeof(ICSharpObject))))
                    {
                        if (Activator.CreateInstance(type) is ICSharpObject cSharpObject
                            && cSharpObject.IsMatch(line))
                        {
                            cSharpObject.LoadDetails(line);
                            codeBuilder.Append(currentIndent);
                            if (line.StartsWith("//")
                                || isCommentedOut)
                            {
                                codeBuilder.Append('#');
                            }
                            
                            codeBuilder.Append(EvaluateKeywordProcessor.Evaluate(cSharpObject.GetPythonEquivalent()));
                            codeBuilder.AppendLine();
                            foundMatchForLineOfCode = true;
                        }
                    }

                    if (!foundMatchForLineOfCode)
                    {
                        if (line.StartsWith("//")
                            || isCommentedOut)
                        {
                            codeBuilder.Append('#');
                        }
                        codeBuilder.Append(currentIndent);
                        codeBuilder.Append(EvaluateKeywordProcessor.Evaluate(line));
                        codeBuilder.AppendLine();
                    }
                }
            }

            Console.WriteLine(codeBuilder.ToString());
        }

        private static bool SetCurrentIndentation(ref string currentIndent, string line)
        {
            if (line.StartsWith("{"))
            {
                currentIndent += "\t";
                return true;
            }
            else if (line.StartsWith("}"))
            {
                currentIndent = currentIndent.Remove(0, 1);
                return true;
            }

            return false;
        }
    }
}
