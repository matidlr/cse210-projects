using System;

class Program
{
    static void Main(string[] args)
    {
        int sessionsCompleted = 0;

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine();
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.WriteLine();
            Console.WriteLine($"Sessions completed: {sessionsCompleted}");
            Console.WriteLine();

            Console.Write("Select a choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    sessionsCompleted++;
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    sessionsCompleted++;
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    sessionsCompleted++;
                    break;

                case "4":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            if (choice != "4")
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}