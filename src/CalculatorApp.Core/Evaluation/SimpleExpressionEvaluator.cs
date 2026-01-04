using CalculatorApp.Core.Parsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core.Evaluation
{
    public sealed class SimpleExpressionEvaluator: IExpressionEvaluator
    {
        public double Evaluate(IReadOnlyList<Token> tokens)
        {
            if (tokens is null) throw new ArgumentNullException(nameof(tokens));
            if (tokens.Count == 0) throw new InvalidOperationException("Empty expression.");

            // Expect: Number (+ Number)*
            if (tokens[0] is not NumberToken first)
                throw new InvalidOperationException("Expression must start with a number.");

            double result = first.Value;

            for (int i = 1; i < tokens.Count; i += 2)
            {
                if (i + 1 >= tokens.Count)
                    throw new InvalidOperationException("Expression cannot end with an operator.");

                if (tokens[i] is not OperatorToken opToken)
                    throw new InvalidOperationException("Expected operator token.");

                if (tokens[i + 1] is not NumberToken numToken)
                    throw new InvalidOperationException("Expected number token.");

                // כרגע פשוט מפעילים את האופרטור (אצלך זה יהיה AddOperator)
                result = opToken.Operator.Execute(result, numToken.Value);
            }

            return result;
        }
    }
}
