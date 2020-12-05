using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2_WebApp_for_SOLID_and_IoC.Services
{
    public interface IValidationForCalculator
    {
        public bool OkForCalculator(string[] key);
    }
}
