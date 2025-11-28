public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you helped someone in need.",
        "Think of a moment when you overcame a challenge.",
        "Think of a time when you made someone smile.",
        "Think of a moment when you achieved a personal goal.",
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "What made this time different than other times when you were not as successful?",
        "What did you learn from it?",
        "How can you apply this experience in the future?",
        "What is your favorite thing about this experience?",
        "What strengths did you demonstrate?",
    };

    public ReflectingActivity()
        : base("Reflecting", "Reflect on times in your life when you overcame challenges.")
    {
    }

    private string GetRandomPrompt()
    {
        Random r = new Random();
        return _prompts[r.Next(_prompts.Count)];
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine("Press Enter when you are ready to reflect on the questions.");
        Console.ReadLine();

        Console.WriteLine("Now reflect on the following questions:");

        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        int qIndex = 0;

        while (DateTime.Now < end)
        {
            Console.Write($"> {_questions[qIndex]}\n");
            ShowSpinner(4);

            qIndex = (qIndex + 1) % _questions.Count;
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}