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
        Dictionary<string, Nutrition> nutrientMap = new Dictionary<string, Nutrition>();

        foreach (var meal in meals["Breakfast"].Concat(meals["Lunch"]).Concat(meals["Dinner"]).Concat(meals["Other"]))
        {
            Food food = meal.Key;
            double amountMultiplier = meal.Value;

            foreach (var nutrient in food.Nutrients)
            {
                string key = nutrient.Name;
                double scaledAmount = nutrient.Amount * amountMultiplier;
                double scaledPercentage = nutrient.Percentage * amountMultiplier;

                if (nutrientMap.ContainsKey(key))
                {
                    nutrientMap[key].Amount += scaledAmount;
                    nutrientMap[key].Percentage += scaledPercentage;
                }
                else
                {
                    nutrientMap[key] = new Nutrition(key, scaledAmount, nutrient.Units, scaledPercentage);
                }
            }
        }

        Console.WriteLine("=== Day Nutrition Summary ===");
        foreach (var nutrient in nutrientMap.Values)
        {
            nutrient.DisplayInfo();
        }
    }

    public void AddToSchedule(string meal, Food food, int amount)
    {
        var mealKey = meals.Keys.FirstOrDefault(k => k.Equals(meal, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrEmpty(mealKey))
        {
            if (meals[mealKey].ContainsKey(food))
            {
                meals[mealKey][food] += amount;
            }
            else
            {
                meals[mealKey].Add(food, amount);
            }

            Console.WriteLine($"{food.Name} x{amount} has been added to {meal} for {_day}.");
        }
        else
        {
            Console.WriteLine("Invalid meal type. Please use 'Breakfast', 'Lunch', 'Dinner', or 'Other'.");
        }
    }

    public void ClearSchedule()
    {
        // Clear all meals
        foreach (var mealCategory in meals.Values)
        {
            mealCategory.Clear();
        }
        Console.WriteLine($"{_day} schedule has been cleared.");
    }


}