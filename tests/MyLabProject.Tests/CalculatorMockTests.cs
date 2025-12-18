using Xunit;
using Moq;
using MyLabProject.BusinessLogic;
using Serilog;

namespace MyLabProject.Tests
{
    /// <summary>
    /// Mock тести для демонстрації використання Moq бібліотеки
    /// </summary>
    public class CalculatorMockTests
    {
        [Fact]
        public void Calculator_WithMockedLogger_WorksCorrectly()
        {
            // Arrange - створюємо mock об'єкт логера
            var mockLogger = new Mock<ILogger>();
            var calculator = new Calculator();

            // Act
            int result = calculator.Add(10, 20);

            // Assert
            Assert.Equal(30, result);
            // Mock демонструє що ми можемо тестувати без реального логера
        }

        [Fact]
        public void Add_MultipleOperations_VerifyBehavior()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result1 = calculator.Add(1, 2);
            var result2 = calculator.Add(3, 4);
            var result3 = calculator.Add(5, 6);

            // Assert - перевіряємо послідовність операцій
            Assert.Equal(3, result1);
            Assert.Equal(7, result2);
            Assert.Equal(11, result3);
        }

        [Theory]
        [InlineData(100, 50, 150)]
        [InlineData(-10, -20, -30)]
        [InlineData(0, 0, 0)]
        public void Add_VariousScenarios_ReturnsExpectedResults(int a, int b, int expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Divide_ValidOperation_LogsCorrectly()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Divide(100, 4);

            // Assert
            Assert.Equal(25.0, result);
            // У реальних логах буде записано операцію
        }

        [Fact]
        public void Multiply_LargeNumbers_HandlesCorrectly()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Multiply(1000, 1000);

            // Assert
            Assert.Equal(1000000, result);
        }

        [Fact]
        public void Factorial_EdgeCase_Zero_ReturnsOne()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Factorial(0);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void Factorial_LargeNumber_CalculatesCorrectly()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Factorial(10);

            // Assert
            Assert.Equal(3628800, result);
        }

        [Fact]
        public void Subtract_NegativeResult_WorksCorrectly()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Subtract(5, 10);

            // Assert
            Assert.Equal(-5, result);
        }
    }
}