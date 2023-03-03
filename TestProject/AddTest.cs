using ClassLibrary;
namespace TestProject
{
    public class AddTest
    {
        private readonly StringCalculator _calculator;
        public AddTest()
        {
            _calculator = new StringCalculator();
        }

        [Fact]
        public void WhenEmptyStringProvided_ShouldReturnZero()
        {
            int answer = _calculator.Add("");
            Assert.Equal(0, answer);
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("2", 2)]
        [InlineData("10", 10)]
        [InlineData("123456789", 0)]
        [InlineData("9999", 0)]
        public void WhenProvidedOneNumber_ShouldReturnThisNumber(string input, int expected)
        {
            int answer = _calculator.Add(input);
            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("2,3", 5)]
        [InlineData("0,0", 0)]
        [InlineData("12,34", 46)]
        [InlineData("100,0", 100)]
        [InlineData("10,10", 20)]
        public void WhenTwoNumbersSeparatedByCommaProvided_ShouldReturnTheirSum(string input, int expected)
        {
            int answer = _calculator.Add(input);
            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("2\n3", 5)]
        [InlineData("0\n0", 0)]
        [InlineData("12\n34", 46)]
        [InlineData("100\n0", 100)]
        [InlineData("0\n10", 10)]
        [InlineData("12\n3", 15)]
        [InlineData("100\n465", 565)]
        public void WhenTwoNumbersSeparatedByNewlineProvided_ShouldReturnTheirSum(string input, int expected)
        {
            int answer = _calculator.Add(input);
            Assert.Equal(expected, answer);
        }

        [Theory]
        [InlineData("0,1,2", 3)]
        [InlineData("0\n1\n2", 3)]
        [InlineData("0\n1,2", 3)]
        [InlineData("0,1\n2", 3)]
        [InlineData("10,2,4", 16)]
        public void WhenThreeNumbersSeparatedByAnySeparator_ShouldReturnSumOfThreeNumber(string input, int expected)
        {
            int answer = _calculator.Add(input);
            Assert.Equal(expected, answer);
        }
        [Theory]
        [InlineData("-1")]
        [InlineData("-2")]
        [InlineData("-10")]
        [InlineData("-1,1")]
        [InlineData("-2\n5")]
        [InlineData("-10\n5,14")]
        public void NegativeNumbers_ShouldThrowException(string input)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add(input));
        }

        [Theory]
        [InlineData("1,1001", 1)]
        [InlineData("1\n1001", 1)]
        [InlineData("1,1000", 1001)]
        [InlineData("1\n1000", 1001)]
        [InlineData("1\n1001,1000", 1001)]
        [InlineData("2000\n1007,999", 999)]
        [InlineData("2000\n1005\n0", 0)]
        public void NumberGreaterThan100_ShouldBeIngored(string input, int expected)
        {
            int answer = _calculator.Add(input);
            Assert.Equal(answer, expected);
        }
    }
}