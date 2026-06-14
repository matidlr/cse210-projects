using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int GetScore() => _score;

    public void Start()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": keepRunning = false; break;
                default: Console.WriteLine("Invalid selection. Try again."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (typeChoice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            Goal selectedGoal = _goals[index];

            if (selectedGoal.IsComplete())
            {
                Console.WriteLine("This goal is already fully completed!");
                return;
            }

            selectedGoal.RecordEvent();
            int pointsEarned = selectedGoal.GetPoints();
            
            // Handle checklist goals to compute extra bonus values
            if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete())
            {
                pointsEarned += checklist.GetBonus();
                Console.WriteLine($"🎉 Magnificent achievement! You unlocked the completion bonus!");
            }

            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear(); // Flush standard lists before structural re-instantiation
        string[] lines = File.ReadAllLines(filename);
        
        _score = int.Parse(lines[0]);

        // Factory pattern parsing infrastructure logic loops
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] mainParts = line.Split(':');
            string type = mainParts[0];
            string[] dataParts = mainParts[1].Split(',');

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2]), bool.Parse(dataParts[3])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(dataParts[0], dataParts[1], int.Parse(dataParts[2]), int.Parse(dataParts[3]), int.Parse(dataParts[4]), int.Parse(dataParts[5])));
            }
        }
        Console.WriteLine("Goals loaded successfully.");
    }
}