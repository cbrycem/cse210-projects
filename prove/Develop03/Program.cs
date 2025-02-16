//I completed the assignment, and to go above and beyond, I have made it so it loads the scriptures from a file,
//I made it so you can add scriptures to the program, then save those to the file to expand your collection of
//scriptures to memorize, and I made it so that when they are memorizing a scripture, they can choose to have it
//show words again, so if they are struggling, they can make it a little easier and then make it harder again

using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "scriptures.csv";
        int choice = 0;
        int scrip = 1;
        List<Scripture> _scriptures = new List<Scripture>();
        try {
            using (StreamReader reader = new StreamReader(filePath))
            {
                bool firstLine = true;
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (firstLine) // Skip header
                    {
                        firstLine = false;
                        continue;
                    }

                    int firstComma = line.IndexOf(',');

                    if (firstComma != -1)
                    {
                        // Split only at the first comma
                        string reference = line.Substring(0, firstComma).Trim();
                        string verse = line.Substring(firstComma + 1).Trim(); // Rest of the line

                        _scriptures.Add(new Scripture(reference, verse));
                    }

                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        //_scriptures.Add(new Scripture("2 Nephi 2:25", "25 Adam fell that men might be; and men are, that they might have joy."));
        Console.WriteLine("Welcome to your scripture mastery tool!");

        while (choice != 5) {
            scrip = 1;
            Console.WriteLine("");
            Console.WriteLine("Please choose an option below: ");
            Console.WriteLine("1) Add a scripture");
            Console.WriteLine("2) Choose a scripture");
            Console.WriteLine("3) Random scripture");
            Console.WriteLine("4) Update current list with your added scriptures");
            Console.WriteLine("5) Exit the program");
            Console.Write("Choice: ");
            string option = Console.ReadLine();
            Console.WriteLine("");

            try {
                choice = int.Parse(option);
            }
            catch {
                Console.WriteLine("Please enter a number");
            }

            if (choice == 1) {
                Console.Write("Please enter the scripture reference you would like to add (enter 0 to exit): ");
                string refe = Console.ReadLine();
                int exit = 1;
                try {
                    exit = int.Parse(refe);
                }
                catch {}
                if (exit == 0) {
                    return;
                }
                Console.WriteLine("");
                Console.Write("Please enter the verse(s) you would like to add: ");
                string vers = Console.ReadLine();
                _scriptures.Add(new Scripture(refe, vers));
            }
            else if (choice == 2) {
                while (scrip != 0) {
                    int i = 1;
                    Console.WriteLine("Which scripture would you like to memorize? (enter 0 to exit)");
                    foreach (Scripture j in _scriptures) {
                        Console.Write(i + ": ");
                        string _reffull = j.DisplayReference();
                        Console.Write(_reffull);
                        Console.WriteLine("");
                        i++;
                    }
                    Console.WriteLine("");
                    Console.Write("Choice: ");
                    option = Console.ReadLine();
                    Console.WriteLine("");

                    try {
                        scrip = int.Parse(option);
                    }
                    catch {
                        Console.WriteLine("Please enter a number");
                    }
                    if (scrip != 0) {
                        scrip -= 1;
                        try {
                            _scriptures[scrip].Display();
                        } catch {
                            Console.WriteLine("Please enter a number on the list");
                        }
                    }
                    Console.WriteLine("");
                }
            }
            else if (choice == 3) {
                int _length = _scriptures.Count; 
                
                Random rnd = new Random();
                int script = rnd.Next(0, _length);
                _scriptures[script].Display();
            }
            else if (choice == 4) {
                using (StreamWriter writer = new StreamWriter("scriptures.csv")) {
                    writer.WriteLine("Reference,Verse");
                    foreach (Scripture j in _scriptures){
                        string _referencefull = j.DisplayReference();
                        string _fullverse = j.Save();
                        writer.WriteLine($"{_referencefull},{_fullverse}");
                    }
                }
            }
            else if (choice == 5) {
                continue;
            }
            else {
                Console.WriteLine("Please enter a number 1-3.");
            }
        }
    }
}