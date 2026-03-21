using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public Entry(string date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public string GetDate() { return _date; }
    public string GetPromptText() { return _promptText; }
    public string GetEntryText() { return _entryText; }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    public string GetSaveFormat()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }
}