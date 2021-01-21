using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    interface IIntValidator
    {
        bool IsValid(string s, out int retVal);
    }
}
