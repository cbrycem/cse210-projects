using System;

class Schedule
{
    public Schedule (string day) {
        _day = day;

        meals = new Dictionary<string, Dictionary<Food, int>>()
        {
            { "Breakfast", new Dictionary<Food, int>() },
            { "Lunch", new Dictionary<Food, int>() },
            { "Dinner", new Dictionary<Food, int>() },
            { "Other", new Dictionary<Food, int>() }
        };
    }

    private string _day;
    private Dictionary<string, Dictionary<Food, int>> meals;

    public string Day {
        get {return _day;}
        set {_day = value;}
    }
    public void Clear()
    {
        foreach (var meal in meals.Keys.ToList())
        {
            meals[meal].Clear();
        }
        Console.WriteLine($"All meals for {_day} have been cleared.");
    }
    public void DisplayMeal(string meal)
    {
        if (meals.ContainsKey(meal))
        {
            Console.WriteLine($"{meal} for {_day}:");
            foreach (var food in meals[meal])
            {
                Console.WriteLine($"- {food.Key.Name} x{food.Value}");
            }
        }
        else
        {
            Console.WriteLine("Invalid meal type.");
        }
    }
    public void DisplayDay()
    {
        Console.WriteLine($"Meals for {_day}:");

        foreach (var meal in meals)
        {
            Console.WriteLine($"{meal.Key}:");

            if (meal.Value.Count > 0)
            {
                foreach (var food in meal.Value)
                {
                    Console.WriteLine($"- {food.Key.Name} x{food.Value}");
                }
            }
            else
            {
                Console.WriteLine("No food items added.");
            }
        }
    }
    public void DisplaySummary() {

    }
    public void AddToSchedule(string meal, Food food, int amount)
    {
        if (meals.ContainsKey(meal))
        {
            if (meals[meal].ContainsKey(food))
            {
                meals[meal][food] += amount;
            }
            else
            {
                meals[meal].Add(food, amount);
            }

            Console.WriteLine($"{food.Name} x{amount} has been added to {meal} for {_day}.");
        }
        else
        {
            Console.WriteLine("Invalid meal type. Please use 'Breakfast', 'Lunch', 'Dinner', or 'Other'.");
        }
    }


}