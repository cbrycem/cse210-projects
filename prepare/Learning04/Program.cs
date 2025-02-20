using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Chris Miller", "Lagrange Multipliers");
        Console.WriteLine(assignment.GetSummary());

        Math assignment2 = new Math("Winter", "Long Division", "2.7", "9-13");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        Writing assignment3 = new Writing("Jack Frost", "The Pig War", "Cause of The Pig War");
        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}