using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Abstraction for Beginners", "CodeWithMorgan", 600);
        video1.AddComment(new Comment("Alice", "Finally, a clear explanation!"));
        video1.AddComment(new Comment("Bob", "I love the bank account example."));
        video1.AddComment(new Comment("Charlie", "Great quality video."));
        videos.Add(video1);

        Video video2 = new Video("Top 10 VS Code Extensions", "TechTips", 450);
        video2.AddComment(new Comment("Dave", "I didn't know about the third one!"));
        video2.AddComment(new Comment("Eve", "Prettier is a lifesaver."));
        video2.AddComment(new Comment("Frank", "Nice list, thanks."));
        videos.Add(video2);

        Video video3 = new Video("Cooking Jollof Rice", "ChefNaija", 1200);
        video3.AddComment(new Comment("Grace", "Smells good through the screen!"));
        video3.AddComment(new Comment("Heidi", "The secret is definitely the stock."));
        video3.AddComment(new Comment("Ivan", "Making this for dinner tonight."));
        videos.Add(video3);

        Console.WriteLine("YOUTUBE VIDEO TRACKING SYSTEM\n");
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}