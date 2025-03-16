using System;
using TheStudent;
using StudentGradeCalculator;
using ExaminerNamespace;

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
        
        // Create Examiner instance
        Examiner examiner = new Examiner();
        
        // Examiner submits and evaluates the grade
        examiner.SubmitGrade(student);
    }
}
