using System;

class Program
{
    static void Main(string[] args)
    {
        string letter;
        Console.WriteLine("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        new string(userInput.Where(c => char.IsDigit(c) || c == '.').ToArray());
        string clean = userInput.Replace("%", "");
        float percent = float.Parse(clean);

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}.");

        if (percent >= 70)
        {
            Console.WriteLine($"Congratulations! You passed your class!");
        }
        else
        {
            Console.WriteLine($"You didn't pass your class. But you've got this! You'll get it next time!");
        }

    }
}