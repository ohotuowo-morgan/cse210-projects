// W02 Journal Program
// Demonstrates abstraction through Entry and Journal classes.
//
// Exceeds Requirements:
// - Added search feature (option 6) to search entries by keyword
// - Entries are saved and loaded using | as separator for reliability

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?",
            "What challenged me today and how did I handle it?",
            "What did I learn today?",
            "How did I show kindness to someone today?",
            "What would I do differently if I could repeat today?",
            "What made me smile today?"
        };

        Random random = new Random();
        bool running = true;

        while (running)
        {
            Console.WriteLine("=== Journal Menu ===");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Search entries by keyword");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = prompts[random.Next(prompts.Count)];
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                Entry entry = new Entry(date, prompt, response);
                journal.AddEntry(entry);
                Console.WriteLine("Entry added!\n");
            }
            else if (choice == "2")
            {
                Console.WriteLine();
                journal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save to: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load from: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                running = false;
                Console.WriteLine("Goodbye!");
            }
            else if (choice == "6")
            {
                Console.Write("Enter keyword to search: ");
                string keyword = Console.ReadLine();
                journal.SearchEntries(keyword);
            }
            else
            {
                Console.WriteLine("Invalid option, try again.\n");
            }
        }
    }
}