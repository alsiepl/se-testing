using System;
using Xunit;
using StudentGradeCalculator; // Ensure this points to the correct namespace

public class StudentGradeCalculatorTests4
{
    private readonly StudentGradeCalculator1 _calculator;

    // Constructor to initialize the _calculator field
    public StudentGradeCalculatorTests4()
    {
        _calculator = new StudentGradeCalculator1(); // Initialize in the constructor
    }

    // Positive Test Case: Valid scores
    [Fact]
    public void GetHighestScore_ValidScores_ReturnsMaxScore()
    {
        // Arrange
        int[] scores = { 50, 60, 70, 30, 90 };

        // Act
        int result = _calculator.GetHighestScore(scores);

        // Assert
        Assert.Equal(90, result);  // Assert that the highest score is 90
    }

    // Edge Case: All scores are the same
    [Fact]
    public void GetHighestScore_AllSameScores_ReturnsThatScore()
    {
        // Arrange
        int[] scores = { 75, 75, 75, 75 };

        // Act
        int result = _calculator.GetHighestScore(scores);

        // Assert
        Assert.Equal(75, result);  // The highest should still be 75
    }

    // Edge Case: Min and Max values (0 and 100)
    [Fact]
    public void GetHighestScore_MinMaxValues_ReturnsMaxValue()
    {
        // Arrange
        int[] scores = { 0, 100, 100, 0, 50 };

        // Act
        int result = _calculator.GetHighestScore(scores);

        // Assert
        Assert.Equal(100, result);  // The highest value should be 100
    }

    // Edge Case: Scores already in sorted order (Ascending)
    [Fact]
    public void GetHighestScore_SortedAscending_ReturnsLastElement()
    {
        // Arrange
        int[] scores = { 10, 20, 30, 40, 50 };

        // Act
        int result = _calculator.GetHighestScore(scores);

        // Assert
        Assert.Equal(50, result);
    }

    // Edge Case: Scores already in sorted order (Descending)
    [Fact]
    public void GetHighestScore_SortedDescending_ReturnsFirstElement()
    {
        // Arrange
        int[] scores = { 90, 80, 70, 60, 50 };

        // Act
        int result = _calculator.GetHighestScore(scores);

        // Assert
        Assert.Equal(90, result);
    }

    // Edge Case: Unordered scores
    [Fact]
    public void GetHighestScore_UnorderedScores_ReturnsCorrectMaxValue()
    {
        // Arrange
        int[] scores = { 60, 10, 80, 90, 20, 30 };

        // Act
        int result = _calculator.GetHighestScore(scores);

        // Assert
        Assert.Equal(90, result);
    }

    // Negative Test Case: Null input
    [Fact]
    public void GetHighestScore_NullScores_ThrowsArgumentException()
    {
        // Arrange
        int[] scores = null!;

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.GetHighestScore(scores));
    }

    // Negative Test Case: Empty array
    [Fact]
    public void GetHighestScore_EmptyScores_ThrowsArgumentException()
    {
        // Arrange
        int[] scores = { };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _calculator.GetHighestScore(scores));
    }

}
