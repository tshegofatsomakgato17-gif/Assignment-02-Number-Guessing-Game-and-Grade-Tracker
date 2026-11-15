
namespace NumberGuessingGame
{
    public enum GuessResult
    {
        TooLow,
        TooHigh,
        Correct
    }

    public class GameLogic
    {
        public const int MinimumNumber = 1;
        public const int MaximumNumber = 100;
        public const int MaximumAttempts = 5;

        // Generates a random secret number between 1 and 100.
        public static int GenerateSecretNumber()
        {
            return Random.Shared.Next(
                MinimumNumber,
                MaximumNumber + 1
            );
        }

        // Checks whether a guess is within the allowed range.
        public static bool IsValidGuess(int guess)
        {
            return guess >= MinimumNumber &&
                   guess <= MaximumNumber;
        }

        // Compares the player's guess with the secret number.
        public static GuessResult CheckGuess(int guess, int secretNumber)
        {
            if (guess < secretNumber)
            {
                return GuessResult.TooLow;
            }

            if (guess > secretNumber)
            {
                return GuessResult.TooHigh;
            }

            return GuessResult.Correct;
        }

        // Checks whether the player still has attempts remaining.
        public static bool HasAttemptsRemaining(int attemptsUsed)
        {
            return attemptsUsed < MaximumAttempts;
        }
    }
}
