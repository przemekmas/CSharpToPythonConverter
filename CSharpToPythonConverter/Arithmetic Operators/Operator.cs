namespace CSharpToPythonConverter.Arithmetic_Operators
{
    public class Operator : ICSharpObject
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Operator(string details)
        {
            LoadDetails(details);
        }

        public Operator()
        {
        }

        public void LoadDetails(string details)
        {
            if (details.Contains("++"))
            {
                Type = "++";
            }
            else if (details.Contains("--"))
            {
                Type = "--";
            }

            Name = details.Remove(details.IndexOf(Type), Type.Length);
        }

        public string GetPythonEquivalent()
        {
            return string.Empty;
        }

        public bool IsMatch(string details)
        {
            return false;
        }
    }
}
