﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW2_WebApp_for_SOLID_and_IoC.Services
{
    public class Class_Multiply : IMultiply
    {
        public double Multiply(double first_number, double second_number)
        {
            return first_number * second_number;
        }                
    }
    public class AnotherMultiply : IMultiply
    {
        public double Multiply(double first_number, double second_number)
        {
            return first_number * second_number + 0.7;
        }
    }
}

