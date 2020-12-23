﻿using CSharpToPythonConverter.Global_Storage;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpToPythonConverter.Methods
{
    public class Method : ICSharpObject
    {
        private string _name;
        private string _returnType;
        private List<string> _parameters;
        private string _accessModifier;

        public Method(string details)
        {
            LoadDetails(details);
        }

        public Method()
        {
        }

        public bool IsMatch(string details)
        {
            var methodDetail = details.Split(' ');
            var containsAccessModifier = false;
            foreach (var modifier in AccessModifiers.ListOfAccessModifiers)
            {
                if (details.Contains(modifier))
                {
                    containsAccessModifier = true;
                }
            }
            return details.EndsWith(")")
                && details.Contains("(")
                && containsAccessModifier;
        }

        public string GetPythonEquivalent()
        {
            var codeBuilder = new StringBuilder();
            codeBuilder.Append("def");
            codeBuilder.Append(' ');
            codeBuilder.Append(_name);
            codeBuilder.Append("(");

            if (_parameters != null
                && _parameters.Any())
            {
                var count = 0;
                foreach (var parameter in _parameters)
                {
                    if (count > 0)
                    {
                        codeBuilder.Append(',');
                    }
                    codeBuilder.Append(parameter);
                    count++;
                }
            }

            codeBuilder.Append(")");
            codeBuilder.Append(":");
            return codeBuilder.ToString();
        }

        public void LoadDetails(string details)
        {
            var methodDetail = details.Split(' ');

            if (methodDetail.Any())
            {
                _accessModifier = methodDetail[0];
                _returnType = methodDetail[1];
                _name = methodDetail[2].Substring(0, methodDetail[2].IndexOf("("));

                var startIndex = details.IndexOf("(");
                var endIndex = details.IndexOf(")");
                var parameterDetail = details.Substring(startIndex + 1, (endIndex - startIndex) - 1);
                _parameters = new List<string>();
                foreach (var parameter in parameterDetail.Split(','))
                {
                    _parameters.Add(parameter);
                }
            }
        }
    }
}