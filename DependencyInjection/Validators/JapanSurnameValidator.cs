using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Validators
{
    class JapanSurnameValidator : IStringValidator
    {
        public bool IsValid(string s)
        {
            SurnameValidator sv = new SurnameValidator();
            return sv.IsValid(s) &&
                Array.IndexOf(new string[] { "Suzuki", "Kawasaki", "Sato", "Takahashi" }, s) != -1;
        }
    }
}
