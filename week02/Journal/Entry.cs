using System;

public class Entry
{
    // Settable for JSON deserialization
    public string Date { get; set; } = "";
    public string PromptText { get; set; } = "";
    public string EntryText { get; set; } = "";

    // Exceeding fields
    public int Mood { get; set; } = 3;        // 1..5
    public string Tags { get; set; } = "";    // comma-separated

    public Entry() { } // needed for System.Text.Json

    public Entry(string date, string promptText, string entryText)
    {
        Date = date;
        PromptText = promptText;
        EntryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}  |  Mood: {Mood}  |  Tags: {Tags}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine(EntryText);
    }
}
