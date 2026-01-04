using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core.Parsing
{
    public interface IExpressionParser
    {
        IReadOnlyList<Token> Parse(string expression);
    }
}
