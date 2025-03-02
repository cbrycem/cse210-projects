using System;

class Reflection : Activities
{
    public Reflection(int time, string name, string description) 
        : base (time, name, description, 
            new List<string> {"Think of a time when you stood up for someone else.", 
                "Think of a time when you did something really difficult.", 
                "Think of a time when you helped someone in need.", 
                "Think of a time when you did something truly selfless."}) {

        _questions = new List<string> {"Why was this experience meaningful to you?", 
            "Have you ever done anything like this before?", 
            "How did you get started?", 
            "How did you feel when it was complete?", 
            "What made this time different than other times when you were not as successful?", 
            "What is your favorite thing about this experience?", 
            "What could you learn from this experience that applies to other situations?", 
            "What did you learn about yourself through this experience?", 
            "How can you keep this experience in mind in the future?"};

    }
    private List<string> _questions;
    private string _question;
    public void StartActivity() {
        OpenMessage();
        GetTime();
        Console.WriteLine("Get ready to start...");
        Spinner();

        Console.Clear();
        Console.WriteLine("Consider the following prompt: ");
        Console.WriteLine();
        Console.WriteLine(_prompts[rnd.Next(_prompts.Count)]);
        Console.WriteLine();
        Console.WriteLine("Press Enter when you're ready to continue");
        Console.ReadLine();
        Console.Clear();

        _startTime = DateTime.Now;
        _currentTime = _startTime;
        _endTime = _startTime.AddSeconds(_time);
        
        while (_currentTime < _endTime) {
            _number = rnd.Next(_questions.Count);
            _question = _questions[_number];
            Console.Write(_question);
            Spinner();
            Console.WriteLine();
            _currentTime = DateTime.Now;
        }
        Console.Clear();
        CloseMessage();
        Spinner();
    }
}