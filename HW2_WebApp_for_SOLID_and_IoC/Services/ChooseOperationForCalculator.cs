using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2_WebApp_for_SOLID_and_IoC.Services
{
    public class ChooseOperationForCalculator : IChooseOperationForCalculator
    {
        public Func<double, double, double> Choose(string op, IPlus plus, IMinus minus, IMultiply multiply, IDivide divide)
        {
            switch (op[0])
            {
                case 'd':
                    return divide.Divide;
                case 'u':
                    return multiply.Multiply;
                case 'm':
                    return minus.Minus;
                case 's':
                    return plus.Plus;
                default: throw new Exception("Validation false");
            }            
        }
    }
}
