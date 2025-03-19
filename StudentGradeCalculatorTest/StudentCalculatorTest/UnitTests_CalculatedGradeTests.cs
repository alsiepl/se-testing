using StudentGradeCalculator; // Ensure this is pointing to the right namespace

public class StudentGradeCalculatorTests
{
    private readonly StudentGradeCalculator1 _calculator;

    // Constructor to initialize the calculator
    public StudentGradeCalculatorTests()
    {
        _calculator = new StudentGradeCalculator1();
    }

    // Positive Case: Valid scores for high grade
    [Fact]
    public void CalculateGrade_ValidHighScore_ReturnsCorrectGrade()
    {
        // Arrange
        double averageScore = 95.0;

        // Act
        string grade = _calculator.CalculateGrade(averageScore);

        // Assert
        Assert.Equal("12", grade); // Ensures "12" is returned for high scores
    }

    // Positive Case: Valid mid-high score
    [Fact]
    public void CalculateGrade_ValidMidHighScore_ReturnsCorrectGrade()
    {
        // Arrange
        double averageScore = 85.0;

        // Act
        string grade = _calculator.CalculateGrade(averageScore);

        // Assert
        Assert.Equal("10", grade); // Ensures "10" is returned for mid-high scores
    }

    // Positive Case: Valid mid-range score
    [Fact]
    public void CalculateGrade_ValidMidRangeScore_ReturnsCorrectGrade()
    {
        // Arrange
        double averageScore = 75.0;

        // Act
        string grade = _calculator.CalculateGrade(averageScore);

        // Assert
        Assert.Equal("7", grade); // Ensures "7" is returned for mid-range scores
    }

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

    // Positive Case: Valid low pass score
    [Fact]
    public void CalculateGrade_ValidLowPassScore_ReturnsCorrectGrade()
    {
        // Arrange
        double averageScore = 55.0;

        // Act
        string grade = _calculator.CalculateGrade(averageScore);

        // Assert
        Assert.Equal("02", grade); // Ensures "02" is returned for low pass scores
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
    [Fact]
    public void CalculateGrade_Score90_Returns12()
    {
        // Arrange
        double score = 90.0;

        // Act
        string result = _calculator.CalculateGrade(score);

        // Assert
        Assert.Equal("12", result);
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

    // Edge Case: 50.0 should return "02"
    [Fact]
    public void CalculateGrade_Score50_Returns02()
    {
        // Arrange
        double score = 50.0;

        // Act
        string result = _calculator.CalculateGrade(score);

        // Assert
        Assert.Equal("02", result);
    }

    // Edge Case: Non-numeric input ("ABC") should throw an exception
    [Fact]
    public void CalculateGrade_InvalidCharacter_ThrowsException()
    {
        // Arrange
        string invalidScore = "ABC";

        // Act & Assert
        Assert.Throws<FormatException>(() =>
        {
            double parsedScore = double.Parse(invalidScore); // This will throw FormatException
            _calculator.CalculateGrade(parsedScore);
        });
    }
}