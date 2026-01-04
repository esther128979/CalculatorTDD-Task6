using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core.Parsing
{
    public class OperatorToken : Token
    {
        public IOperator Operator { get; }

        public OperatorToken(IOperator op)
        {
            Operator = op;
        }


    }
}
