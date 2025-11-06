using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private const string Sep = "~|~"; // simple text format separator (allowed by core spec)

    public void AddEntry(Entry newEntry) => _entries.Add(newEntry);

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\n(No entries yet.)");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry e in _entries)
        {
            e.Display();
            Console.WriteLine();
        }
    }

    // ----- Core text I/O (kept for assignment compatibility) -----

    public void SaveToFile(string file)
    {
        using var sw = new StreamWriter(file);
        foreach (Entry e in _entries)
        {
            // Persist mood and tags too (still using the simple separator)
            sw.WriteLine($"{e.Date}{Sep}{e.PromptText}{Sep}{e.EntryText}{Sep}{e.Mood}{Sep}{e.Tags}");
        }
        Console.WriteLine($"Saved {_entries.Count} entries to '{file}'.");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' not found.");
            return;
        }

        _entries.Clear();
        foreach (var line in File.ReadAllLines(file))
        {
            var parts = line.Split(Sep);
            // Backwards-compatible: if older files had only 3 parts
            string date   = parts.Length > 0 ? parts[0] : "";
            string prompt = parts.Length > 1 ? parts[1] : "";
            string text   = parts.Length > 2 ? parts[2] : "";
            int mood      = (parts.Length > 3 && int.TryParse(parts[3], out int m)) ? m : 3;
            string tags   = parts.Length > 4 ? parts[4] : "";

            _entries.Add(new Entry(date, prompt, text) { Mood = mood, Tags = tags });
        }
        Console.WriteLine($"Loaded {_entries.Count} entries from '{file}'.");
    }

    // ----- Exceeding: JSON I/O -----

    public void SaveToJson(string file)
    {
        var json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(file, json);
        Console.WriteLine($"Saved {_entries.Count} entries to JSON file '{file}'.");
    }

    public void LoadFromJson(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine($"File '{file}' not found.");
            return;
        }

        string json = File.ReadAllText(file);

        // Empty file? Just load an empty list.
        if (string.IsNullOrWhiteSpace(json))
        {
            _entries = new List<Entry>();
            Console.WriteLine($"Loaded 0 entries from JSON '{file}'. (File was empty.)");
            return;
        }

        // Quick sanity check: does it look like JSON?
        string first = json.TrimStart();
        if (!(first.StartsWith("[") || first.StartsWith("{")))
        {
            Console.WriteLine(
                $"The file '{file}' does not look like JSON.\n" +
                $"Tip: If this is a text-format journal (uses ~|~), load it with option 3 (Load text).");
            return;
        }

        try
        {
            var opts = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
                AllowTrailingCommas = true,
                WriteIndented = false
            };

            var list = JsonSerializer.Deserialize<List<Entry>>(json, opts) ?? new List<Entry>();
            _entries = list;
            Console.WriteLine($"Loaded {_entries.Count} entries from JSON file '{file}'.");
        }
        catch (JsonException ex)
        {
            Console.WriteLine(
                "JSON parse error while loading your journal:\n" +
                $"  {ex.Message}\n" +
                "Tips:\n" +
                "  • Make sure the file was saved with option 6 (Save as JSON).\n" +
                "  • Ensure the JSON is an array like: [ { ... }, { ... } ]\n" +
                "  • Remove trailing commas or comments if present.\n");
        }
    }
}
