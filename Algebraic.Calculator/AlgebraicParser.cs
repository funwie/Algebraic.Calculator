using System;
using System.Collections.Generic;
using System.Linq;

namespace Algebraic.Calculator
{
    public static class AlgebraicParser
    {
        private static readonly Dictionary<string, (string symbol, int precedence, bool rightAssociative)> operators
            = new (string symbol, int precedence, bool rightAssociative)[] {
            ("^", 4, true),
            ("*", 3, false),
            ("/", 3, false),
            ("+", 2, false),
            ("-", 2, false)
        }.ToDictionary(op => op.symbol);

        private static IEnumerable<string> Tokenize(this string stringExpression)
        {
            char previous = ' ';
            var token = new List<string>();

            foreach (char character in stringExpression.ToCharArray())
            {
                if (BasicCalculator.IsDigit(previous) && BasicCalculator.IsDigit(character))
                {
                    token[token.Count - 1] = token.Last() + character;
                }

                else if (BasicCalculator.IsOperator(character))
                {
                    token.Add(character.ToString());
                }
                else if (BasicCalculator.IsDigit(character))
                {
                    token.Add(character.ToString());
                }
                else if (character != ' ')
                {
                    throw new ArithmeticException($"Invalid Algebraic expression {stringExpression}. {character} not allowed");
                }

                previous = character;
            }
            return token;
        }

        public static List<string> ToPostfix(this string infix)
        {
            if (string.IsNullOrWhiteSpace(infix))
            {
                throw new ArgumentException("Empty expression");
            }

            var tokens = infix.Tokenize();
            var stack = new Stack<string>();
            var output = new List<string>();

            foreach (string token in tokens)
            {
                if (int.TryParse(token, out _))
                {
                    output.Add(token);
                }
                else if (operators.TryGetValue(token, out var op1))
                {
                    while (stack.Count > 0 && operators.TryGetValue(stack.Peek(), out var op2))
                    {
                        int c = op1.precedence.CompareTo(op2.precedence);
                        if (c < 0 || !op1.rightAssociative && c <= 0)
                        {
                            output.Add(stack.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }
                    stack.Push(token);
                }
                else if (token == "(")
                {
                    stack.Push(token);
                }
                else if (token == ")")
                {
                    string top = "";
                    while (stack.Count > 0 && (top = stack.Pop()) != "(")
                    {
                        output.Add(top);
                    }
                    if (top != "(")
                    {
                        throw new ArgumentException("No matching left parenthesis.");
                    }
                }
            }
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (!operators.ContainsKey(top))
                { 
                    throw new ArgumentException("No matching right parenthesis."); 
                }
                output.Add(top);
            }

            return output;
        }
    }

}
