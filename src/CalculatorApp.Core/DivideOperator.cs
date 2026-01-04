using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core
{
    public sealed class DivideOperator : IOperator
    {
        public char Symbol => '/';
        public int Precedence => 2;

        public double Execute(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }
    }
}
