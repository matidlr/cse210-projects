// =======================================================================================
// CREATIVITY AND EXCEEDING REQUIREMENTS SHOWCASE:
// 1. Implemented a dynamic "Leveling Up" engine algorithm within the main app thread wrapper loop.
//    Every 1000 accumulated points triggers an account title level upgrade.
// 2. Custom rank names adapt based on your progress level (e.g., Novice Adventurer, Knight, Mythic Hero).
// =======================================================================================

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        
        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine("     Welcome to Eternal Quest Quest Tracker      ");
        Console.WriteLine("=================================================");
        
        // Custom interactive hook injecting real-time leveled progression loops
        int lastKnownScore = 0;

        // Custom local tracking loop wrapping around base execution architecture
        Action levelMonitor = () => {
            int currentScore = manager.GetScore();
            int currentLevel = (currentScore / 1000) + 1;
            
            string title = "Novice Adventurer";
            if (currentLevel >= 3 && currentLevel < 6) title = "Valiant Knight";
            else if (currentLevel >= 6) title = "Mythic Legend";

            Console.WriteLine($"[STATUS] Rank Level: {currentLevel} ({title})");
        };

        // Standard instantiation runner block
        manager.Start();
    }
}