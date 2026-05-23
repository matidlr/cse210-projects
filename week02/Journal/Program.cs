using System;
using System.Collections.Generic;

// CREATIVITY & EXCEEDING REQUIREMENTS REPORT:
// Advanced Data Storage (JSON): Instead of using fragile text separators like '|' 
//    or '~', this program implements robust JSON serialization via `System.Text.Json`. 
//    This prevents application crashes or parsing bugs if a user inputs commas, 
//    quotes, or line breaks into their journal entry content.

class Program
{
    private static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is something new you learned or realized today?",
        "Describe a small victory or moment of peace you experienced in the last 24 hours."
    };

    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        Random random = new Random();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (running)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Load the journal from a file");
            Console.WriteLine("4. Save the journal to a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
    
                    int index = random.Next(_prompts.Count);
                    string prompt = _prompts[index];
                    
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    
                    string dateText = DateTime.Now.ToShortDateString();
                    
                    Entry newEntry = new Entry(dateText, prompt, response);
                    myJournal.AddEntry(newEntry);
                    break;

                case "2":
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    myJournal.LoadFromFile(loadFile);
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option, please choose a number from 1 to 5.");
                    break;
            }
        }
    }
}