
namespace GradeTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GradeBook? gradeBook = null;
            bool running = true;

            while (running)
            {
                ShowMenu();

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        gradeBook = EnterStudentScores();
                        break;

                    case "2":
                        if (gradeBook == null)
                        {
                            Console.WriteLine("Please enter student scores first.");
                        }
                        else
                        {
                            gradeBook.DisplayStudentResults();
                        }
                        break;

                    case "3":
                        if (gradeBook == null)
                        {
                            Console.WriteLine("Please enter student scores first.");
                        }
                        else
                        {
                            DisplaySummary(gradeBook);
                        }
                        break;

                    case "4":
                        Console.WriteLine("Thank you for using Grade Tracker. Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, 3 or 4.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("          GRADE TRACKER");
            Console.WriteLine("================================");
            Console.WriteLine("1. Enter Student Scores");
            Console.WriteLine("2. Display Student Results");
            Console.WriteLine("3. Display Class Summary");
            Console.WriteLine("4. Quit");
            Console.WriteLine("================================");
        }

        static GradeBook EnterStudentScores()
        {
            int numberOfStudents = GetNumberOfStudents();

            string[] studentNames = new string[numberOfStudents];
            double[] scores = new double[numberOfStudents];

            for (int i = 0; i < numberOfStudents; i++)
            {
                Console.WriteLine($"\nStudent {i + 1}");

                studentNames[i] = GetStudentName();
                scores[i] = GetValidScore();
            }

            Console.WriteLine("\nStudent scores have been saved successfully!");

            return new GradeBook(studentNames, scores);
        }

        static int GetNumberOfStudents()
        {
            while (true)
            {
                Console.Write("How many students do you want to enter? ");

                string? input = Console.ReadLine();

                if (int.TryParse(input, out int number) &&
                    number >= 1 && number <= 50)
                {
                    return number;
                }

                Console.WriteLine("Enter a whole number between 1 and 50.");
            }
        }

        static string GetStudentName()
        {
            while (true)
            {
                Console.Write("Enter student name: ");
                string? name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name.Trim();
                }

                Console.WriteLine("Student name cannot be empty.");
            }
        }

        static double GetValidScore()
        {
            while (true)
            {
                Console.Write("Enter score (0-100): ");
                string? input = Console.ReadLine();

                if (double.TryParse(input, out double score) &&
                    !double.IsNaN(score) &&
                    !double.IsInfinity(score) &&
                    score >= 0 && score <= 100)
                {
                    return score;
                }

                Console.WriteLine("Invalid score. Enter a number between 0 and 100.");
            }
        }

        static void DisplaySummary(GradeBook gradeBook)
        {
            Console.WriteLine("\n========== CLASS SUMMARY ==========");
            Console.WriteLine($"Average score: {gradeBook.CalculateAverage():F2}%");
            Console.WriteLine($"Highest score: {gradeBook.GetHighestScore():F2}%");
            Console.WriteLine($"Lowest score: {gradeBook.GetLowestScore():F2}%");
        }
    }
}
