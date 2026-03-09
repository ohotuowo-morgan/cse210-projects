using System;

class Program
{
    static void Main(string[] args)
    {
        // static void Mainn(string PromptUserName(); int PromptUserNumber(); int SquareFavNumber();)
        // {
        //     DisplayWelcome();

        //     Console.WriteLine($"{userName} the square of your number {newNum} is {sqrNum}");
        // }

        DisplayWelcome();

        string name = PromptUserName();

        int favNum = PromptUserNumber();

        int sqr = SquareFavNumber(favNum);

        DisplayResult(name, favNum, sqr);

    }

    static void DisplayResult(string name, int favNum, int sqr)
    {
        Console.WriteLine($"{name}, the square of your Favourite number {favNum} is {sqr}");
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string favNum = Console.ReadLine();
        int newNum = int.Parse(favNum);
        return newNum;
    }

    static int SquareFavNumber(int newNum)
    {
        int sqrNum = newNum * newNum;
        return sqrNum;
    }
}