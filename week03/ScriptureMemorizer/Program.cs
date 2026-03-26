using System;

// W03 Project: Scripture Memorizer Program
//
// Exceeds Requirements:
// - Added logic in Scripture.HideRandomWords to only select from words that are NOT already hidden.
// - This prevents the program from "wasting" turns by trying to hide underscores, 
//   ensuring a smoother user experience where new words disappear every time.

class Program
{
    static void Main(string[] args)
    {
        // 1. Initialize the Reference and Scripture
        // You can change these values to any scripture you like
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding";
        
        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        // 2. Main Program Loop
        // The loop continues until the user types 'quit' OR all words are hidden
        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            // Clear the console for the "disappearing" effect
            Console.Clear();
            
            // Display the current state of the scripture (Reference + Words/Underscores)
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit:");
            userInput = Console.ReadLine();

            // If the user didn't quit, hide 3 more random words
            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        // 3. Final Display
        // Shows the scripture one last time (fully hidden) before the program exits
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Good luck with your memorization!");
    }
}