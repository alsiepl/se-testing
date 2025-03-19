using StudentGradeCalculator; // Ensure this points to the correct namespace

public class StudentGradeCalculatorTests5
{
    private readonly StudentGradeCalculator1 _calculator;

    // Constructor to initialize the _calculator field
    public StudentGradeCalculatorTests5()
    {
        _calculator = new StudentGradeCalculator1(); // Initialize in the constructor
    }

    // Positive Test Case: Valid Ranges

    [Fact]
    public void GetStudentRank_AverageScore90OrAbove_ReturnsTopPerformer()
    {
        // Act & Assert
        Assert.Equal("Top Performer!", _calculator.GetStudentRank(90));
        Assert.Equal("Top Performer!", _calculator.GetStudentRank(95));
        Assert.Equal("Top Performer!", _calculator.GetStudentRank(100));
    }

    // Positive Test Case: Valid Ranges

    [Fact]
    public void GetStudentRank_AverageScoreBetween75And89_ReturnsAboveAverage()
    {
        // Act & Assert
        Assert.Equal("Above Average", _calculator.GetStudentRank(75));
        Assert.Equal("Above Average", _calculator.GetStudentRank(80));
        Assert.Equal("Above Average", _calculator.GetStudentRank(89)); // Edge case
    }

    // Positive Test Case: Valid Ranges

    [Fact]
    public void GetStudentRank_AverageScoreBetween60And74_ReturnsAverage()
    {
        // Act & Assert
        Assert.Equal("Average", _calculator.GetStudentRank(60));
        Assert.Equal("Average", _calculator.GetStudentRank(65));
        Assert.Equal("Average", _calculator.GetStudentRank(74)); // Edge case
    }

    // Positive Test Case: Valid Ranges

    [Fact]
    public void GetStudentRank_AverageScoreBelow60_ReturnsNeedsImprovement()
    {
        // Act & Assert
        Assert.Equal("Needs improvement.", _calculator.GetStudentRank(0));
        Assert.Equal("Needs improvement.", _calculator.GetStudentRank(30));
        Assert.Equal("Needs improvement.", _calculator.GetStudentRank(59)); // Edge case
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

}
