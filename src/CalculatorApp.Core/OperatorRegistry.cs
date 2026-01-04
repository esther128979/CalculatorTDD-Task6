using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorApp.Core
{
    public sealed class OperatorRegistry
    {
        private readonly Dictionary<char, IOperator> _map = new();

        public OperatorRegistry(IEnumerable<IOperator> operators)
        {
            foreach (var op in operators)
                _map[op.Symbol] = op;
        }

        public IOperator Get(char symbol)
        {
            if (!_map.TryGetValue(symbol, out var op))
                throw new InvalidOperationException($"Unknown operator '{symbol}'.");
            return op;
        }
    }
}
