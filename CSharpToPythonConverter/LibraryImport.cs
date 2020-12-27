using System.Collections.Generic;

namespace CSharpToPythonConverter
{
    public class LibraryImport
    {
        private readonly List<string> _imports = new List<string>();
        private static LibraryImport _libraryImport;

        public static LibraryImport Instance 
        {    
            get
            {
                if (_libraryImport == null)
                {
                    _libraryImport = new LibraryImport();

                }
                return _libraryImport;
            }
        }

        public void Add(string from, string import)
        {
            if (!_imports.Contains($"from {from} import {import}"))
            {
                _imports.Add($"from {from} import {import}");
            }
        }

        public void Add(string import)
        {
            if (!_imports.Contains($"import {import}"))
            {
                _imports.Add($"import {import}");
            }
        }

        public List<string> GetAllImports()
        {
            return _imports;
        }
    }
}
