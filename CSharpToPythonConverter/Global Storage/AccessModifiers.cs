using System.Collections.Generic;

namespace CSharpToPythonConverter.Global_Storage
{
    public static class AccessModifiers
    {
        public static List<string> ListOfAccessModifiers => new List<string>()
        {
            "public",
            "protected",
            "internal",
            "protected internal",
            "private",
            "private protected"
        };
    }
}
