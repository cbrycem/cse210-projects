using System;

class Journal
{
    public Journal() {
        
    }
    public string _file;
    public List<Entries> _entries = new List<Entries>();

    public void Display() {

        foreach (Entries j in _entries) {
            j.Display();
        }
    }
    public void WriteEntry() {
        Console.WriteLine("");
    }
    public void Save() {
        
    }
    public void Load() {
        
    }
}