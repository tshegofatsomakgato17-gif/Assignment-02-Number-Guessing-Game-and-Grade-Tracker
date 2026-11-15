# Assignment 02 – Number Guessing Game and Grade Tracker

## 1. Project Overview

This solution contains two C# console applications developed for Assignment 02:

- **Number Guessing Game:** A game where the computer generates a random number between 1 and 100. The player has five attempts to guess the correct number.
- **Grade Tracker:** An application that stores student names and scores in arrays and calculates the average, highest and lowest scores. It also assigns a grade to each student.

## 2. Technologies Used

- C#
- .NET 10
- Visual Studio
- xUnit for automated testing
- Git and GitHub for version control

## 3. Project Structure

The solution contains three projects:

- `NumberGuessingGame` – Contains the number guessing game and its game logic.
- `GradeTracker` – Contains the grade management and calculation functionality.
- `Assignment 02.Tests` – Contains automated tests for the application logic.

## 4. Application Features

### Number Guessing Game

- Generates a random number between 1 and 100.
- Allows a maximum of five valid attempts.
- Tells the player whether a guess is too high or too low.
- Checks for invalid input and out-of-range guesses.
- Provides instructions and a repeating menu.
- Displays the correct number when the player loses.

### Grade Tracker

- Accepts student names and scores.
- Stores information using arrays.
- Allows a maximum of 50 students per entry.
- Validates scores between 0 and 100.
- Calculates the class average.
- Displays the highest and lowest scores.
- Assigns individual grades.
- Provides a repeating menu until the user quits.

## 5. Grade Classification

The following grade boundaries were used:

| Score | Grade |
|---|---|
| 80–100 | A |
| 70–79 | B |
| 60–69 | C |
| 50–59 | D |
| 0–49 | F |

These boundaries are project assumptions because specific grade boundaries were not provided.

## 6. Architecture and Design Decisions

The applications use separate classes and methods to keep the code organised and easier to maintain.

- `GameLogic.cs` contains the reusable number guessing game logic.
- `GradeBook.cs` contains the student score storage, calculations and grade classification.
- Each `Program.cs` file handles the console menu and user interaction.
- The test project is separate from the two console applications.

Methods are used to avoid placing all application functionality inside one Main method.

## 7. Testing

Automated tests were created using xUnit.

The tests cover:

- Random number generation and valid number ranges.
- Guess comparisons.
- Remaining game attempts.
- Grade calculations.
- Average, highest and lowest scores.
- Invalid grade book data.

The solution builds successfully with zero build errors.

During automated test execution, 16 of 27 tests passed. The remaining 11 tests could not load the NumberGuessingGame assembly because Windows Application Control blocked the DLL with error `0x800711C7`.

This is documented as an environment-related testing limitation. The blocked tests should not be interpreted as confirmed passing tests.

## 8. Assumptions and Known Limitations

- The game uses numbers from 1 to 100.
- Players have five valid guessing attempts.
- Invalid guesses do not consume an attempt.
- Grade boundaries follow the classification shown above.
- Student records are stored in memory and are not saved to a database or file.
- The Grade Tracker supports up to 50 students per entry.
- Automated testing of the game logic is affected by the Windows Application Control restriction described above.

## 9. How to Run

Open the `Assignment 02` solution in Visual Studio.

Select `NumberGuessingGame` or `GradeTracker` as the startup project and run the selected console application.

The automated tests are available in the `Assignment 02.Tests` project and can be run through Visual Studio Test Explorer.

## 10. Conclusion

This project demonstrates the use of C# methods, classes, arrays, loops, conditional statements, input validation, exception handling, automated testing and version control.