using System;
using TheStudent;
using StudentGradeCalculator;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of exams: ");
        int numExams;
        while (!int.TryParse(Console.ReadLine(), out numExams) || numExams <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }

        // Create Student instance and input scores
        Student student = new Student(numExams);
        int[] scores = student.InputScores();

        // Create instance of StudentGradeCalculator1
        var calculator = new StudentGradeCalculator1();

        // Perform calculations
        double average = calculator.CalculateAverageScore(scores);
        string passOrFail = calculator.DeterminePassOrFail(average);
        string grade = calculator.CalculateGrade(average);

        // Display results
        Console.WriteLine($"\nAverage Score: {average:F2}");
        Console.WriteLine($"Result: {passOrFail}");
        Console.WriteLine($"Grade: {grade}");
    }
}
