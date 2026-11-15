
namespace NumberGuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                ShowMenu();

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PlayGame();
                        break;

                    case "2":
                        ShowInstructions();
                        break;

                    case "3":
                        Console.WriteLine("Thank you for playing. Goodbye!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2 or 3.");
                        break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n================================");
            Console.WriteLine("       NUMBER GUESSING GAME");
            Console.WriteLine("================================");
            Console.WriteLine("1. Play Game");
            Console.WriteLine("2. Instructions");
            Console.WriteLine("3. Quit");
            Console.WriteLine("================================");
        }

        static void ShowInstructions()
        {
            Console.WriteLine("\nINSTRUCTIONS");
            Console.WriteLine("The computer will generate a random number between 1 and 100.");
            Console.WriteLine("You have 5 attempts to guess the correct number.");
            Console.WriteLine("The game will tell you whether your guess is too high or too low.");
            Console.WriteLine("Invalid guesses do not use up an attempt.");
        }

        static void PlayGame()
        {
            int secretNumber = GameLogic.GenerateSecretNumber();
            int attemptsUsed = 0;
            bool won = false;

            Console.WriteLine("\nI have selected a number between 1 and 100.");
            Console.WriteLine($"You have {GameLogic.MaximumAttempts} attempts to guess it!");

            while (GameLogic.HasAttemptsRemaining(attemptsUsed) && !won)
            {
                Console.Write($"\nAttempt {attemptsUsed + 1}: Enter your guess: ");
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                    continue;
                }

                if (!GameLogic.IsValidGuess(guess))
                {
                    Console.WriteLine("Your guess must be between 1 and 100.");
                    continue;
                }

                attemptsUsed++;

                GuessResult result = GameLogic.CheckGuess(guess, secretNumber);

                switch (result)
                {
                    case GuessResult.TooLow:
                        Console.WriteLine("Too low! Try a higher number.");
                        break;

                    case GuessResult.TooHigh:
                        Console.WriteLine("Too high! Try a lower number.");
                        break;

                    case GuessResult.Correct:
                        Console.WriteLine("Congratulations! You guessed the correct number!");
                        Console.WriteLine($"You used {attemptsUsed} attempt(s).");
                        won = true;
                        break;
                }
            }

            if (!won)
            {
                Console.WriteLine("\nSorry! You have used all your attempts.");
                Console.WriteLine($"The correct number was {secretNumber}.");
            }
        }
    }
}
