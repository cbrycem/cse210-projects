using System;

class Prompts
{
    public Prompts() {
        
    }
    public List<string> _prompt = new List<string>();

    public void AddNew() {

        Console.Write("Enter a new prompt you would like to use in the future: ");
        
    }
    public void Display() {

        Console.WriteLine($"{_prompt}");
    }
}