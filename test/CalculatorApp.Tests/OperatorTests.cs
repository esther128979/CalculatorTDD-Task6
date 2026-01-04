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
        public void Calculate_WithSubtraction_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("5   -3");
            Assert.Equal(2, result);
        }
       
        [Fact]
        public void Calculate_WithMultipleAdditions_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(" 1 + 2    + 1  ");
            Assert.Equal(4, result);
        }
        [Fact]
        public void Calculate_WithMultipleSubtractions_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate(" 1 - 2    - 1  ");
            Assert.Equal(-2, result);
        }


        [Fact]
        public void Calculate_WithMultiplication_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("2*3");
            Assert.Equal(6, result);
        }

        [Fact]
        public void Calculate_RespectsOperatorPrecedence()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("1 + 2 * 6");
            Assert.Equal(13, result);
        }

        [Fact]
        public void Calculate_WithDivision_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("8/2");
            Assert.Equal(4, result);
        }
        [Fact]
        public void Calculate_DivisionByZero_ThrowsException()
        {
            var calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Calculate("8/0"));
        }
        [Fact]
        public void Calculate_WithMixedOperators_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("6/3+5+8*7");
            Assert.Equal(63, result);
        }
        [Fact]
        public void Calculate_DivisionByZeroInComplexExpression_ThrowsException()
        {
            var calculator = new Calculator();

            Assert.Throws<DivideByZeroException>(
                () => calculator.Calculate("7/7*56/0"));
        }


    }
}
