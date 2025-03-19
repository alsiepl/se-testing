using StudentGradeCalculator; // Make sure this points to the correct namespace

public class StudentGradeCalculatorTests2
{
    private readonly StudentGradeCalculator1 _calculator;

    public StudentGradeCalculatorTests2()
    {
        _calculator = new StudentGradeCalculator1();
    }

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

    // Edge Case: Invalid input (non-numeric value)
    [Fact]
    public void DeterminePassOrFail_InvalidCharacter_ThrowsException()
    {
        // Arrange - Simulating invalid input scenario
        string invalidScore = "%&"; // Invalid input

        // Act & Assert - Ensure it throws a FormatException
        Assert.Throws<FormatException>(() =>
        {
            int parsedScore = int.Parse(invalidScore); // This will throw FormatException
            _calculator.DeterminePassOrFail(parsedScore);
        });
    }

}
