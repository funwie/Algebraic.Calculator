using Algebraic.Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algebraic.CalculatorTests
{
    [TestClass]
    public class AlgebraicParserTests
    {

        [TestMethod]
        public void ParseTwoNumbersWithAddition_ReturnPostfix()
        {
            var expression = "1 + 1";

            var expected = "11+";

            var result = expression.ToPostfix();
            var actual = string.Join("", result);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseNumbersWithAdditionAndSubtraction_ReturnPostfix()
        {
            var expression = " 2-1 + 2 ";

            var expected = "21-2+";

            var result = expression.ToPostfix();
            var actual = string.Join("", result);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseNumbersWithAdditionAndSubtractionAndMultiplication_ReturnPostfix()
        {
            var expression = "1*4 + 5 + 2-3 + 6/8";

            var expected = "14*5+2+3-68/+";

            var result = expression.ToPostfix();
            var actual = string.Join("", result);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseNumbersWithAdditionAndSubtractionAndMultiplicationAndDivision_ReturnPostfix()
        {
            var expression = "7-8/6* 6 + 25 / 4-20 / 78* 3 ";

            var expected = "786/6*-254/+2078/3*-";

            var result = expression.ToPostfix();
            var actual = string.Join("", result);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseEmptyNumber_ThrowArgumentException()
        {
            var expression = " ";

            var result = expression.ToPostfix();
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void ParseInValidExpression_ThrowArithmeticExceptionException()
        {
            var expression = "1 MN 0";

            var result = expression.ToPostfix();
        }
    }
}
