using System;

class Resume
{
    public Resume() {
        
    }
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display() {
        Console.WriteLine($"Name: {_name}");

        foreach (Job j in _jobs) {
            j.Display();
        }
    }
}