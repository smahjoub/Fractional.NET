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
        public void HumanRepresentationTest(long inputNumerator, long inputDenominator, string expectedOutput)
        {
            var f1 = new Fractional(inputNumerator, inputDenominator);

            Assert.False(f1.IsNaN);

            Assert.True(f1.HumanRepresentation == expectedOutput);
        }
    }
}
