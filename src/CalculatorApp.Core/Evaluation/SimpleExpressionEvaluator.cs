using System;
using System.Collections.Generic;
using CalculatorApp.Core.Parsing;

namespace CalculatorApp.Core.Evaluation
{
    public sealed class SimpleExpressionEvaluator : IExpressionEvaluator
    {
        public double Evaluate(IReadOnlyList<Token> tokens)
        {
            if (tokens is null) throw new ArgumentNullException(nameof(tokens));
            if (tokens.Count == 0) throw new InvalidOperationException("Empty expression.");

            // Expect: Number (Operator Number)*
            if (tokens[0] is not NumberToken)
                throw new InvalidOperationException("Expression must start with a number.");

            var values = new Stack<double>();
            var ops = new Stack<IOperator>();

            // first number
            values.Push(((NumberToken)tokens[0]).Value);

            for (int i = 1; i < tokens.Count; i += 2)
            {
                if (i + 1 >= tokens.Count)
                    throw new InvalidOperationException("Expression cannot end with an operator.");

                if (tokens[i] is not OperatorToken opToken)
                    throw new InvalidOperationException("Expected operator token.");

                if (tokens[i + 1] is not NumberToken numToken)
                    throw new InvalidOperationException("Expected number token.");

                var currentOp = opToken.Operator;

                // Apply operators already on stack with higher or equal precedence
                while (ops.Count > 0 && ops.Peek().Precedence >= currentOp.Precedence)
                {
                    ApplyTopOperator(values, ops);
                }

                ops.Push(currentOp);
                values.Push(numToken.Value);
            }

            while (ops.Count > 0)
            {
                ApplyTopOperator(values, ops);
            }

            if (values.Count != 1)
                throw new InvalidOperationException("Invalid expression.");

            return values.Pop();
        }

        private static void ApplyTopOperator(Stack<double> values, Stack<IOperator> ops)
        {
            if (values.Count < 2)
                throw new InvalidOperationException("Invalid expression.");

            var right = values.Pop();
            var left = values.Pop();
            var op = ops.Pop();

            values.Push(op.Execute(left, right));
        }
    }
}
