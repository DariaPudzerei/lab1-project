using Xunit;
using MyLabProject.Builders;

namespace MyLabProject.Tests
{
    /// <summary>
    /// Тести для CalculationBuilder (патерн Builder)
    /// </summary>
    public class CalculationBuilderTests
    {
        [Fact]
        public void Builder_CreateSimpleCalculation_Success()
        {
            // Arrange & Act
            var calculation = CalculationBuilder.Create()
                .WithDescription("Test calculation")
                .AddOperation("5 + 3")
                .WithResult(8)
                .Build();

            // Assert
            Assert.NotNull(calculation);
            Assert.Equal("Test calculation", calculation.Description);
            Assert.Single(calculation.Operations);
            Assert.Equal(8, calculation.Result);
        }

        [Fact]
        public void Builder_CreateComplexCalculation_Success()
        {
            // Arrange & Act
            var calculation = CalculationBuilder.Create()
                .WithDescription("Complex calculation")
                .AddOperation("Step 1")
                .AddOperation("Step 2")
                .AddOperation("Step 3")
                .WithResult(100)
                .Build();

            // Assert
            Assert.NotNull(calculation);
            Assert.Equal(3, calculation.Operations.Count);
            Assert.Equal(100, calculation.Result);
        }

        [Fact]
        public void Builder_NoDescription_ThrowsException()
        {
            // Arrange
            var builder = CalculationBuilder.Create()
                .AddOperation("5 + 3");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => builder.Build());
        }

        [Fact]
        public void Builder_EmptyDescription_ThrowsException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() =>
                CalculationBuilder.Create().WithDescription(""));
        }

        [Fact]
        public void Builder_EmptyOperation_ThrowsException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() =>
                CalculationBuilder.Create()
                    .WithDescription("Test")
                    .AddOperation(""));
        }

        [Fact]
        public void Builder_WithoutResult_BuildsSuccessfully()
        {
            // Arrange & Act
            var calculation = CalculationBuilder.Create()
                .WithDescription("Without result")
                .AddOperation("Some operation")
                .Build();

            // Assert
            Assert.NotNull(calculation);
            Assert.Null(calculation.Result);
        }

        [Fact]
        public void Builder_ChainedCalls_WorkCorrectly()
        {
            // Arrange & Act
            var calculation = CalculationBuilder.Create()
                .WithDescription("Chained")
                .AddOperation("Op1")
                .AddOperation("Op2")
                .WithResult(42)
                .Build();

            // Assert
            Assert.Equal("Chained", calculation.Description);
            Assert.Equal(2, calculation.Operations.Count);
            Assert.Equal(42, calculation.Result);
        }
    }
}