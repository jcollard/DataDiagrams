using System;

namespace DataDiagrams
{
    class MainClass
    {

        public static int GetRandomNumber()
        {
            Random numberGenerator = new Random();
            return numberGenerator.Next(0, 100);
        }

        public static int GuessNumber()
        {
            Console.Write("Guess a number: ");
            return Int32.Parse(Console.ReadLine());
        }

        public static void Main(string[] args)
        {
            int numberToGuess = GetRandomNumber();
            int numberOfGuesses = 0;
            int numberGuessed = -1;

            Console.WriteLine("I'm thinking of a number between 0 and 100.");

            while (numberGuessed != numberToGuess)
            {
                numberGuessed = GuessNumber();
                numberOfGuesses = numberOfGuesses + 1;
                if (numberGuessed == numberToGuess)
                {
                    Console.WriteLine("That's correct!");
                }
                else if (numberGuessed < numberToGuess)
                {
                    Console.WriteLine("Your guess is too low.");
                }
                else
                {
                    Console.WriteLine("Your guess is too high.");
                }
            }

            Console.WriteLine($"It took you {numberOfGuesses} guesses to find my number.");

        }
    }


}
