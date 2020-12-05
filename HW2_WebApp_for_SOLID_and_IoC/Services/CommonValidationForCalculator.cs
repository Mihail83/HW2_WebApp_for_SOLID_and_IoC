using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HW2_WebApp_for_SOLID_and_IoC.Services
{
    public class CommonValidationForCalculator : IValidationForCalculator
    {
        public bool OkForCalculator(string[] key)
        {
            double stub;
            bool op=false;
            string[] keys = { "s", "m", "u", "d" };
            foreach (var symbol in keys)
                {
                    if (key[2].Equals(symbol))
                    {
                    op = true;
                    break;
                    }                
                }            
            return  double.TryParse(key[0], out stub)
                    && double.TryParse(key[1], out stub) && op;
        }
    }
}
