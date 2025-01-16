using System;

class Program
{
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName() {
        Console.Write("Please enter your name: ");
        string userInput = Console.ReadLine();
        return userInput;
    }
    static int PromptUserNumber() {
        Console.Write("Please enter your favorite number: ");
        string userInput = Console.ReadLine();
        new string(userInput.Where(c => char.IsDigit(c) || c == '.').ToArray());
        string clean = userInput.Replace("%", "");
        int number = int.Parse(clean);

        return number;
    }
    static int SquareNumber(int number) {
        int square = number * number;
        return square;
    }
    static void DisplayResult(string name, int square) {
        Console.WriteLine(name + ", the square of your number is " + square);
    }

    static void Main() {
        DisplayWelcome();
        string name = PromptUserName();
        int num = PromptUserNumber();
        int square = SquareNumber(num);
        DisplayResult(name, square);
    }
}