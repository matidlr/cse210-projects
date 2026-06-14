using System;

public abstract class Goal
{
    // Encapsulation: Protected fields so derived classes can access their own metadata
    protected string _shortName;
    protected string _description;
    protected int _points; // Stored as integer for scoring operations

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Polymorphism: Abstract methods that MUST be overridden by concrete classes
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    
    // Polymorphism: Virtual methods with default behavior that can be overridden if needed
    public virtual string GetDetailsString()
    {
        string statusSymbol = IsComplete() ? "X" : " ";
        return $"[{statusSymbol}] {_shortName} ({_description})";
    }

    public abstract string GetStringRepresentation();

    // Getters for GoalManager orchestration
    public int GetPoints() => _points;
    public string GetShortName() => _shortName;
}