using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Fractional.Tests
{
    public class FractionalArithmeticOperatorsTests
    {
        [Theory]
        [InlineData("3/4", "1/2", 5, 4)]
        [InlineData("-7/4", "1/4", -3, 2)]
        [InlineData("-2", "0", -2, 1)]
        [InlineData("-7 3/4", "4 3/4", -3, 1)]
        public void FractionalToFractionalAddition(string input1, string input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);
            var f2 = new Fractional(input2);

            var result = f1 + f2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }


        [Theory]
        [InlineData("3/4", "1/2", 1, 4)]
        [InlineData("-7/4", "1/4", -2, 1)]
        [InlineData("-2", "0", -2, 1)]
        [InlineData("-7 3/4", "4 3/4", -25, 2)]
        public void FractionalToFractionalSubtraction(string input1, string input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);
            var f2 = new Fractional(input2);

            var result = f1 - f2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }


        [Theory]
        [InlineData("3/4", "1/2", 3, 8)]
        [InlineData("-7/4", "1/4", -7, 16)]
        [InlineData("-2", "0", 0, 1)]
        [InlineData("-7 3/4", "4 3/4", -589, 16)]
        public void FractionalToFractionalMultiplication(string input1, string input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);
            var f2 = new Fractional(input2);

            var result = f1 * f2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }


        [Theory]
        [InlineData("3/4", "1/2", 3, 2)]
        [InlineData("-7/4", "1/4", -7, 1)]
        [InlineData("-7 3/4", "4 3/4", -31, 19)]
        public void FractionalToFractionalDivision(string input1, string input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);
            var f2 = new Fractional(input2);
           
            var result = f1 / f2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }

        [Theory]
        [InlineData("3/4", "1/2", 5, 4)]
        [InlineData("-7/4", "1/4", -3, 2)]
        [InlineData("-2", "0", -2, 1)]
        [InlineData("-7 3/4", "4 3/4", -3, 1)]
        public void FractionalToStringAddition(string input1, string input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);

            var result = f1 + input2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }

        [Theory]
        [InlineData("3/4", "1/2", 1, 4)]
        [InlineData("-7/4", "1/4", -2, 1)]
        [InlineData("-2", "0", -2, 1)]
        [InlineData("-7 3/4", "4 3/4", -25, 2)]
        public void FractionalToStringSubtraction(string input1, string input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);

            var result = f1 - input2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }


        [Theory]
        [InlineData("3/4", "1/2", 3, 8)]
        [InlineData("-7/4", "1/4", -7, 16)]
        [InlineData("-2", "0", 0, 1)]
        [InlineData("-7 3/4", "4 3/4", -589, 16)]
        public void FractionalToStringMultiplication(string input1, string input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);

            var result = f1 * input2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }


        [Theory]
        [InlineData("3/4", "1/2", 3, 2)]
        [InlineData("-7/4", "1/4", -7, 1)]
        [InlineData("-7 3/4", "4 3/4", -31, 19)]
        public void FractionalToStringDivision(string input1, string input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);

            var result = f1 / input2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }



        [Theory]
        [InlineData("3/4", 0.5d, 5, 4)]
        [InlineData("-7/4", 0.25d, -3, 2)]
        [InlineData("-2", 0, -2, 1)]
        [InlineData("3/4", 1.75d, 5, 2)]
        public void FractionalToDecimalAddition(string input1, decimal input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);

            var result = f1 + input2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }

        [Theory]
        [InlineData("3/4", 0.5d, 1, 4)]
        [InlineData("-7/4", 0.25d, -2, 1)]
        [InlineData("-2", 0, -2, 1)]
        [InlineData("3/4", 1.75d, -1, 1)]
        public void FractionalToDecimalSubtraction(string input1, decimal input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);

            var result = f1 - input2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }


        [Theory]
        [InlineData("3/4", 0.5d, 3, 8)]
        [InlineData("-7/4", 0.25d, -7, 16)]
        [InlineData("-2", 0, 0, 1)]
        [InlineData("3/4", 1.75d, 21, 16)]
        public void FractionalToDecimalMultiplication(string input1, decimal input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);

            var result = f1 * input2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }


        [Theory]
        [InlineData("3/4", 0.5d, 3, 2)]
        [InlineData("-7/4", 0.25d, -7, 1)]
        [InlineData("3/4", 1.75d, 3, 7)]
        public void FractionalToDecimalDivision(string input1, decimal input2, long expectedNumerator, long expectedDenominator)
        {
            var f1 = new Fractional(input1);

            var result = f1 / input2;

            Assert.False(result.IsNaN);
            Assert.Equal(expectedDenominator, result.Denominator);
            Assert.Equal(expectedNumerator, result.Numerator);
        }

    }
}