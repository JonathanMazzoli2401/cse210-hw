// EXCEEDING REQUIREMENTS:
// 1. Implemented a non-repeating prompt system for ListingActivity so prompts do not repeat 
//    until all have been used at least once.
// 2. Added a new custom activity: AffirmationActivity, which displays rotating affirmations.

using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;

        while (choice != 4)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Listing Activity");
            Console.WriteLine("3. Reflecting Activity");
            Console.WriteLine("4. Affirmation Activity");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option (1-5): ");

            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                BreathingActivity b = new BreathingActivity();
                b.Run();
            }
            else if (choice == 2)
            {
                ListingActivity l = new ListingActivity();
                l.Run();
            }
            else if (choice == 3)
            {
                ReflectingActivity r = new ReflectingActivity();
                r.Run();
            }
            else if (choice == 4)
            {
                AffirmationActivity a = new AffirmationActivity();
                a.Run();
            }
            else if (choice == 5)
            {
                Console.WriteLine("\nGoodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}