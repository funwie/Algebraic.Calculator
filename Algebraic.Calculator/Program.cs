using System;

namespace Algebraic.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var expression = args[0];
                var expressionPostfix = expression.ToPostfix();
                var result = BasicCalculator.Evaluate(expressionPostfix);
                PrintResults(expression, result.ToString());
            }
            else
            {
                var expression1 = "1 + 1";
                var expression1Postfix = expression1.ToPostfix();
                var result1 = BasicCalculator.Evaluate(expression1Postfix);
                PrintResults(expression1, result1.ToString());


                var expression2 = " 2-1 + 2 ";
                var expression2Postfix = expression2.ToPostfix();
                var result2 = BasicCalculator.Evaluate(expression2Postfix);
                PrintResults(expression2, result2.ToString());


                var expression3 = "1*4 + 5 + 2-3 + 6/8";
                var expression3Postfix = expression3.ToPostfix();
                var result3 = BasicCalculator.Evaluate(expression3Postfix);
                PrintResults(expression3, result3.ToString());


                var expression4 = "7-8/6* 6 + 25 / 4-20 / 78* 3 ";
                var expression4Postfix = expression4.ToPostfix();
                var result4 = BasicCalculator.Evaluate(expression4Postfix);
                PrintResults(expression4, $"{result4}");


                var expression5 = " 100 + 50 +25-75  ";
                var expression5Postfix = expression5.ToPostfix();
                var result5 = BasicCalculator.Evaluate(expression5Postfix);
                PrintResults(expression5, result5.ToString());
            }
        }

        static void PrintResults(string expression, string result)
        {
            var fractionString = "";
            if (result.Contains("."))
            {
                var fraction = Fraction.Parse(Double.Parse(result));
                fractionString = $" = {fraction.Numerator}/{fraction.Denominator}";
            }

            Console.WriteLine($"{expression} = {result} {fractionString}");
            Console.WriteLine();
        }
    }
}
