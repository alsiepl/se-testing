using System;
using Xunit;
using StudentGradeCalculator; // Ensure this points to the correct namespace

public class StudentGradeCalculatorTests1
{
    private readonly StudentGradeCalculator1 _calculator;

    // Constructor to initialize the _calculator field
    public StudentGradeCalculatorTests1()
    {
        _calculator = new StudentGradeCalculator1(); // Initialize in the constructor
    }

    // Positive Test Case: Valid scores
    [Fact]
    public void CalculateAverageScore_ValidScores_ReturnsCorrectAverage()
    {
        // Arrange
        int[] scores = { 50, 60, 70 };

        // Act
        double result = _calculator.CalculateAverageScore(scores);

        // Assert
        Assert.Equal(60.0, result);  // Assert that the result is 60.0
    }

    // Negative Test Case: Null input
    [Fact]
    public void CalculateAverageScore_NullScores_ThrowsArgumentException()
    {
        // Arrange
        int[] scores = null!;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.CalculateAverageScore(scores));
    }

    // Negative Test Case: Empty array
    [Fact]
    public void CalculateAverageScore_EmptyScores_ThrowsArgumentException()
    {
        // Arrange
        int[] scores = {};

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.CalculateAverageScore(scores));
    }

    // Negative Test Case: Scores outside the valid range (greater than 100)
    [Fact]
    public void CalculateAverageScore_ScoreAbove100_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        int[] scores = { 110, 90, 80 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateAverageScore(scores));
    }

    // Negative Test Case: Scores outside the valid range (negative scores)
    [Fact]
    public void CalculateAverageScore_NegativeScore_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        int[] scores = { -10, 50, 60 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateAverageScore(scores));
    }

    // Edge Case: Min and Max values (0 and 100)
    [Fact]
    public void CalculateAverageScore_MinMaxValues_ReturnsCorrectAverage()
    {
        // Arrange
        int[] scores = { 0, 100, 100, 0 };

        // Act
        double result = _calculator.CalculateAverageScore(scores);

        // Assert
        Assert.Equal(50.0, result);  // Assert that the result is 50.0
    }

    // Edge Case: All scores are maximum (100)
    [Fact]
    public void CalculateAverageScore_AllMaxScores_ReturnsMaxAverage()
    {
        // Arrange
        int[] scores = { 100, 100, 100 };

        // Act
        double result = _calculator.CalculateAverageScore(scores);

        // Assert
        Assert.Equal(100.0, result);  // Assert that the result is 100.0
    }

    // Edge Case: Invalid characters in scores (non-numeric values)
[Fact]
public void CalculateAverageScore_InvalidInput_ThrowsException()
{
    // Arrange - Simulating invalid input scenario
    object[] invalidScores = { "x", "#", "&!", 100 }; // Invalid mix of types

    // Act & Assert - Ensure it throws an ArgumentException or FormatException
    Assert.Throws<FormatException>(() =>
    {
        int[] parsedScores = Array.ConvertAll(invalidScores, item => Convert.ToInt32(item));
        _calculator.CalculateAverageScore(parsedScores);
    });
}
}
