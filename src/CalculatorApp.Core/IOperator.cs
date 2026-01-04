using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core
{
    public interface IOperator
    {
        char Symbol { get; }       // +, -, *, /
        int Precedence { get; }    // סדר פעולות
        double Execute(double a, double b); // החישוב עצמו


    }
}
