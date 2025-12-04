/*
EXCEEDING REQUIREMENTS IMPLEMENTED:

1. Added a Level System:
   - The user levels up every 500 points.
   - Displays a celebratory "LEVEL UP" message.

2. Added Streak Gamification:
   - If the user records 3 positive goals in a row, they receive a +50 point streak bonus.

3. Added a New Goal Type: NegativeGoal
   - Negative goals subtract points instead of adding them.
   - Matches BYU-I suggestion of "negative goals" for bad habits.

These enhancements increase motivation, performance feedback, and gamification,
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager gm = new GoalManager();
        gm.Start();
    }
}