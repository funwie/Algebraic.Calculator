using System;
using System.Collections.Generic;
using System.Linq;

namespace Algebraic.Calculator
{
    public static class BasicCalculator
    {
        public static double Evaluate(List<string> tokens)
        {
            if (tokens == null || !tokens.Any())
            {
                return 0.0;
            }


            if (tokens.Count < 3)
            {
                return 0.0;
            }

            var results = new Stack<double>();

            foreach (var token in tokens)
            {
                if (IsDigits(token))
                {
                    results.Push(double.Parse(token));
                }
                else
                {
                    var op1 = 0.0;
                    var op2 = 0.0;
                    if (results.Count > 1)
                    {
                        op1 = results.Pop();
                        op2 = results.Pop();
                    }
                    var ans = 0.0;

                    switch (token)
                    {
                        case "+":
                            ans = op2 + op1;
                            break;
                        case "-":
                            ans = op2 - op1;
                            break;
                        case "*":
                            ans = op2 * op1;
                            break;
                        case "/":
                            if (op1 == 0)
                            {
                                throw new DivideByZeroException();
                            }
                            ans = op2 / op1;
                            break;
                        default:
                            throw new ArgumentException(token);
                    }
                    results.Push(ans);
                }
            }
            if (results.Count > 1)
            {
                throw new ArithmeticException("Invalid expression");
            }

            return results.Pop();
        }

        public static bool IsDigit(char digit)
        {
            var digits = new HashSet<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            return digits.Contains(digit);
        }

        public static bool IsDigits(string digits)
        {
            return digits.ToCharArray().All(x => IsDigit(x));
        }

        public static bool IsOperator(char op)
        {
            var operators = new HashSet<char> { '-', '+', '*', '/', '(', ')' };
            return operators.Contains(op);
        }

    }
}
