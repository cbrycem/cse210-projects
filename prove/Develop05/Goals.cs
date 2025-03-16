using System;

class Goals
{
    public Goals(string name, string description) {
        _name = name;
        _description = description;
        _complete = false;
    }
    public Goals(string name, string description, string complete) {
        _name = name;
        _description = description;
        if (complete == "True") {
            _complete = true;
        } else {
            _complete = false;
        }
    }
    public Goals(string name, string description, string complete, string completionamount) {
        _name = name;
        _description = description;
        _completionamount = int.Parse(completionamount);
        if (complete == "true") {
            _complete = true;
        } else {
            _complete = false;
        }
    }
    protected string _name;
    protected string _description;
    protected bool _complete;
    protected int _completionamount;
    public virtual string Type() {
        return "";
    }
    public string Name() {
        return _name;
    }
    public string Description() {
        return _description;
    }
    public virtual int TotalTimes() {
        return 0;
    }
    public int CompletionAmount() {
        return _completionamount;
    }
    public virtual void Finished() {
        _complete= true;
    }
    public bool IsComplete() {
        return _complete;
    }
    public virtual void RecordEvent(ref int points) {

    }
    public virtual void Display() {
        if (_complete) {
            Console.WriteLine($"[x] {_name}: {_description}");
        } else {
            Console.WriteLine($"[ ] {_name}: {_description}");
        }
    }
}