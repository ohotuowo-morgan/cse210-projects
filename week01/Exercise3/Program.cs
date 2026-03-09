using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        Random randomGenerator = new Random();
        int randomNum = randomGenerator.Next(1, 11);

        int count = 0;
        string guess;
        int newGuess = -1;

        while (randomNum != newGuess)
        {
            count += 1;
            Console.Write("What is your guess: ");
            guess = Console.ReadLine();
            newGuess = int.Parse(guess);

            if (newGuess == randomNum)
            {
                Console.WriteLine("Correct");
                Console.WriteLine($"You guessed {count} times");
            }
            else if (newGuess < randomNum)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Lower");
            }
        }

    }
}