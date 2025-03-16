using System;

class Eternal : Goals
{
    public Eternal(string name, string description) : base (name, description) {

    }
    public Eternal(string name, string description, string complete, string completionamount) : base (name, description, complete, completionamount) {

    }
    public override string Type() {
        return "Eternal";
    }
    public override void RecordEvent(ref int points) {
        _completionamount++;
        points = points + (int)Math.Round(Math.Sqrt(_completionamount));
    }
    public override void Display() {
        Console.WriteLine($"{_name}: {_description}");
        Console.WriteLine($"Completed: {_completionamount} times");
    }
}