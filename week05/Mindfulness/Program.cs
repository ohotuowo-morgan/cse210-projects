using System;

class Program
{
    static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS: 
        // I added a tracking mechanism to keep a log of how many times 
        // the user performs each activity during their session.
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                breathingCount++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                reflectingCount++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                listingCount++;
            }
        }

        // Final farewell displaying the session log (Exceeds Requirements)
        Console.Clear();
        Console.WriteLine("Thank you for using the Mindfulness Program!");
        Console.WriteLine("Here is your activity log for this session:");
        Console.WriteLine($"- Breathing Activities Completed: {breathingCount}");
        Console.WriteLine($"- Reflecting Activities Completed: {reflectingCount}");
        Console.WriteLine($"- Listing Activities Completed: {listingCount}");
        Console.WriteLine("\nHave a wonderful day!");
    }
}