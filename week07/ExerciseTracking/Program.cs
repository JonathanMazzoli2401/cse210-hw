using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2024, 11, 4), 45, 15.0),
            new Swimming(new DateTime(2024, 11, 5), 25, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
