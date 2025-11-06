using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts = new()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What am I most grateful for right now?",
        "What challenge did I overcome today?",
        "What did I learn about myself today?",
        "What made me smile today?",
        "How did I help someone today?"
    };

    private readonly Random _rand = new();
    private int _lastIndex = -1; // Exceeding: avoid immediate repetition

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0) return "Write about anything you like today.";
        if (_prompts.Count == 1) return _prompts[0];

        int index;
        do { index = _rand.Next(_prompts.Count); }
        while (index == _lastIndex);

        _lastIndex = index;
        return _prompts[index];
    }

    // Optional helpers if you want to extend prompts at runtime
    public void AddPrompt(string newPrompt)
    {
        if (!string.IsNullOrWhiteSpace(newPrompt))
            _prompts.Add(newPrompt.Trim());
    }

    public void DisplayAllPrompts()
    {
        Console.WriteLine("\nAvailable prompts:");
        foreach (var p in _prompts) Console.WriteLine($"- {p}");
    }
}
