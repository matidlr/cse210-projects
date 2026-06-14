public class SimpleGoal : Goal
{
    private bool _isComplete;

    // Constructor chains parameters directly up to the base constructor
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false; // Sensible default state initialization
    }

    // Overloaded custom constructor used exclusively by the Factory loading pattern
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}