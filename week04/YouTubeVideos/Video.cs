using System;
using System.Collections.Generic;
public class Video
{
    private string  _title;
    private string _author;
    private int _length;

    List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }
    
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");

        foreach(Comment comment in _comments)
        {
            // Comment comment1 = new Comment("Morgan", "This Video was helpful");
            // comment1.DisplayComment;
            Console.WriteLine($"{comment.DisplayComment()}");

        }
        Console.WriteLine();
    }
}