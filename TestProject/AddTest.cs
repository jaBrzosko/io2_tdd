using ClassLibrary;
namespace TestProject
{
    public class AddTest
    {
        [Fact]
        public void WhenEmptyStringProvided_ShouldReturnZero()
        {
            StringCalculator calculator = new StringCalculator();
            int answer = calculator.Add("");
            Assert.Equal(0, answer);
        }
    }
}