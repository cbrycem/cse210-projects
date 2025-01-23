using System;

class Entries
{
    public Entries() {
        
    }
    public string _prompt;
    public string _entry;
    public string _date;

    public void Display() {

        Console.WriteLine($"{_date}: {_prompt}: {_entry}");
        
    }
}