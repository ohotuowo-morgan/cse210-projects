using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries yet.\n");
            return;
        }
        Console.WriteLine($"Total entries: {_entries.Count}\n");
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry e in _entries)
            {
                writer.WriteLine(e.GetSaveFormat());
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }
        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry e = new Entry(parts[0], parts[1], parts[2]);
                _entries.Add(e);
            }
        }
        Console.WriteLine("Journal loaded successfully!\n");
    }

    public void SearchEntries(string keyword)
    {
        bool found = false;
        foreach (Entry e in _entries)
        {
            if (e.GetEntryText().Contains(keyword) || e.GetPromptText().Contains(keyword))
            {
                e.Display();
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No entries found with that keyword.\n");
        }
    }
}