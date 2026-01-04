using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core
{
    public sealed class MultiplyOperator : IOperator
    {
        public char Symbol => '*';
        public int Precedence => 2;

        public double Execute(double a, double b) => a * b;
    }
}
