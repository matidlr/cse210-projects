using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries { get; set; } = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nYour journal is currently empty.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Exceeds Requirements: Saves the entire list using structured JSON format
    public void SaveToFile(string file)
    {
        try
        {
        
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_entries, options);
            
            File.WriteAllText(file, jsonString);
            Console.WriteLine($"Journal successfully saved to {file}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving: {ex.Message}");
        }
    }

    // Exceeds Requirements: Loads structured JSON data and safely overwrites current memory
    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"Error: The file '{file}' does not exist.");
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(file);
            // Deserializes directly back into our List of Entry objects
            List<Entry> loadedEntries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
            
            if (loadedEntries != null)
            {
                _entries = loadedEntries;
                Console.WriteLine($"Journal successfully loaded from {file}!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading: {ex.Message}");
        }
    }
}