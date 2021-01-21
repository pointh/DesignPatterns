using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Validators
{
    /// <summary>
    /// Validátor pro Japonské občany
    /// </summary>
    class JapanAgeValidator : IIntValidator
    {
        /// <summary>
        /// Validační metoda, která je implementací interface IIntValidator
        /// </summary>
        /// <param name="s">String, který se má převádět na int a validovat</param>
        /// <returns>
        /// Vrací validovaný věk nebo int.MinValue, pokud vstupní string
        /// není parsovatelný na int nebo je parsované číslo mimo rozsah
        /// (1, 200).
        /// </returns>

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
