using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Validators
{
    // Service class
    // Poskytuje službu validace vstupu typu string
    class SurnameValidator : IStringValidator
    {
        public bool IsValid(string s) { return s.Length > 1; }
    }
}
