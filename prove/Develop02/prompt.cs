using System;

static class Prompts
{
    public static List<string> _prompt = new List<string>{
        "How did your day go?",
        "What did you do today?",
        "What did you eat today?",
        "What did you learn in the scriptures today?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public static void AddNew() {

        Console.Write("Enter a new prompt you would like to use in the future: ");
        _prompt.Add(Console.ReadLine());
        
    }
    public static string Display() {
        Random random = new Random();
        int index = random.Next(_prompt.Count);

        // 4. Get the random element from the list
        string prompt = _prompt[index];
        Console.WriteLine($"{prompt}");

        return prompt;

    }
}