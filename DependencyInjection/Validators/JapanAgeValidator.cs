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
    class JapanAgeValidator:IIntValidator
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
        public int IsValid(string s)
        {
            int i;
            if (int.TryParse(s, out i) == false)
                return int.MinValue;

            if (i > 0 && i < 200)
                return i;

            return int.MinValue;
        }
    }
}
