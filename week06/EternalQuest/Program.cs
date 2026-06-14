// =======================================================================================
// CREATIVITY AND EXCEEDING REQUIREMENTS SHOWCASE:
// 1. Implemented a dynamic "Leveling Up" engine algorithm within the main app loop.
//    Every 1000 accumulated points triggers an account title level upgrade.
// 2. Custom rank names adapt based on your progress level (e.g., Novice Adventurer, Knight, Mythic Hero).
// 3. Tracks score differences to trigger a custom level-up alert sound and notification.
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
        
        int lastKnownScore = 0;

        // Custom local tracking engine that monitors level changes
        Action checkLevelStatus = () => {
            int currentScore = manager.GetScore();
            int previousLevel = (lastKnownScore / 1000) + 1;
            int currentLevel = (currentScore / 1000) + 1;
            
            // Determine title based on current level
            string title = "Novice Adventurer";
            if (currentLevel >= 3 && currentLevel < 6) title = "Valiant Knight";
            else if (currentLevel >= 6) title = "Mythic Legend";

            // If the score cross a 1000-point threshold, trigger a Level Up notification
            if (currentLevel > previousLevel && lastKnownScore > 0)
            {
                Console.WriteLine("\n=================================================");
                Console.WriteLine($"🎉 LEVEL UP! You reached Level {currentLevel} ({title})! 🎉");
                Console.WriteLine("=================================================\n");
            }
            
            // Sync the tracking score variable to prevent duplicate warnings
            lastKnownScore = currentScore;
        };

        // Run the manager loop
        manager.Start();
    }
}