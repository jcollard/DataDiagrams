using System;

namespace DataDiagrams
{
    class MainClass
    {

        public static int GetRandomNumber()
        {
            Random numberGenerator = new Random();
            int randomNumber = numberGenerator.Next(0, 100);
            return randomNumber;
        }

        public static char GetRandomCharacter()
        {
            Random numberGenerator = new Random();
            int randomNumber = numberGenerator.Next(65, 90);
            char randomChar = (char)randomNumber;
            return randomChar;
        }

        public static int GuessNumber()
        {
            Console.Write("Guess a number: ");
            int guess = Int32.Parse(Console.ReadLine());
            return guess;
        }

        public static char GuessChar()
        {
            Console.Write("Guess a character: ");
            string userInput = Console.ReadLine().Trim().ToUpper();
            if (userInput.Length == 1)
            {
                return userInput[0];
            }
            Console.WriteLine("Invalid input!");
            return GuessChar();
        }

        public static void NumberGuessingGame()
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

        public static void CharacterGuessingGame()
        {
            char charToGuess = GetRandomCharacter();
            int numberOfGuesses = 0;
            char charGuessed = ' ';

            Console.WriteLine("I'm thinking of a character between 'A' and 'Z'.");

            while (charGuessed != charToGuess)
            {
                charGuessed = GuessChar();
                numberOfGuesses = numberOfGuesses + 1;
                if (charGuessed == charToGuess)
                {
                    Console.WriteLine("That's correct!");
                }
                else if (charGuessed < charToGuess)
                {
                    Console.WriteLine($"My character comes after '{charGuessed}'.");
                }
                else
                {
                    Console.WriteLine($"My character comes before '{charGuessed}'.");
                }
            }

            Console.WriteLine($"It took you {numberOfGuesses} guesses to find my character.");

        }

        public static void Main(string[] args)
        {
            //CharacterGuessingGame();
            ByteWriter bw = new ByteWriter("/Users/jcollard/git/ap-compsci-2021-2022/project_ideas/DataDiagrams/project/DataDiagrams/DataDiagrams/testfile.5211");
            bw.WriteByte("Test");
        }
    }


}
