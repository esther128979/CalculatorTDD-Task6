using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Generic;
using CalculatorApp.Core.Parsing;

namespace CalculatorApp.Core.Evaluation
{
    public  interface IExpressionEvaluator
    {
        double Evaluate(IReadOnlyList<Token> tokens);
    }
}
