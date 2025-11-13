using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(w => new Word(w))
                        .ToList();
    }

    public string GetDisplayText()
        => $"{_reference.GetDisplayText()} — " +
            string.Join(" ", _words.Select(w => w.GetDisplayText()));

    public void HideRandomWords(int count, bool avoidRehiding)
    {
        var candidates = avoidRehiding
            ? _words.Where(w => !w.IsHidden()).ToList()
            :_words.ToList();

        if (candidates.Count == 0) return;

        for (int i = 0; i < count; i++)
        {
            var pick = candidates[_random.Next(candidates.Count)];
            pick.Hide();

            if (avoidRehiding)
            {
                candidates.Remove(pick);
                if (candidates.Count == 0) break;
            }
        }
    }

    public bool AllWordsHidden() => _words.All(w => w.IsHidden());
}