public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breating", "This activity helps you relax through slow breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        int duration = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in...");
            ShowCountdown(4);
            Console.Write("\nBreathe out...");
            ShowCountdown(6);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}