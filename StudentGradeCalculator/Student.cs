namespace TheStudent
{
    
    public class Student
    {
        public int[] student_scores;
        public int numExams;

        public Student(int numExams)
        {
            this.numExams = numExams;
            student_scores = new int[numExams];
        }

        public int[] InputScores()
        {
            for (int i = 0; i < numExams; i++)
            {
                int score;
                while (true)
                {
                    Console.Write($"Enter score for exam {i + 1} (0-100): ");
                    if (int.TryParse(Console.ReadLine(), out score) && score >= 0 && score <= 100)
                    {
                        student_scores[i] = score;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
                    }
                }
            }
            return student_scores;
        }
    }
}

