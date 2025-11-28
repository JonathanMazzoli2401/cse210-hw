public class AffirmationActivity : Activity
{
    private List<string> _affirmations = new List<string>()
    {
        "You are capable of amazing things.",
        "You are stronger than you think.",
        "You are improving every day.",
        "You are worthy of good things.",
        "You bring value to the world.",
        "Your efforts are making a difference."
    };

    public AffirmationActivity()
        : base("Affirmation", "This activity helps you build positive self-affirmations.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random r = new Random();
        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.WriteLine("\n" + _affirmations[r.Next(_affirmations.Count)]);
            ShowSpinner(3);
        }

        DisplayEndingMessage();
    }
}