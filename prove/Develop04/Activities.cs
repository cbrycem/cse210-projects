using System;

class Activities
{
    public Activities(int time, string name, string description) {
        _time = time;
        _openMessage = "Welcome to the " + name + " activity!";
        _name = name;
        _description = description;
    }
    public Activities(int time, string name, string description, List<string> prompts) {
        _time = time;
        _openMessage = "Welcome to the " + name + " activity!";
        _name = name;
        _description = description;
        _prompts = prompts;
    }
    protected List<string> _prompts;
    protected int _number;
    protected int _time;
    private string _openMessage;
    protected string _name;
    private string _description;
    protected DateTime _startTime;
    protected DateTime _currentTime;
    protected DateTime _endTime;
    protected TimeSpan _timeLeft;
    protected TimeSpan _totalTime;
    protected Random rnd = new Random();

    public void Spinner() {
        Console.Write("-");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Console.Write("\\");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Console.Write("|");
        Thread.Sleep(500);
        Console.Write("\b \b");
        Console.Write("/");
        Thread.Sleep(500);
        Console.Write("\b \b");
    }
    protected void CloseMessage() {
        Console.WriteLine("Great job!");
        Spinner();
        _totalTime = _currentTime - _startTime;
        Console.WriteLine("You have finished the " + _name + " activity in " + Math.Round(_totalTime.TotalSeconds) + " seconds!");
    }
    protected void OpenMessage() {
        Console.Clear();
        Console.WriteLine(_openMessage);
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }
    protected void GetTime() {
        Console.Write("How long (in seconds) would you like to do this activity for? ");
        _time = int.Parse(Console.ReadLine());
    }
}