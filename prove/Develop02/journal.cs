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
        Console.WriteLine("Are you sure you want to load a journal? It will overwrite your current one (y/n)");
        string response = Console.ReadLine();
        if (response.ToLower() != "y")
        {
            Console.WriteLine("Load operation canceled.");
            return;
        }
        _entries.Clear();
        Console.WriteLine("What is the file name? (include .txt, and no spaces)");
        _file = Console.ReadLine();
        try 
        {
            using (StreamReader reader = new StreamReader(_file))
            {
                string line1, line2, line3, line4;
                DateTime _time;

                while ((line1 = reader.ReadLine()) != null &&
                    (line2 = reader.ReadLine()) != null &&
                    (line3 = reader.ReadLine()) != null &&
                    (line4 = reader.ReadLine()) != null)
                {
                    Entries entry = new Entries();
                    line1 = line1.Replace("Date: ", "");
                    _time = DateTime.Parse(line1);
                    entry._date = _time;


                    line2 = line2.Replace("Prompt: ", "");
                    entry._prompt = line2;

                    line3 = line3.Replace("Response: ", "");
                    entry._entry = line3;
                    _entries.Add(entry);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has occurred: " + ex.Message);
        }
    }

    public void Delete() {
        Console.WriteLine("Are you sure you want to delete your journal? (y/n)");
        string response = Console.ReadLine();
        if (response.ToLower() != "y")
        {
            Console.WriteLine("Delete operation canceled.");
            return;
        }
        _entries.Clear();
    }
}