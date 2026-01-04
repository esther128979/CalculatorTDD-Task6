using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CalculatorApp.Core;

namespace CalculatorApp.Tests
{
    public class OperatorTests
    {
        [Fact]
        public void AddOperator_Execute_ReturnsSum()
        {
            var add = new AddOperator();
            var result = add.Execute(2, 5);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Calculate_IgnoresWhitespace()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(" 2 +  5 ");
            Assert.Equal(7, result);
        }

        [Fact]
        public void Calculate_WithMultipleAdditions_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(" 1 + 2    + 1  ");
            Assert.Equal(4, result);
        }

        [Fact]
        public void Calculate_WithMultiplication_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2*3");
            Assert.Equal(6, result);
        }

    }
}
