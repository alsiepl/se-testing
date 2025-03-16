﻿using System;
using TheStudent;

namespace StudentGradeCalculator
{
    public class StudentGradeCalculator1
    {
        public double CalculateAverageScore(int[] scores)
        {
            if (scores == null || scores.Length == 0)
            {
                throw new ArgumentException("Scores cannot be null or empty.");
            }

            int sum = 0;
            foreach (var score in scores)
            {
                int numericScore;
                // Try to convert the score to an integer. If it fails, throw an exception.
                try
                {
                    numericScore = Convert.ToInt32(score);
                }
                catch (FormatException)
                {
                    throw new FormatException($"Invalid input: {score} is not a valid number.");
                }

                // Check if the score is within the valid range
                if (numericScore < 0 || numericScore > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(score), "Each score must be between 0 and 100.");
                }

                sum += numericScore;
            }

            return (double)sum / scores.Length; // Return the average score
        }

        public string DeterminePassOrFail(double averageScore)
        {
            if (averageScore < 0 || averageScore > 100 || double.IsNaN(averageScore))
            {
                throw new ArgumentOutOfRangeException("Average score must be between 0 and 100.");
            }

            return averageScore >= 60 ? "Pass" : "Fail";
        }


        public string CalculateGrade(double averageScore)
        {
            if (averageScore < 0 || averageScore > 100)
            {
                throw new ArgumentOutOfRangeException("Average score must be between 0 and 100.");
            }

            if (averageScore >= 90) return "12";
            if (averageScore >= 80) return "10";
            if (averageScore >= 70) return "7";
            if (averageScore >= 60) return "4";
            if (averageScore >= 50) return "02";
            return "00";
        }

        public string GetStudentRank(double averageScore)
        {
            if (averageScore < 0 || averageScore > 100)
            {
                throw new ArgumentOutOfRangeException("Average score must be between 0 and 100.");
            }

            if (averageScore >= 90) return "Top Performer!";
            if (averageScore >= 75) return "Above Average";
            if (averageScore >= 60) return "Average";
            return "Needs improvement.";
        }

        public int GetHighestScore(int[] scores)
        {
            if (scores == null || scores.Length == 0)
            {
                throw new ArgumentException("Scores cannot be null or empty.");
            }
            return scores.Max();
        }

        public int GetLowestScore(int[] scores)
        {
            if (scores == null || scores.Length == 0)
            {
                throw new ArgumentException("Scores cannot be null or empty.");
            }
            return scores.Min();
        }

    }
}