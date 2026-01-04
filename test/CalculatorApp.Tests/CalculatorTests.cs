using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using CalculatorApp.Core;

namespace CalculatorApp.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculate_WithSimpleAddition_ReturnsCorrectResult()
        {

            var add = new AddOperator();
            double result = add.Execute(2, 5);
            Assert.Equal(7, result);
        }


        [Fact]
        public void Calculate_WithSubtraction_ReturnsCorrectResult()
        {
            var calculator = new Calculator();
            var result = calculator.Calculate("5   -3");
            Assert.Equal(2, result);
        }


        



    }
}
