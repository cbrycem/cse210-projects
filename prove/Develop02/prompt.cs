using System;

static class Prompts
{
    public static List<string> _prompt = new List<string>{
        "How did your day go?",
        ""
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