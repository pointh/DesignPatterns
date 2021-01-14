using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Validators
{
    // Service class
    // Poskytuje službu validace vstupu typu int

    class AgeValidator : IIntValidator
    {
        public int IsValid(string s)
        {
            int i;
            if (int.TryParse(s, out i) == false)
                return int.MinValue;

            if (i > 0 && i < 150)
                return i;

            return int.MinValue;
        }
    }
}
