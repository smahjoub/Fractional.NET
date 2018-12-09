using System;
using Xunit;


namespace Fractional.Tests
{
    public class FractionalTests
    {
        [Theory]
        [InlineData("7 3/4", 31, 4)]
        [InlineData("-7 3/4", -31, 4)]
        [InlineData("3/4", 3, 4)]
        [InlineData("4", 4, 1)]
        public void ConstructionOfFractionObjectFromString(string value, long expectedNumerator, long expectedDenominator)
        {
            var fractional = new Fractional(value);

            Assert.False(fractional.IsNaN);
            Assert.Equal(expectedDenominator, fractional.Denominator);
            Assert.Equal(expectedNumerator, fractional.Numerator);
        }


        [Theory]
        [InlineData(0.75, 3, 4)]
        [InlineData(1, 1, 1)]
        [InlineData(0.333333, 1, 3)]
        [InlineData(0, 0, 1)]
        public void ConstructionOfFractionObjectFromDecimal(decimal value, long expectedNumerator, long expectedDenominator)
        {
            var fractional = new Fractional(value);

            Assert.False(fractional.IsNaN);
            Assert.Equal(expectedDenominator, fractional.Denominator);
            Assert.Equal(expectedNumerator, fractional.Numerator);

        }


        [Theory]
        [InlineData(3, 4)]
        [InlineData(1, 1)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        public void ConstructionOfFractionObjectFromInteger(long numerator, long denominator)
        {
            var fractional = new Fractional(numerator, denominator);

            Assert.False(fractional.IsNaN);
            Assert.Equal(denominator, fractional.Denominator);
            Assert.Equal(numerator, fractional.Numerator);
        }


        [Theory]
        [InlineData("7 3/0")]
        [InlineData("3/0")]
        public void ZeroDenominator(string zeroDenominator)
        {
            var fractional = new Fractional(zeroDenominator);

            Assert.True(fractional.IsNaN);
        }

        [Theory]
        [InlineData("s7 3/4")]
        [InlineData("-7 3s/4")]
        [InlineData(" s3/4")]
        [InlineData("4s")]
        public void InvalidExpression(string invalidExpression)
        {
            var fractional = new Fractional(invalidExpression);

            Assert.True(fractional.IsNaN);
        }
    }
}
