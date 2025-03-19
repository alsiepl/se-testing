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

    // CALCULATE AVERAGE SCORES 

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
        int[] scores = { };

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

    // DETERMINE PASS OR FAIL

    // Positive Test Case: Valid passing score
    [Fact]
    public void DeterminePassOrFail_ValidPassingScore_ReturnsPass()
    {
        // Arrange
        double averageScore = 70.0;

        // Act
        string result = _calculator.DeterminePassOrFail(averageScore);

        // Assert
        Assert.Equal("Pass", result);  // Assert that the result is "Pass"
    }

    // Positive Test Case: Valid failing score
    [Fact]
    public void DeterminePassOrFail_ValidFailingScore_ReturnsFail()
    {
        // Arrange
        double averageScore = 50.0;

        // Act
        string result = _calculator.DeterminePassOrFail(averageScore);

        // Assert
        Assert.Equal("Fail", result);  // Assert that the result is "Fail"
    }

    // Negative Test Case: Score below 0
    [Fact]
    public void DeterminePassOrFail_ScoreBelowZero_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        double averageScore = -5.0;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.DeterminePassOrFail(averageScore));
    }

    // Negative Test Case: Score above 100
    [Fact]
    public void DeterminePassOrFail_ScoreAbove100_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        double averageScore = 110.0;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.DeterminePassOrFail(averageScore));
    }

    // Edge Case: Exactly at the pass threshold
    [Fact]
    public void DeterminePassOrFail_AtPassThreshold_ReturnsPass()
    {
        // Arrange
        double averageScore = 60.0;

        // Act
        string result = _calculator.DeterminePassOrFail(averageScore);

        // Assert
        Assert.Equal("Pass", result);  // Assert that the result is "Pass"
    }

    // Edge Case: Just below the pass threshold
    [Fact]
    public void DeterminePassOrFail_BelowPassThreshold_ReturnsFail()
    {
        // Arrange
        double averageScore = 59.9;

        // Act
        string result = _calculator.DeterminePassOrFail(averageScore);

        // Assert
        Assert.Equal("Fail", result);  // Assert that the result is "Fail"
    }

    // ASSIGN A LETTER GRADE

    // Positive Case: Valid passing score
    [Fact]
    public void CalculateGrade_ValidPassingScore_ReturnsCorrectGrade()
    {
        // Arrange
        double averageScore = 65.0;

        // Act
        string grade = _calculator.CalculateGrade(averageScore);

        // Assert
        Assert.Equal("4", grade); // Ensures "4" is returned for pass threshold scores
    }

    // Positive Case: Valid failing score
    [Fact]
    public void CalculateGrade_ValidFailingScore_ReturnsCorrectGrade()
    {
        // Arrange
        double averageScore = 45.0;

        // Act
        string grade = _calculator.CalculateGrade(averageScore);

        // Assert
        Assert.Equal("00", grade); // Ensures "00" is returned for failing scores
    }

    // Negative Case: Invalid score below 0
    [Fact]
    public void CalculateGrade_ScoreBelowZero_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        double averageScore = -1.0;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateGrade(averageScore));
    }

    // Negative Case: Invalid score above 100
    [Fact]
    public void CalculateGrade_ScoreAboveHundred_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        double averageScore = 110.0;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateGrade(averageScore));
    }

    // Edge Case: 80.0 should return "10"
    [Fact]
    public void CalculateGrade_Score80_Returns10()
    {
        // Arrange
        double score = 80.0;

        // Act
        string result = _calculator.CalculateGrade(score);

        // Assert
        Assert.Equal("10", result);
    }

    // Edge Case: 70.0 should return "7"
    [Fact]
    public void CalculateGrade_Score70_Returns7()
    {
        // Arrange
        double score = 70.0;

        // Act
        string result = _calculator.CalculateGrade(score);

        // Assert
        Assert.Equal("7", result);
    }

    // Edge Case: 60.0 should return "4"
    [Fact]
    public void CalculateGrade_Score60_Returns4()
    {
        // Arrange
        double score = 60.0;

        // Act
        string result = _calculator.CalculateGrade(score);

        // Assert
        Assert.Equal("4", result);
    }

    // DETERMINE STUDENT RANK

    // Positive Test Case: Valid Ranges

    [Fact]
    public void GetStudentRank_AverageScoreBetween75And89_ReturnsAboveAverage()
    {
        // Act & Assert
        Assert.Equal("Above Average", _calculator.GetStudentRank(75));
        Assert.Equal("Above Average", _calculator.GetStudentRank(80));
        Assert.Equal("Above Average", _calculator.GetStudentRank(89)); // Edge case
    }

    // Negative Test Case: Invalid Input

    [Fact]
    public void GetStudentRank_AverageScoreBelowZero_ThrowsArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.GetStudentRank(-1));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.GetStudentRank(-50));
    }

    // Negative Test Case: Invalid Input

    [Fact]
    public void GetStudentRank_AverageScoreAbove100_ThrowsArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.GetStudentRank(101));
        Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.GetStudentRank(150));
    }

    // IDENTIFY LOWEST SCORE 

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

    // IDENTIFY HIGHEST SCORE

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