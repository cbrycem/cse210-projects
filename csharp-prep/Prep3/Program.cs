using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator= new Random();
        string response = "a";
        int guess = 0;
        do {   
            int number = randomGenerator.Next(1, 100);
            Console.WriteLine("Thank you for playing this game. \nI have chosen a number between 1 and 100, and you get to guess it! Start guessing!");
            while (guess != number) {
                Console.Write("Guess the Secret Number: ");
                string userInput = Console.ReadLine();
                new string(userInput.Where(c => char.IsDigit(c) || c == '.').ToArray());
                string clean = userInput.Replace("%", "");
                guess = int.Parse(clean);
            
                if (guess > number)
                {
                    Console.WriteLine("Lower");
                } else if (guess < number) {
                    Console.WriteLine("Higher");
                }
            }
            Console.WriteLine("Congratulations, you have guessed the number!");
            Console.Write("Would you like to play again? (y/n)");
            response = Console.ReadLine();
        } while (response == "y");
        //Console.WriteLine("Hello Prep3 World!");
    }
}