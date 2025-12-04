public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points) {}

    public override void RecordEvent()
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} ({GetDescription()}) -- This goal subtracts points!";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
    }
}
