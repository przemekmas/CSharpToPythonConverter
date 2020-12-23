namespace CSharpToPythonConverter
{
    public interface ICSharpObject
    {
        string GetPythonEquivalent();
        void LoadDetails(string details);
        bool IsMatch(string details);
    }
}
