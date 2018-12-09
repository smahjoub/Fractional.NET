using Fractional.Extentions;
using System;
using Xunit;

namespace Fractional.Tests
{
    public class StringExtentionsTests
    {
        [Theory]
        [InlineData("7 3/4", true)]
        [InlineData("-7 3/4", true)]
        [InlineData("3/4", false)]
        [InlineData("4", false)]
        public void IsMixedFractionalTheory(string value, bool expected)
        {
            var result = StringExtentions.IsMixedFractional(value);

            Assert.Equal(expected, result);
        }


        [Theory]
        [InlineData("7 3/4", false)]
        [InlineData("-7 3/4", false)]
        [InlineData("3/4", true)]
        [InlineData("4", true)]
        [InlineData("0", true)]
        [InlineData("-4", true)]
        public void IsSimpleractionalTheory(string value, bool expected)
        {
            var result = StringExtentions.IsSimpleFractional(value);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsMixedFractional_InValid_Fractional_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => StringExtentions.IsMixedFractional(null));
        }

        [Fact]
        public void IsSimpleFractional_InValid_Fractional_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => StringExtentions.IsSimpleFractional(null));
        }
    }
}
