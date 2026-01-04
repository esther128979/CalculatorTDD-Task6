using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core
{
    public class AddOperator : IOperator
    {
        public char Symbol => '+';
        public int Precedence => 1;
        public double Execute(double a, double b)
        {
            return a + b;
        }

    }
}
