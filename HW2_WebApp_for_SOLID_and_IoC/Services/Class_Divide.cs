using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2_WebApp_for_SOLID_and_IoC.Services
{
    public class Class_Divide : IDivide
    {
        public double Divide(double first_number, double second_number)
        {
            return first_number / second_number;
        }
    }
    public class AnotherDivide : IDivide
    {
        public double Divide(double first_number, double second_number)
        {
            return first_number / second_number + 0.7;
        }
    }
}
