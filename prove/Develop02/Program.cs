using System;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        Journal journal = new Journal();
        Console.WriteLine("Welcome to your Journal!");

        while (choice != 7) {
            Console.WriteLine("");
            Console.WriteLine("Please choose an option below: ");
            Console.WriteLine("1) Make a new entry");
            Console.WriteLine("2) See all entries");
            Console.WriteLine("3) Save your journal to a file");
            Console.WriteLine("4) Load your journal from a file");
            Console.WriteLine("5) Delete current journal");
            Console.WriteLine("6) Add a new prompt");
            Console.WriteLine("7) Exit the program");
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
                journal.WriteEntry();
            }
            else if (choice == 2) {
                journal.Display();
            }
            else if (choice == 3) {
                journal.Save();
            }
            else if (choice == 4) {
                journal.Load();
            }
            else if (choice == 5) {
                journal.Delete();
            }
            else if (choice == 6) {
                Prompts.AddNew();
            }
            else if (choice == 7) {
                continue;
            }
            else {
                Console.WriteLine("Please enter a number 1-7.");
            }
        }
    }
}