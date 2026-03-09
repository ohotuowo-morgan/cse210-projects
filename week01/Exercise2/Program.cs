using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.Write("What is your grade(0-100%): ");
        string score = Console.ReadLine();
        int newScore = int.Parse(score);

        string letter;
        string sign;

        if (newScore >= 90) 
        {
            letter = "A";
        }
        else if ( newScore >= 80)
        {
            letter = "B";
        }
        else if (newScore >= 70)
        {
            letter = "C";
        }
        else if (newScore >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if(newScore >= 97 || newScore < 60)
        {
            sign = "";
        }
        else if (newScore % 10 >= 7)
        {
            sign = "+";
        }
        else if (newScore % 10 <= 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letter}{sign}");

        if (newScore >= 70) 
        {
            Console.WriteLine("Congratulaions!! You passed the course");
        }
        else
        {
            Console.WriteLine("You Failed the course try harder next semester, you can do it!");
        }
    }
}