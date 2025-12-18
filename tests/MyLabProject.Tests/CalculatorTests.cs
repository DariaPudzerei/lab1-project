using Xunit;
using MyLabProject.BusinessLogic;

namespace MyLabProject.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;

        public CalculatorTests()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_NegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = -5;
            int b = -3;

            // Act
            int result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(-8, result);
        }

        [Fact]
        public void Subtract_TwoNumbers_ReturnsCorrectDifference()
        {
            // Arrange
            int a = 10;
            int b = 4;

            // Act
            int result = _calculator.Subtract(a, b);

            // Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiply_TwoNumbers_ReturnsCorrectProduct()
        {
            // Arrange
            int a = 6;
            int b = 7;

            // Act
            int result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(42, result);
        }

        [Fact]
        public void Divide_ValidNumbers_ReturnsCorrectQuotient()
        {
            // Arrange
            int a = 15;
            int b = 3;

            // Act
            double result = _calculator.Divide(a, b);

            // Assert
            Assert.Equal(5.0, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            int a = 10;
            int b = 0;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(5, 120)]
        [InlineData(6, 720)]
        public void Factorial_ValidInput_ReturnsCorrectResult(int input, long expected)
        {
            // Act
            long result = _calculator.Factorial(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Factorial_NegativeNumber_ThrowsArgumentException()
        {
            // Arrange
            int n = -5;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.Factorial(n));
        }
    }
}