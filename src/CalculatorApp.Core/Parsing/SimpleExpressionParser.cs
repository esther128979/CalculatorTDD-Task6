using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace CalculatorApp.Core.Parsing
{
    public sealed class SimpleExpressionParser:IExpressionParser
    {
        private readonly OperatorRegistry _operators;

        public SimpleExpressionParser(OperatorRegistry operators)
        {
            _operators = operators;
        }

        public IReadOnlyList<Token> Parse(string expression)
        {
            if (expression is null) throw new ArgumentNullException(nameof(expression));

            var tokens = new List<Token>();
            int i = 0;

            while (i < expression.Length)
            {
                // 1) דילוג על רווחים לבנים
                if (char.IsWhiteSpace(expression[i]))
                {
                    i++;
                    continue;
                }

               
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    var op = _operators.Get(expression[i]);
                    tokens.Add(new OperatorToken(op));
                    i++;
                    continue;
                }

                // 3) מספר (כרגע ספרות בלבד: 0-9, נרחיב אחר כך)
                if (char.IsDigit(expression[i]))
                {
                    int start = i;
                    while (i < expression.Length && char.IsDigit(expression[i]))
                        i++;

                    var text = expression.Substring(start, i - start);
                    var value = double.Parse(text, CultureInfo.InvariantCulture);

                    tokens.Add(new NumberToken(value));
                    continue;
                }

                // 4) כל דבר אחר כרגע לא חוקי
                throw new InvalidOperationException($"Invalid character '{expression[i]}' in expression.");
            }

            return tokens;
        }
    }
}
