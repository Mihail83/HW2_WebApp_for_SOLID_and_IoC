using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2_WebApp_for_SOLID_and_IoC.Services
{
    public interface IChooseOperationForCalculator
    {
        //сменить на массив double?////////////////////////////
        public  Func<double,double,double> Choose(string op, IPlus plus, IMinus minus, IMultiply multiply, IDivide divide);

    }
}
