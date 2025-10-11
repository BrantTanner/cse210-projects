using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{

    public List<Entry> _entries = new List<Entry>();


    public void newEntry(Entry entry)
    {

        _entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine();
            Console.WriteLine($"Date: {entry._date}");
            Console.WriteLine($"Prompt: {entry._prompt}");
            Console.WriteLine($"Response: {entry._response}");
        }
    }

    public void Load()
    {
        // Open and display entries from file
        Console.WriteLine("What is the filename?: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = System.IO.File.ReadAllLines(filename);
            _entries.Clear(); // Clear existing entries

            foreach (string line in lines)
            {
                string[] parts = line.Split(",");

                if (parts.Length >= 3)
                {
                    Entry entry = new Entry();
                    entry._date = parts[0];
                    entry._prompt = parts[1];
                    entry._response = parts[2];

                    _entries.Add(entry);
                }
            }

            Console.WriteLine($"Succesfully loaded {_entries.Count} entries from {filename}");
        }

        else
        {
            Console.WriteLine("File not found.");
        }

    }

    public void Save()
    {
        // Save entry to file
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                // Write each entry as a single line
                // Each field separated by commas
                outputFile.WriteLine($"{entry._date},{entry._prompt},{entry._response}");
            }
        }

        Console.WriteLine($"Entries saved to {filename} succesfully");
    }
};

