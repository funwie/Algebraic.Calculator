using Algebraic.Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Algebraic.CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void EvaluateValidToken_ReturnResult()
        {
            var token = new List<string> { "1", "1", "+" };
            var expected = 2;

            var result = BasicCalculator.Evaluate(token);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void EvaluateInValidToken_ThrowArithmeticException()
        {
            var token = new List<string> { "1", "1", "1", "+" };
            var expected = 3;

            var result = BasicCalculator.Evaluate(token);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void EvaluateDivideByZero_ThrowDivideByZeroException()
        {
            var token = new List<string> { "2", "0", "/" };

            var result = BasicCalculator.Evaluate(token);
        }
    }
}
