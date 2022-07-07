using Xunit;

namespace Contoso.Payment.UnitTests
{
    class Calculator
    { 
        public int Add(int a, int b) => a + b;
    }

    public class CalculatorTest
    {
        [Fact]
        public void Should_Return_Value_Two()
        {
            //  Arrange
            const int a = 1;
            const int b = 1;
            var calculator = new Calculator();

            //  Act
            int result = calculator.Add(a, b);

            //  Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Should_Not_Return_Value_Two()
        {
            //  Arrange
            const int a = 1;
            const int b = 2;
            var calculator = new Calculator();

            //  Act
            int result = calculator.Add(a, b);

            //  Assert
            Assert.NotEqual(2, result);
        }

        [Theory]
        [InlineData(3,5)]
        [InlineData(2,6)]
        [InlineData(1,1)]
        public void Should_Return_Even_Values(int a, int b)
        {
            //  Arrange
            var calculator = new Calculator();

            //  Act
            int result = calculator.Add(a, b);

            //  Assert
            Assert.Equal(0, result%2);
        }
    }
}