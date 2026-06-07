using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn from this experience?",
        "What did you learn about yourself?",
        "How can you remember this experience in the future?"
    };

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity helps you reflect on moments of strength and resilience."
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();

        Console.WriteLine(
            $"--- {_prompts[random.Next(_prompts.Count)]} ---"
        );

        Console.WriteLine();
        Console.WriteLine("Reflect on each question:");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            string question = _questions[random.Next(_questions.Count)];

            Console.WriteLine();
            Console.Write($"> {question} ");

            ShowSpinner(5);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}