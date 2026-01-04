using System.Collections.Generic;
using CalculatorApp.Core.Evaluation;
using CalculatorApp.Core.Parsing;

namespace CalculatorApp.Core
{
    public sealed class Calculator
    {
        private readonly IExpressionParser _parser;
        private readonly IExpressionEvaluator _evaluator;

        
        public Calculator()
     : this(
         new SimpleExpressionParser(
             new OperatorRegistry(new List<IOperator>
             {
                new AddOperator(),
                new SubtractOperator(),
                new MultiplyOperator()
             })
         ),
         new SimpleExpressionEvaluator()
     )
        {
        }



        // מאפשר בדיקות/הזרקת תלויות (DIP)
        public Calculator(IExpressionParser parser, IExpressionEvaluator evaluator)
        {
            _parser = parser;
            _evaluator = evaluator;
        }

        public double Calculate(string expression)
        {
            var tokens = _parser.Parse(expression);
            return _evaluator.Evaluate(tokens);
        }
    }
}
