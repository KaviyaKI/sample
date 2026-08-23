using learningprojectserver;

namespace learningprojectserver.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_TwoNumbers_ReturnsCorrectResult()
    {
        // Arrange
        var calculator = new Calculator();

        // Act
        var result = calculator.Add(10, 20);

        // Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void Subtract_TwoNumbers_ReturnsCorrectResult()
    {
        var calculator = new Calculator();

        var result = calculator.Subtract(20, 10);

        Assert.Equal(10, result);
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsCorrectResult()
    {
        var calculator = new Calculator();

        var result = calculator.Multiply(10, 5);

        Assert.Equal(50, result);
    }
}