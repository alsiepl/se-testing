using TheStudent;

namespace TheStudentTests
{
    public class StudentTests
    {
        // Test to ensure the constructor correctly initializes the array size
        [Fact]
        public void Constructor_InitializesArrayWithCorrectLength()
        {
            int numExams = 3;
            Student student = new Student(numExams);
            
            Assert.Equal(numExams, student.student_scores.Length);
        }

        // Test to check if valid scores are correctly stored in the array
        [Fact]
        public void InputScores_ValidScores_AreStoredCorrectly()
        {
            int numExams = 3;
            Student student = new Student(numExams);
            
            // Simulating user input via StringReader
            using (StringReader sr = new StringReader("90\n85\n78\n"))
            {
                Console.SetIn(sr);
                student.InputScores();
            }
            
            int[] expectedScores = { 90, 85, 78 };
            Assert.Equal(expectedScores, student.student_scores);
        }

        // Test to ensure invalid inputs are rejected and valid inputs are stored correctly
        [Fact]
        public void InputScores_InvalidThenValidInput_AcceptsValidInput()
        {
            int numExams = 2;
            Student student = new Student(numExams);
            
            // Simulating user input where invalid inputs are entered first
            using (StringReader sr = new StringReader("-10\n105\n50\n75\n"))
            {
                Console.SetIn(sr);
                student.InputScores();
            }
            
            int[] expectedScores = { 50, 75 };
            Assert.Equal(expectedScores, student.student_scores);
        }
    }
}
