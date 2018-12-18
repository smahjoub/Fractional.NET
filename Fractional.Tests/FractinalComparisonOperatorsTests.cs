using Xunit;

namespace Fractional.Tests
{

    public class FractinalComparisonOperatorsTests
    {
        [Theory]
        [InlineData("4 3/2")]
        [InlineData("1/2")]
        [InlineData("5/2")]
        public void TwoFractionalsAreEqual(string input)
        {
            var f1 = new Fractional(input);
            var f2 = new Fractional(input);

            Assert.False(f1.IsNaN);
            Assert.False(f2.IsNaN);
            Assert.True(f1 == f2);
        }

        [Theory]
        [InlineData("4 3/2", "5 3/2")]
        [InlineData("1/2", "2")]
        [InlineData("5/2", "0")]
        public void TwoFractionalsAreNotEqual(string input1, string input2)
        {
            var f1 = new Fractional(input1);
            var f2 = new Fractional(input2);

            Assert.False(f1.IsNaN);
            Assert.False(f2.IsNaN);
            Assert.True(f1 != f2);
        }

        [Theory]
        [InlineData("5 3/2", "3 3/2")]
        [InlineData("2", "1/2")]
        [InlineData("5/2", "0")]
        public void IsGreaterThan(string input1, string input2)
        {
            var f1 = new Fractional(input1);
            var f2 = new Fractional(input2);

            Assert.False(f1.IsNaN);
            Assert.False(f2.IsNaN);
            Assert.True(f1 > f2);
        }

        [Theory]
        [InlineData("4 3/2", "5 3/2")]
        [InlineData("1/2", "2")]
        [InlineData("0", "5/2")]
        public void IsLowerThan(string input1, string input2)
        {
            var f1 = new Fractional(input1);
            var f2 = new Fractional(input2);

            Assert.False(f1.IsNaN);
            Assert.False(f2.IsNaN);
            Assert.True(f1 < f2);
        }
    }
}
