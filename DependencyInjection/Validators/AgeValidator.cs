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
        public bool IsValid(string s, out int retVal)
        {
            retVal = int.MinValue;

            if (int.TryParse(s, out int i) == false) // protože formát
            {
                return false;
            }

            if (i > 0 && i < 150) // protože rozsah
            {
                retVal = i;
                return true;
            }

            return false;
        }
    }
}
