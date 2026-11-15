
using Xunit;
using NumberGuessingGame;
using GradeTracker;

namespace Assignment02.Tests
{
    public class UnitTest1
    {
        // NUMBER GUESSING GAME TESTS

        [Fact]
        public void GenerateSecretNumber_ReturnsNumberWithinRange()
        {
            int number = GameLogic.GenerateSecretNumber();

            Assert.InRange(number, 1, 100);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(50, true)]
        [InlineData(100, true)]
        [InlineData(0, false)]
        [InlineData(101, false)]
        public void IsValidGuess_ChecksNumberRange(int guess, bool expected)
        {
            Assert.Equal(expected, GameLogic.IsValidGuess(guess));
        }

        [Fact]
        public void CheckGuess_ReturnsTooLow()
        {
            Assert.Equal(GuessResult.TooLow, GameLogic.CheckGuess(20, 50));
        }

        [Fact]
        public void CheckGuess_ReturnsTooHigh()
        {
            Assert.Equal(GuessResult.TooHigh, GameLogic.CheckGuess(80, 50));
        }

        [Fact]
        public void CheckGuess_ReturnsCorrect()
        {
            Assert.Equal(GuessResult.Correct, GameLogic.CheckGuess(50, 50));
        }

        [Fact]
        public void HasAttemptsRemaining_ReturnsFalseAfterFiveAttempts()
        {
            Assert.False(GameLogic.HasAttemptsRemaining(5));
        }

        [Fact]
        public void HasAttemptsRemaining_ReturnsTrueBeforeFiveAttempts()
        {
            Assert.True(GameLogic.HasAttemptsRemaining(4));
        }

        // GRADE TRACKER TESTS

        [Fact]
        public void CalculateAverage_ReturnsCorrectAverage()
        {
            GradeBook book = new GradeBook(
                new string[] { "John", "Mary", "Peter" },
                new double[] { 80, 70, 90 }
            );

            Assert.Equal(80, book.CalculateAverage());
        }

        [Fact]
        public void GetHighestScore_ReturnsHighestScore()
        {
            GradeBook book = new GradeBook(
                new string[] { "John", "Mary", "Peter" },
                new double[] { 60, 95, 75 }
            );

            Assert.Equal(95, book.GetHighestScore());
        }

        [Fact]
        public void GetLowestScore_ReturnsLowestScore()
        {
            GradeBook book = new GradeBook(
                new string[] { "John", "Mary", "Peter" },
                new double[] { 60, 95, 75 }
            );

            Assert.Equal(60, book.GetLowestScore());
        }

        [Theory]
        [InlineData(85, "A")]
        [InlineData(75, "B")]
        [InlineData(65, "C")]
        [InlineData(55, "D")]
        [InlineData(40, "F")]
        [InlineData(80, "A")]
        [InlineData(50, "D")]
        [InlineData(0, "F")]
        [InlineData(100, "A")]
        public void GetGrade_ReturnsCorrectGrade(double score, string expected)
        {
            Assert.Equal(expected, GradeBook.GetGrade(score));
        }

        [Fact]
        public void GradeBook_RejectsScoreAbove100()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new GradeBook(
                    new string[] { "John" },
                    new double[] { 105 }
                )
            );
        }

        [Fact]
        public void GradeBook_RejectsNegativeScore()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new GradeBook(
                    new string[] { "John" },
                    new double[] { -5 }
                )
            );
        }

        [Fact]
        public void GradeBook_RejectsMismatchedArrays()
        {
            Assert.Throws<ArgumentException>(() =>
                new GradeBook(
                    new string[] { "John", "Mary" },
                    new double[] { 80 }
                )
            );
        }

        [Fact]
        public void GradeBook_RejectsEmptyArrays()
        {
            Assert.Throws<ArgumentException>(() =>
                new GradeBook(
                    new string[] { },
                    new double[] { }
                )
            );
        }
    }
}
