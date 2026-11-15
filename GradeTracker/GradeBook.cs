
namespace GradeTracker
{
    public class GradeBook
    {
        private readonly string[] studentNames;
        private readonly double[] scores;

        public GradeBook(string[] studentNames, double[] scores)
        {
            if (studentNames == null || scores == null)
            {
                throw new ArgumentNullException("Names and scores cannot be null.");
            }

            if (studentNames.Length == 0 || studentNames.Length != scores.Length)
            {
                throw new ArgumentException("Student names and scores must have the same number of entries, and cannot be empty.");
            }

            foreach (double score in scores)
            {
                if (score < 0 || score > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(scores), "Scores must be between 0 and 100.");
                }
            }

            this.studentNames = (string[])studentNames.Clone();
            this.scores = (double[])scores.Clone();
        }

        public string[] GetStudentNames()
        {
            return (string[])studentNames.Clone();
        }

        public double[] GetScores()
        {
            return (double[])scores.Clone();
        }

        public double CalculateAverage()
        {
            double total = 0;

            foreach (double score in scores)
            {
                total += score;
            }

            return total / scores.Length;
        }

        public double GetHighestScore()
        {
            double highest = scores[0];

            foreach (double score in scores)
            {
                if (score > highest)
                {
                    highest = score;
                }
            }

            return highest;
        }

        public double GetLowestScore()
        {
            double lowest = scores[0];

            foreach (double score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }

            return lowest;
        }

        public static string GetGrade(double score)
        {
            if (score < 0 || score > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(score));
            }

            if (score >= 80)
                return "A";
            else if (score >= 70)
                return "B";
            else if (score >= 60)
                return "C";
            else if (score >= 50)
                return "D";
            else
                return "F";
        }

        public void DisplayStudentResults()
        {
            Console.WriteLine("\n========== STUDENT RESULTS ==========");

            for (int i = 0; i < studentNames.Length; i++)
            {
                Console.WriteLine(
                    $"{studentNames[i]} | Score: {scores[i]:F2}% | Grade: {GetGrade(scores[i])}"
                );
            }
        }
    }
}
