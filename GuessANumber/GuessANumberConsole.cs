using System;

namespace GuessANumber
{
    public class GuessANumberConsole
    {
        // When the player guesses too low, min is updated as the lowest
        // number that the winning number can be.
        private int min;

        // When the player guesses too high, max is updated as the highest
        // number that the winning number can be.
        private int max;

        // Guesses left
        private int guessesLeft;

        // The guess that the player enters
        private int guess;

        Random rand = new Random();

        // When set to true, the player has guessed the number correctly
        bool winCondition;

        // The number that the player has to guess to win the game
        private int winningNumber;

        // Ideally, these shouldn't be hardcoded, so that custom games can
        // be easily made; but for this example, we hardcode.
        private void Init()
        {
            winningNumber = rand.Next(1, 500);
            min = 1;
            max = 500;
            guessesLeft = 12;
            guess = 0;
            winCondition = false;
        }

        // Quick introduction to the game
        private void DoIntro()
        {
            Console.WriteLine("Welcome to Guess a Number! I will think of a number between 1 and 500,\n" +
            "and you will have 12 tries to figure it out! To make things easier, every time you guess\n" +
            "incorrectly, I will tell you if you my number is higher or lower than your guess. I will\n" +
            "also help you by reminding you of the highest number you guessed and the lowest number\n" +
            "you guessed, in order to help you narrow down the solution! \n\nPress any key to begin!\r\n");
            Console.ReadKey();
            Console.WriteLine("\n\n");

        }

        // Body of the game
        public void RunGame()
        {
            // Set up the game
            Init();
            // Do the intro
            DoIntro();
            // Game Loop
            do
            {
                // Get and then evaluate the guess
                GetGuess();
                EvaluateGuess();

            } while (guessesLeft > 0 && !winCondition);

            if (guessesLeft == 0 && !winCondition)
            {
                Console.WriteLine("You ran out of guesses! GAME OVER!");
            }
            Console.ReadKey();

        }
  
        // Determine if the guess equaled the winning number, or was greater than or less than
        private void EvaluateGuess()
        {
            if (guess == winningNumber)
            {
                Console.WriteLine("YOU GUESSED CORRECTLY! It took you " + (12 - guessesLeft) + " tries! Congrats!");
                winCondition = true;
            }
            else if (guess > winningNumber)
            {
                Console.WriteLine("You guessed too high! My number is lower!");
                if (guess < max)
                {
                    max = guess;
                }
            }
            else if (guess < winningNumber)
            {
                Console.WriteLine("You guessed too low! My number is higher!");
                if (guess > min)
                {
                    min = guess;
                }
            }
        }

        private int GetGuess()
        {
            Console.Write("I am thinking of a number from " + min + " to " + max + "! " +
                    "You have " + guessesLeft + " guesses left. Type in your guess!\n");
            string input = Console.ReadLine();
            guessesLeft--;
            // If the guess isn't an integer, re-request the guess until it is
            while (!int.TryParse(input, out guess))
            {
                Console.WriteLine("You must enter an integer as a guess (no decimals)! Try again!");
                input = Console.ReadLine();
            }

            return guess;
        }

        static void Main(string[] args)
        {
            var game = new GuessANumberConsole();
            game.RunGame();

        }

    }
}
