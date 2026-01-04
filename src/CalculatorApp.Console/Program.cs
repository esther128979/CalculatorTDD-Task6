using System;
using CalculatorApp.Core;

namespace CalculatorApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Calculator (type an expression). Type 'exit' to quit.");
            var calculator = new Calculator();

            while (true)
            {
                System.Console.Write("> ");
                var input = System.Console.ReadLine();

                if (input == null)
                    continue;

                input = input.Trim();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                if (input.Length == 0)
                    continue;

                try
                {
                    var result = calculator.Calculate(input);
                    System.Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    
                    System.Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
