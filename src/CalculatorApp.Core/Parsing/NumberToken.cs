using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core.Parsing
{
    public class NumberToken:Token
    {
        public double Value { get; }

        public NumberToken(double value)
        {
            Value = value;
        }

    }
}
