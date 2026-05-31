using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video(
            "Learn C# in 20 Minutes",
            "Programming Hub",
            1200);

        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very helpful."));
        video1.AddComment(new Comment("Mike", "Thanks for sharing."));

        Video video2 = new Video(
            "Top 10 Soccer Goals",
            "Sports World",
            850);

        video2.AddComment(new Comment("Lucas", "Amazing goals."));
        video2.AddComment(new Comment("Emma", "Goal number 5 was incredible."));
        video2.AddComment(new Comment("David", "Best compilation ever."));

        Video video3 = new Video(
            "How to Cook Pasta",
            "Chef Maria",
            600);

        video3.AddComment(new Comment("Anna", "Looks delicious."));
        video3.AddComment(new Comment("Chris", "I'm trying this tonight."));
        video3.AddComment(new Comment("Laura", "Easy to follow."));

        Video video4 = new Video(
            "The History of Space Exploration",
            "Science Channel",
            1800);

        video4.AddComment(new Comment("Alex", "Very informative."));
        video4.AddComment(new Comment("Sophia", "Loved the visuals."));
        video4.AddComment(new Comment("Tom", "Excellent documentary."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            Console.WriteLine();

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}