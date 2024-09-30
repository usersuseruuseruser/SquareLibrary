using SquareLibrary;
using SquareLibrary.ExceptionMessages;

namespace SquareLibraryTests;

using System;

public class TriangleTests
{
    [Fact]
    public void FindSquareOfTriangle_ValidSides_ReturnsCorrectArea()
    {
        // Arrange
        double a = 3, b = 4, c = 5;
        double expectedArea = 6;
        
        // Act
        double actualArea = SquareFinder.FindSquareOfTriangle(a, b, c);
        
        // Assert
        Assert.Equal(expectedArea, actualArea, 5); 
    }
    
    [Fact]
    public void FindSquareOfTriangle_ValidSides_ReturnsCorrectArea2()
    {
        // Arrange
        double a = 5, b = 10, c = 14;
        double expectedArea = 17.605042;
        
        // Act
        double actualArea = SquareFinder.FindSquareOfTriangle(a, b, c);
        
        // Assert
        Assert.Equal(expectedArea, actualArea, 5); 
    }
    
    [Fact]
    public void FindSquareOfTriangle_ZeroSides_ThrowsArgumentException()
    {
        // Arrange
        double a = 0, b = 4, c = 5;
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => SquareFinder.FindSquareOfTriangle(a, b, c));
        Assert.Equal(TriangleExceptionMessages.SidesMustBePositive, ex.Message);
    }

    [Fact]
    public void FindSquareOfTriangle_OverflowSides_ThrowsArgumentException()
    {
        // Arrange
        double a = 1e154, b = 1e154, c = 1e154;
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => SquareFinder.FindSquareOfTriangle(a, b, c));
        Assert.Equal(ex.Message, TriangleExceptionMessages.SidesAreTooBig);
    }
    
    [Fact]
    public void FindSquareOfTriangle_NegativeSide_ThrowsArgumentException()
    {
        // Arrange
        double a = -3, b = 4, c = 5;

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => SquareFinder.FindSquareOfTriangle(a, b, c));
        Assert.Equal(TriangleExceptionMessages.SidesMustBePositive, ex.Message);
    }

    [Fact]
    public void FindSquareOfTriangle_InvalidSides_ThrowsArgumentException()
    {
        // Arrange
        double a = 1, b = 1, c = 3; 

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => SquareFinder.FindSquareOfTriangle(a, b, c));
        Assert.Equal(TriangleExceptionMessages.TriangleDoesNotExist, ex.Message);
    }
}
