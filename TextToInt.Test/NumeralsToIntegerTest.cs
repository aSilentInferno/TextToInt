using TextToInt;

namespace TextToInt.Test;
    
public class NumeralsToIntegerTest
{

    [Fact]
    public void Convert_SingleNumeral()
    {
        // Arrange
        string input = "five";
        int expected = 5;
        
        // Act
        int output = NumeralsToInteger.Convert(input);
        // Assert
        Assert.Equal(output, expected);
    }

    [Fact]
    public void Convert_WithHpyhen()
    {
        // Arrange
        string input = "twenty-five";
        int expected = 25;
        
        // Act
        int output = NumeralsToInteger.Convert(input);
        // Assert
        Assert.Equal(output, expected);
    }
    [Fact]
    public void Convet_BiggerNumber()
    {
        // Arrange
        string input = "five hundred twenty-five";
        int expected = 525;

        // Act
        int output = NumeralsToInteger.Convert(input);
        // Assert
        Assert.Equal(output, expected);
    }
    [Fact]
    public void Convert_InvalidNumeral()
    {
        // Arrange
        string input = "meow";
        int? expected = null;

        // Act
        int output = NumeralsToInteger.Convert(input);
        // Assert
        Assert.Equal(output, expected);
    }
   
}