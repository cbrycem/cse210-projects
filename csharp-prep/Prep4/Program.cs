using System;

class Program
{
    
    static void Main(string[] args)
    {
        List<int> num = new List<int>();
        int number;
        int sum = 0;
        Console.WriteLine("Enter a list of numbers. Enter 0 when finished.");
        do {
            Console.Write("Enter Number: ");
            string userInput = Console.ReadLine();
            new string(userInput.Where(c => char.IsDigit(c) || c == '.').ToArray());
            string clean = userInput.Replace("%", "");
            number = int.Parse(clean);
            if (number == 0) {
                break;
            }
            num.Add(number);
        } while (number != 0);

        for (int i = 0; i < num.Count; i++) {
            sum = sum + num[i];
        }
        
        Console.WriteLine("The sum is: " + sum);
        
        float avg = (float)sum / (float)num.Count;
        Console.WriteLine("The average is: " + avg);

        int max = num.Max();
        Console.WriteLine("The largest number is: " + max);

    }
}