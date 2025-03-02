using System;

class Breathing : Activities
{
    public Breathing(int time, string name, string description) : base (time, name, description) {
    
    }
    public void StartActivity() {
        OpenMessage();
        GetTime();
        Console.WriteLine("Get ready to start...");
        Spinner();
        _startTime = DateTime.Now;
        _currentTime = _startTime;
        _endTime = _startTime.AddSeconds(_time);
        while (_currentTime < _endTime) {
            BreathIn();
            _currentTime = DateTime.Now;
            if (_currentTime >= _endTime) {
                break;
            }
            _timeLeft = _endTime - _currentTime;
            Console.WriteLine($"{Math.Round(_timeLeft.TotalSeconds)} seconds left");
            Thread.Sleep(1000);
            BreathOut();
            _currentTime = DateTime.Now;
            if (_currentTime >= _endTime) {
                break;
            }
            _timeLeft = _endTime - _currentTime;
            Console.WriteLine($"{Math.Round(_timeLeft.TotalSeconds)} seconds left");
            Thread.Sleep(1000);
        }
        Console.Clear();
        CloseMessage();
        Spinner();
    }
    private void BreathIn() {
        Console.Clear();
        Console.WriteLine("Breath in.");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Breath in..");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Breath in...");
        Thread.Sleep(1000);
    }
    private void BreathOut() {
        Console.Clear();
        Console.WriteLine("Breath out.");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Breath out..");
        Thread.Sleep(1000);
        Console.Clear();
        Console.WriteLine("Breath out...");
        Thread.Sleep(1000);
    }
}