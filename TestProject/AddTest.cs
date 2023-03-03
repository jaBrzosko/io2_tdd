using ClassLibrary;
namespace TestProject
{
    public class AddTest
    {
        private StringCalculator _calculator;
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
        [InlineData("123456789", 123456789)]
        [InlineData("-2", -2)]
        [InlineData("-9999", -9999)]
        public void WhenProvidedOneNumber_ShouldReturnThisNumber(string input, int expected)
        {
            int answer = _calculator.Add(input);
            Assert.Equal(expected, answer);
        }
    }
}