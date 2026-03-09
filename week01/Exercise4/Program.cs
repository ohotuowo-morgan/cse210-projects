using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        Console.Write("Enter a number: ");
        string number = Console.ReadLine();
        int num = int.Parse(number);


        List<int> numList = new List<int>();

        while (num != 0)
        {
            numList.Add(num);
            Console.Write("Enter a number: ");
            number = Console.ReadLine();
            num = int.Parse(number);
        }

        int listSum = 0;

        foreach (int i in numList)
        {
            listSum += i;
        }
        int listLen = numList.Count;
        int maxNum = numList.Max();
        float avg = (float)listSum/listLen;
        Console.WriteLine($"The list is: {string.Join(", ", numList)}");
        Console.WriteLine($"The sum is: {listSum}");
        Console.WriteLine($"The average of the list is: {avg}");
        Console.WriteLine($"The largest number is: {maxNum}");
    }
}