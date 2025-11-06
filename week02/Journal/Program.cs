using System;

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        string choice = "";
        while (choice != "5")
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Save as JSON");
            Console.WriteLine("7. Load from JSON");
            Console.Write("What would you like to do? ");
            choice = (Console.ReadLine() ?? "").Trim();

            if (choice == "1")
            {
                string prompt = prompts.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("Your response: ");
                string text = Console.ReadLine() ?? "";
                string date = DateTime.Now.ToShortDateString();

                Console.Write("Mood (1–5): ");
                int mood = int.TryParse(Console.ReadLine(), out int m) ? Math.Clamp(m, 1, 5) : 3;

                Console.Write("Tags (comma-separated): ");
                string tags = Console.ReadLine() ?? "";

                var entry = new Entry(date, prompt, text)
                {
                    Mood = mood,
                    Tags = tags
                };
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to load (text): ");
                string filename = Console.ReadLine() ?? "";
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to save (text): ");
                string filename = Console.ReadLine() ?? "";
                journal.SaveToFile(filename);
            }
            else if (choice == "6")
            {
                Console.Write("Enter filename to save as JSON: ");
                string filename = Console.ReadLine() ?? "";
                journal.SaveToJson(filename);
            }
            else if (choice == "7")
            {
                Console.Write("Enter filename to load from JSON: ");
                string filename = Console.ReadLine() ?? "";
                journal.LoadFromJson(filename);
            }
            else if (choice != "5")
            {
                Console.WriteLine("Please choose a valid option (1–7).");
            }
        }

        Console.WriteLine("\nThank you for using the Journal Program. Goodbye!");

        // EXCEEDING THE REQUIREMENTS:
        // 1) JSON save/load using System.Text.Json (options 6 & 7)
        // 2) Extra entry fields: Mood (1–5) and Tags (comma-separated)
        // 3) PromptGenerator avoids repeating the same prompt consecutively
    }
}
