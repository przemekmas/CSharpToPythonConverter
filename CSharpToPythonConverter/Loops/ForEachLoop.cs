using System.Linq;

namespace CSharpToPythonConverter.Loops
{
    public class ForEachLoop : ICSharpObject
    {
        private string _itemName;
        private string _listName;

        public string GetPythonEquivalent()
        {
            return $"for {_itemName} in {_listName}:";
        }

        public bool IsMatch(string details)
        {
            return details.StartsWith("foreach")
                && details.Contains('(')
                && details.Contains(')')
                && details.Contains("in");
        }

        public void LoadDetails(string details)
        {
            var startIndex = details.IndexOf("(");
            var endIndex = details.IndexOf(")");

            var loopDetail = details.Substring(startIndex + 1, endIndex - startIndex - 1);
            var items = loopDetail.Split(' ');
            _itemName = items[1];
            _listName = items[3];
        }
    }
}
