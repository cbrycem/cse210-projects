using System;
using System.Text;
using System.Linq;

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
        Entries entry = new Entries();
        entry._prompt = Prompts.Display();
        entry._entry = Console.ReadLine();
        Console.WriteLine("");
        entry._date = DateTime.Now;
        _entries.Add(entry);
    }
    public void Save() {
        Console.WriteLine("Please enter the file name you would like to save it under: (include .txt at the end)");
        _file = Console.ReadLine();
        char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();

        // Use StringBuilder to efficiently build the sanitized file name
        StringBuilder sanitizedFileName = new StringBuilder();

        // Iterate through each character and add it to the sanitized file name if it's valid
        foreach (char c in _file)
        {
            if (!invalidChars.Contains(c))
            {
                sanitizedFileName.Append(c);
            }
        }

        _file = sanitizedFileName.ToString();

        try
        {
            if (File.Exists(_file))
            {
                Console.WriteLine("The file already exists. Do you want to overwrite it? (y/n)");
                string response = Console.ReadLine();
                if (response.ToLower() != "y")
                {
                    Console.WriteLine("Save operation canceled.");
                    return;
                }
            }


            using (StreamWriter writer = new StreamWriter(_file))
            {
                foreach (Entries j in _entries){

                    writer.WriteLine($"Date: {j._date}");
                    writer.WriteLine($"Prompt: {j._prompt}");
                    writer.WriteLine($"Response: {j._entry}");
                    writer.WriteLine("----------");

                    //Console.WriteLine($"Date: {j._date}");
                    //Console.WriteLine($"Prompt: {j._prompt}");
                    //Console.WriteLine($"Response: {j._entry}");
                    //Console.WriteLine("----------");
                }
            }
            Console.WriteLine("Your input has been saved to " + _file);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }


    }
    public void Load() {
        
    }
}