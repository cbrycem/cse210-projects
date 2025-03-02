//To exceed the requirements, I added a log to keep track of how many times each 
//activity was done, and made it so it'll print out at the end when they exit the program

using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        int breath = 0;
        int reflect = 0;
        int list = 0;
        Console.WriteLine("Welcome to your Mindfulness Program!");
        Listing listing = new Listing(0, "Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Breathing breathing = new Breathing(0, "Breathing", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
        Reflection reflection = new Reflection(0, "Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        while (choice != 4) {
            Console.WriteLine("");
            Console.WriteLine("Please choose an activity below: ");
            Console.WriteLine("1) Breathing");
            Console.WriteLine("2) Listing");
            Console.WriteLine("3) Reflection");
            Console.WriteLine("4) Exit the program");
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
                breathing.StartActivity();
                breath++;
            }
            else if (choice == 2) {
                listing.StartActivity();
                list++;
            }
            else if (choice == 3) {
                reflection.StartActivity();
                reflect++;
            }
            else if (choice == 4) {

                Console.WriteLine("Thanks for using the Mindfulness Program today!");
                breathing.Spinner();
                Console.WriteLine("You did the Breathing activity " + breath + " times!");
                reflection.Spinner();
                Console.WriteLine("You did the Reflection activity " + reflect + " times!");
                listing.Spinner();
                Console.WriteLine("You did the Listing activity " + list + " times!");
                breathing.Spinner();

                continue;
            }
            else {
                Console.WriteLine("Please enter a number 1-4.");
            }
        }
    }
}