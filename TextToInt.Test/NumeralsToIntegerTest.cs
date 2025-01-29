
namespace TextToInt.Test;

public class NumeralsToIntegerTest
{
    private readonly NumeralsToInteger NumeToInt;
    public NumeralsToIntegerTest()
    {
        Dictionary<string, int> numerals = Program.LoadNumeralsFromJson();
        NumeToInt = new(numerals);
    }

    [Fact]
    public void Convert_SingleNumeral()
    {
        // Arrange
        string input = "five";
        int expected = 5;

        // Act
        int output = NumeToInt.Convert(input);
        // Assert
        Assert.Equal(output, expected);
    }
    [Fact]
    public void Convert_SingeWordMultipleDigits()
    {
        // Arrange
        string input = "twelve";
        int expected = 12;

        // Act
        int output = NumeToInt.Convert(input);
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
        int output = NumeToInt.Convert(input);
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
        int output = NumeToInt.Convert(input);
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
        int output = NumeToInt.Convert(input);
        // Assert
        Assert.Equal(output, expected);
    }
    [Fact]
    public void Convert_RepeatedNumeral()
    {
        // Arrange
        string input = "five five";
        int? expected = null;

        // Act
        int output = NumeToInt.Convert(input);
        // Assert
        Assert.Equal(output, expected);
    }
    [Fact]
    public void Convert_WeirdNumber()
    {

        // Arrange
        string input = "twelve hundred twenty-five";
        int expected = 1225;

        // Act
        int output = NumeToInt.Convert(input);

        // Assert
        Assert.Equal(output, expected);
    }
}