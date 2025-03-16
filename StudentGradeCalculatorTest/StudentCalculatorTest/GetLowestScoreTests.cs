using System;
using Xunit;
using StudentGradeCalculator; // Ensure this points to the correct namespace

public class StudentGradeCalculatorTests3
{
    private readonly StudentGradeCalculator1 _calculator;

    // Constructor to initialize the _calculator field
    public StudentGradeCalculatorTests3()
    {
        _calculator = new StudentGradeCalculator1(); // Initialize in the constructor
    }

    // Positive Test Case: Valid scores
    [Fact]
    public void GetLowestScore_ValidScores_ReturnsMinScore()
    {
        // Arrange
        int[] scores = { 50, 60, 70, 30, 90 };

        // Act
        int result = _calculator.GetLowestScore(scores);

        // Assert
        Assert.Equal(30, result);  // Assert that the lowest score is 30
    }

    // Edge Case: All scores are the same
    [Fact]
    public void GetLowestScore_AllSameScores_ReturnsThatScore()
    {
        // Arrange
        int[] scores = { 75, 75, 75, 75 };

        // Act
        int result = _calculator.GetLowestScore(scores);

        // Assert
        Assert.Equal(75, result);  // The lowest should still be 75
    }

    // Edge Case: Min and Max values (0 and 100)
    [Fact]
    public void GetLowestScore_MinMaxValues_ReturnsMinValue()
    {
        // Arrange
        int[] scores = { 0, 100, 100, 0, 50 };

        // Act
        int result = _calculator.GetLowestScore(scores);

        // Assert
        Assert.Equal(0, result);  // The lowest value should be 0
    }

    // Edge Case: Scores already in sorted order (Ascending)
    [Fact]
    public void GetLowestScore_SortedAscending_ReturnsFirstElement()
    {
        // Arrange
        int[] scores = { 10, 20, 30, 40, 50 };

        // Act
        int result = _calculator.GetLowestScore(scores);

        // Assert
        Assert.Equal(10, result);
    }

    // Edge Case: Scores already in sorted order (Descending)
    [Fact]
    public void GetLowestScore_SortedDescending_ReturnsLowest()
    {
        // Arrange
        int[] scores = { 90, 80, 70, 60, 50 };

        // Act
        int result = _calculator.GetLowestScore(scores);

        // Assert
        Assert.Equal(50, result);
    }

    // Edge Case: Unordered scores
    [Fact]
    public void GetLowestScore_UnorderedScores_ReturnsCorrectMinValue()
    {
        // Arrange
        int[] scores = { 60, 10, 80, 90, 20, 30 };

        // Act
        int result = _calculator.GetLowestScore(scores);

        // Assert
        Assert.Equal(10, result);
    }

    // Negative Test Case: Null input
    [Fact]
    public void GetLowestScore_NullScores_ThrowsArgumentException()
    {
        // Arrange
        int[] scores = null!;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.GetLowestScore(scores));
    }

    // Negative Test Case: Empty array
    [Fact]
    public void GetLowestScore_EmptyScores_ThrowsArgumentException()
    {
        // Arrange
        int[] scores = { };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.GetLowestScore(scores));
    }
}