using SquareLibrary;
using SquareLibrary.ExceptionMessages;

namespace SquareLibraryTests;

public class CircleTests
{
    [Fact]
    public void FindSquareOfCircle_ValidRadius_ReturnsCorrectArea()
    {
        // Arrange
        double r = 3;
        double expectedArea = Math.PI * r * r;
        
        // Act
        double actualArea = SquareFinder.FindSquareOfCircle(r);
        
        // Assert
        Assert.Equal(expectedArea, actualArea, 5);
    }
    
    [Fact]
    public void FindSquareOfCircle_ValidRadius_ReturnsCorrectArea2()
    {
        // Arrange
        double r = 6.6666;
        double expectedArea = Math.PI * r * r;
        
        // Act
        double actualArea = SquareFinder.FindSquareOfCircle(r);
        
        // Assert
        Assert.Equal(expectedArea, actualArea, 5);
    }

    [Fact]
    public void FindSquareOfCircle_NegativeRadius_ThrowsArgumentException()
    {
        // Arrange
        double r = -5;
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => SquareFinder.FindSquareOfCircle(r));
        Assert.Equal(CircleExceptionMessages.RadiusMustBeGreaterThanZero, ex.Message);
    }

    [Fact]
    public void FindSquareOfCircle_ZeroRadius_ThrowsArgumentException()
    {
        // Arrange
        double r = 0;
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => SquareFinder.FindSquareOfCircle(r));
        Assert.Equal(CircleExceptionMessages.RadiusMustBeGreaterThanZero, ex.Message);
    }

    [Fact]
    public void FindSquareOfCircle_OverflowRadius_ThrowsArgumentException()
    {
        // Arrange
        double r = 1e154; 
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => SquareFinder.FindSquareOfCircle(r));
        Assert.Equal(CircleExceptionMessages.RadiusIsTooBig, ex.Message);
    }
}
