public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are your personal strengths?",
        "What are you greatful for today?",
        "Who has helped you recently?",
        "What is a personal achievement you are proud of?"
    };

    private List<string> _availablePrompts;
    public ListingActivity()
        : base("Listing", "List as many responses as you can.")
    {
        _availablePrompts = new List<string>(_prompts);
    }
    
    private string GetRandomPrompt()
    {
        if (_availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_prompts);
        }

        Random r = new Random();
        int index = r.Next(_availablePrompts.Count);
        string selectedPrompt = _availablePrompts[index];
        _availablePrompts.RemoveAt(index);
        return selectedPrompt;
    }

    private List<string> GetListFromUser(int seconds)
    {
        List<string> answers = new List<string>();
        DateTime end = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            answers.Add(item);
        }
        return answers;
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine("Prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("You may begin listing in:");
        ShowCountdown(5);

        List<string> items = GetListFromUser(GetDuration());
        Console.WriteLine($"\nYou listed {items.Count} items!");

        DisplayEndingMessage();
    }
}