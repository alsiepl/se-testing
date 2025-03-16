using System;
using TheStudent;
using StudentGradeCalculator;

namespace ExaminerNamespace
{
    public class Examiner
    {
        private StudentGradeCalculator1 calculator;

        public Examiner()
        {
            calculator = new StudentGradeCalculator1();
        }

        public void SubmitGrade(Student student)
        {
            if (student == null || student.student_scores.Length == 0)
            {
                Console.WriteLine("No student scores available.");
                return;
            }

            double average = calculator.CalculateAverageScore(student.student_scores);
            string passOrFail = calculator.DeterminePassOrFail(average);
            string grade = calculator.CalculateGrade(average);
            string rank = calculator.GetStudentRank(average);
            int lowestScore = calculator.GetLowestScore(student.student_scores);
            int highestScore = calculator.GetHighestScore(student.student_scores);

            Console.WriteLine("\nExaminer's Evaluation:");
            Console.WriteLine($"Average Score: {average:F2}");
            Console.WriteLine($"Result: {passOrFail}");
            Console.WriteLine($"Final Grade: {grade}");
            Console.WriteLine($"Rank: {rank}");
            Console.WriteLine($"Lowest score: {lowestScore}");
            Console.WriteLine($"Highest score: {highestScore}");
        }
    }
}