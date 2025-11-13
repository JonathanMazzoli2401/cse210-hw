using System;

class Program
{
    //Exceeding Requirements:
    //The program avoids re-hiding already hidden words by using the 'avoidRehiding' flag
    //and selecting only visible words in the HideRandomWords method.
    //The program includes a small scripture library and randomly selects a verse each run,
    //giving the user varied memorization practice.
    static void Main()
    {
        bool avoidRehiding = true;
        var scriptures = new (Reference Ref, string Text)[]
        {
            (new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, " +
            "that whosoever believeth in him should not perish, but have everlasting life."),
            (new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
            "In all thy ways acknowledge him, and he shall direct thy paths.")
        };

        var random = new Random();
        var pick = scriptures[random.Next(scriptures.Length)];
        var scripture = new Scripture(pick.Ref, pick.Text);

        int hidePerStep = 3;
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");

            string input = Console.ReadLine() ?? "";
            if (input.Trim().Equals("quit", StringComparison.OrdinalIgnoreCase))
                break;

            scripture.HideRandomWords(hidePerStep, avoidRehiding);

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\n(All words are hidden. Program ending.)");
                break;
            }
        }
    }
}