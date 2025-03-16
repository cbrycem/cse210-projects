using System;

class Basic : Goals
{
    public Basic(string name, string description) : base (name, description) {

    }
    public Basic(string name, string description, string complete) : base (name, description, complete) {

    }
    public override string Type() {
        return "Basic";
    }
    public override void RecordEvent(ref int points) {
        
        if (_complete) {

        } else {
            base.Finished();
            points++;
        }
    }
    public override void Display() {
        base.Display();
    }

}