using Xunit;

namespace Fractional.Tests
{
    public class HumanRepresentationTests
    {
        [Theory]
        [InlineData(1, 4, "1/4")]
        [InlineData(5, 4, "1 1/4")]
        [InlineData(4, 4, "1")]
        [InlineData(0, 4, "0")]
        public void NumeratorAndDenominatorToHumanRepresentationTest(long inputNumerator, long inputDenominator, string expectedOutput)
        {
            var f1 = new Fractional(inputNumerator, inputDenominator);

            Assert.False(f1.IsNaN);

            Assert.True(f1.HumanRepresentation == expectedOutput);
        }


        [Theory]
        [InlineData(0.25d, "1/4")]
        [InlineData(0.33333d, "1/3")]
        [InlineData(7.75d, "7 3/4")]
        [InlineData(1d, "1")]
        [InlineData(0d, "0")]
        public void DecimalToHumanRepresentationTest(decimal d, string expectedOutput)
        {
            var f1 = new Fractional(d, keepExcat: false);

            Assert.False(f1.IsNaN);

            Assert.True(f1.HumanRepresentation == expectedOutput);
        }
    }
}
