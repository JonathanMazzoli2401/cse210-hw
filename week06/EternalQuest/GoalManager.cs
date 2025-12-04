using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    private int _level = 1;
    private int _streak = 0;

    public void Start()
    {
        int choice = -1;

        while (choice != 6)
        {
            Console.WriteLine($"\nYou have {_score} points.   Level: {_level}\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");

        Console.Write("Which type would you like to create? ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int pts = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, desc, pts));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, desc, pts));
        }
        else if (type == 3)
        {
            Console.Write("How many times to complete? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus for completing: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
        }
        else
        {
            _goals.Add(new NegativeGoal(name, desc, pts));
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("\nYour Goals:");
        int i = 1;

        foreach (Goal g in _goals)
        {
            Console.WriteLine($"{i}. {g.GetDetailsString()}");
            i++;
        }
    }

    private void RecordEvent()
    {
        Console.WriteLine("\nWhich goal did you accomplish?");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Select the goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        Goal goal = _goals[index];

        goal.RecordEvent();

        int earned = goal.GetPoints();

        
        if (goal is NegativeGoal)
        {
            _score -= Math.Abs(earned);
            _streak = 0;
            Console.WriteLine($"\n⚠ You lost {Math.Abs(earned)} points!");
        }
        else
        {
            _score += earned;
            _streak++;

            
            if (goal is ChecklistGoal cg && cg.IsComplete())
            {
                _score += cg.GetBonus();
                Console.WriteLine($"\n BONUS! You earned {cg.GetBonus()} extra points!");
            }

            
            if (_streak == 3)
            {
                _score += 50;
                Console.WriteLine("\n STREAK BONUS! +50 points! ");
                _streak = 0;
            }

            
            int newLevel = (_score / 500) + 1;
            if (newLevel > _level)
            {
                _level = newLevel;
                Console.WriteLine($"\n LEVEL UP! You are now Level {_level}! ");
            }
        }

        Console.WriteLine("\nEvent recorded!");
    }

    private void SaveGoals()
    {
        using (StreamWriter sw = new StreamWriter("goals.txt"))
        {
            sw.WriteLine(_score);
            sw.WriteLine(_level);

            foreach (Goal g in _goals)
            {
                sw.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("\nGoals saved.");
    }

    private void LoadGoals()
    {
        _goals.Clear();

        string[] lines = File.ReadAllLines("goals.txt");

        _score = int.Parse(lines[0]);
        _level = int.Parse(lines[1]);

        for (int i = 2; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                SimpleGoal g = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (bool.Parse(parts[4])) g.RecordEvent();
                _goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal g = new ChecklistGoal(
                    parts[1], parts[2], int.Parse(parts[3]),
                    int.Parse(parts[4]), int.Parse(parts[5])
                );

                int completed = int.Parse(parts[6]);
                for (int j = 0; j < completed; j++) g.RecordEvent();

                _goals.Add(g);
            }
            else if (type == "NegativeGoal")
            {
                _goals.Add(new NegativeGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
        }

        Console.WriteLine("\nGoals loaded.");
    }
}
