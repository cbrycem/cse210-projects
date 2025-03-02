using System;

class Listing : Activities
{
    public Listing(int time, string name, string description) 
        : base (time, name, description,
            new List<string> {"Who are people that you appreciate?", 
                "What are personal strengths of yours?", 
                "Who are people that you have helped this week?", 
                "When have you felt the Holy Ghost this month?", 
                "Who are some of your personal heroes?"}) {

    }
    private List<string> _responses = new List<string>();
    private string _response;
    private string _prompt;
    public void StartActivity() {
        OpenMessage();
        GetTime();
        Console.WriteLine("Get ready to start...");
        Spinner();

        Console.Clear();
        _prompt = _prompts[rnd.Next(_prompts.Count)];
        Console.Write(_prompt);
        Spinner();
        Spinner();
        Spinner();

        _startTime = DateTime.Now;
        _currentTime = _startTime;
        _endTime = _startTime.AddSeconds(_time);
        
        while (_currentTime < _endTime) {
            Console.Clear();
            Console.WriteLine(_prompt);
            Console.Write("Response: ");
            _response = Console.ReadLine();
            _responses.Add(_response);
            _currentTime = DateTime.Now;
        }
        Console.Clear();
        DisplayResponses();
        Console.WriteLine();
        CloseMessage();
        _responses.Clear();
        Spinner();
    }
    private void DisplayResponses() {
        Console.Clear();
        for (int i = 0; i < _responses.Count; i++) {
            Console.WriteLine(_responses[i]);
            Thread.Sleep(1000);
        }
    }
}