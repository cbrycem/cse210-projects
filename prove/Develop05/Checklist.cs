using System;

class Checklist : Goals
{
    public Checklist(string name, string description, int totaltimes) : base (name, description) {
        _totaltimes = totaltimes;
    }
    public Checklist(string name, string description, string complete, string completionamount, string totaltime) : base (name, description, complete, completionamount) {
        _totaltimes = int.Parse(totaltime);
    }
    private int _totaltimes;
    public override string Type() {
        return "Checklist";
    }
    public override int TotalTimes() {
        return _totaltimes;
    }
    public override void RecordEvent(ref int points) {
        if (_complete) {

        } else {
            _completionamount++;
            if (_completionamount/_totaltimes == 1) {
                base.Finished();
                points = points + 10;
            } else {
                points++;
            }
        }
    }
    public override void Display() {
        base.Display();
        if (_complete) {
        } 
        else {
            Console.WriteLine($"Completed: {_completionamount}/{_totaltimes}");
        }
    }
}