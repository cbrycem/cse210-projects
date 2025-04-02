using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static Food FoodSelect(List<Food> _allFood) {
        string option = Console.ReadLine();
        
        if (option == "0") {
            return null;
        }
        
        var matchingFoods = _allFood
            .Where(f => f.Name.Contains(option, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (matchingFoods.Count == 0)
        {
            Console.WriteLine("No matching food items found. Please check the name and try again.");
            return null;
        }
        else
        {
            Console.WriteLine("Matching food items:");
            // Display matching foods with an index for selection
            for (int i = 0; i < matchingFoods.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {matchingFoods[i].Name}");
            }

            // Ask user to select a food item by number
            Console.Write("Please select a food item by number: ");
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > matchingFoods.Count)
            {
                Console.Write("Invalid selection. Please enter a number between 1 and " + matchingFoods.Count + ": ");
            }

            // Get the selected food item
            Food foodSelect = matchingFoods[selection - 1];

            return foodSelect;
        }
    }
    static void Main(string[] args)
    {
        int choice = 0;
        int mark = 0;
        int cancel = 0;
        List<Food> _allFood =  new List<Food>();
        List<Food> _madeFood = new List<Food>();
        List<Schedule> schedule = new List<Schedule> 
        {
            new Schedule("Monday"),
            new Schedule("Tuesday"),
            new Schedule("Wednesday"),
            new Schedule("Thursday"),
            new Schedule("Friday"),
            new Schedule("Saturday"),
            new Schedule("Sunday"),
        };
        Console.WriteLine("Welcome to your Food Schedule and Tracker App!");
        while (choice != 4) {
            Console.WriteLine("");
            Console.WriteLine("Please choose an option below: ");
            Console.WriteLine("1) Add Food, update food, add to schedule"); //Add: New food, to schedule, update food info
            Console.WriteLine("2) View Schedule, Nutrition, Ingredients, Food");//View: Schedule, Nutrition, Ingredients, Shopping List, Foods saved
            Console.WriteLine("3) Save or Load File");
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
                Console.WriteLine("");
                Console.WriteLine("What are you wanting to add/update?");
                Console.WriteLine("1) New Food");
                Console.WriteLine("2) Update Food Info/Nutrition");
                Console.WriteLine("3) Add to schedule");
                Console.Write("Choice: ");
                option = Console.ReadLine();
                
                try {
                    mark = int.Parse(option);
                }
                catch {
                    Console.WriteLine();
                }

                if (mark == 1) {

                    Console.WriteLine("");
                    Console.WriteLine("What kind of food are you adding/creating?");
                    Console.WriteLine("1) Base Food");
                    Console.WriteLine("2) Made Food");
                    Console.WriteLine("3) Baking Ingredient");
                    Console.WriteLine("Any other number/character to Cancel");
                    Console.Write("Choice: ");
                    option = Console.ReadLine();
                    
                    try {
                        mark = int.Parse(option);
                    }
                    catch {
                        Console.WriteLine();
                    }

                    if (mark == 1) {
                        Base_Food baseFood = new Base_Food();
                        Console.WriteLine("Please enter the following data:");
                        Console.Write("Name: ");
                        baseFood.Name = Console.ReadLine();
                        Console.Write("Brand: ");
                        baseFood.Brand = Console.ReadLine();
                        Console.Write("Food Group: ");
                        baseFood.FoodGroup = Console.ReadLine();
                        Console.Write("Stock: ");
                        baseFood.Stock = int.Parse(Console.ReadLine());
                        Console.Write("Units: ");
                        baseFood.Units = Console.ReadLine();
                        _allFood.Add(baseFood);
                    }
                    else if (mark == 2) {
                        Made_Food madeFood = new Made_Food();
                        Console.WriteLine("Please enter the following data:");
                        Console.Write("Name: ");
                        madeFood.Name = Console.ReadLine();
                        while (true) {
                            Console.Write("What Ingredient do you want to add?");
                            Food ingredient = FoodSelect(_allFood);
                            if (ingredient != null) {
                                Console.Write("Amount of this ingredient to use?");
                                string amount = Console.ReadLine();
                                int intamount;
                                try {
                                    intamount = int.Parse(amount);
                                }
                                catch {
                                    Console.WriteLine("Please enter a number");
                                    continue;
                                }
                                Console.Write("Units of amount?");
                                string units = Console.ReadLine();
                                madeFood.AddIngredient(ingredient, intamount, units);
                            }
                            else {
                                break;
                            }
                        }
                        _allFood.Add(madeFood);
                        _madeFood.Add(madeFood);
                        Console.WriteLine($"Perfect! You have now added {madeFood.Name} to your food list option!");
                    }
                    else if (mark == 3) {
                        Baking baking = new Baking();
                        Console.WriteLine("Please enter the following data:");
                        Console.Write("Name: ");
                        baking.Name = Console.ReadLine();
                        Console.Write("Brand: ");
                        baking.Brand = Console.ReadLine();
                        Console.Write("Food Group: ");
                        baking.FoodGroup = Console.ReadLine();
                        Console.Write("Stock: ");
                        baking.Stock = int.Parse(Console.ReadLine());
                        Console.Write("Units: ");
                        baking.Units = Console.ReadLine();
                        _allFood.Add(baking);
                    }
                }
                else if (mark == 2) {
                    Console.WriteLine("");
                    Console.Write("Please enter the food name you want to update (enter 0 to cancel): ");
                    Food update = FoodSelect(_allFood);

                    if (update != null) {
                        Console.WriteLine($"Updating food: {update.Name}");
                        Console.WriteLine("Now you will enter the nutrients data (for one serving). Do it one item at a time, and it will keep going until you cancel/stop it");
                        cancel = 0;
                    
                        while (cancel != 1) {
                            Console.WriteLine("");
                            Console.WriteLine("Please enter the following info (or enter 1 instead of the name to cancel/exit)");
                            Console.Write("Nutrition Info Name (ex: Calories, carbs, etc): ");
                            string infoName = Console.ReadLine();
                            if (infoName == "1") {
                                cancel = 1;
                                break;
                            }
                            else if (string.IsNullOrWhiteSpace(infoName)) {
                                Console.WriteLine("Nutrition info name cannot be empty. Please try again.");
                                continue; // Skip to the next iteration of the loop
                            }
                            Console.Write("Amount: ");
                            int amount;
                            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0) 
                            {
                                Console.Write("Please enter a valid positive integer for amount: ");
                            }
                            Console.Write("Units: ");
                            string units = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(units)) 
                            {
                                Console.WriteLine("Units cannot be empty. Start again.");
                                continue; // Skip to the next iteration of the loop
                            }
                            Console.Write("Daily Value Percentage: ");
                            int percent;
                            while (!int.TryParse(Console.ReadLine(), out percent) || percent < 0 || percent > 100) 
                            {
                                Console.Write("Please enter a valid percentage (0-100) (if unknown, type 0): ");
                            }
                            update.Nutrients.Add(new Nutrition(infoName, amount, units, percent));
                        }
                    } 
                    else {
                        Console.WriteLine("No food selected or operation was canceled.");
                    }
                }
                else if (mark == 3) {
                    Console.WriteLine("");
                    Console.WriteLine("What day are you adding this to? (Ex: Sunday, Monday, etc)");
                    string day = Console.ReadLine();
                    Console.WriteLine("What meal? (Ex: Breakfast, Lunch, Dinner, Other)");
                    string meal = Console.ReadLine();
                    Console.Write("What food are you adding?");
                    Food selectedFood = FoodSelect(_allFood);
                        
                    if (selectedFood != null) {
                        Schedule scheduleForDay = schedule.FirstOrDefault(s => s.Day.Equals(day, StringComparison.OrdinalIgnoreCase));

                        if (scheduleForDay == null) {
                            Console.WriteLine($"Food not added. No schedule entry for {day}.");
                        }
                        else {

                            int amount;
                            Console.Write("Amount to add: ");
                            while (!int.TryParse(Console.ReadLine(), out amount) || amount < 0) 
                            {
                                Console.Write("Please enter a valid positive integer for amount: ");
                            }


                            scheduleForDay.AddToSchedule(meal, selectedFood, amount);
                            Console.WriteLine($"{selectedFood.Name} added to {meal} on {day}.");
                        }
                    }
                    else {
                        Console.WriteLine("No food selected or operation was canceled.");
                    }

                }
            }
            else if (choice == 2) {
                Console.WriteLine(""); //Schedule, Nutrition, Ingredients, Shopping List, Foods saved
                Console.WriteLine("What are you wanting to view?");
                Console.WriteLine("1) Schedule");
                Console.WriteLine("2) Nutrition of a food item");
                Console.WriteLine("3) Ingredients of a Food");
                Console.WriteLine("4) Foods saved");
                //Console.WriteLine("5) Shopping list");
                Console.Write("Choice: ");
                option = Console.ReadLine();
                
                try {
                    mark = int.Parse(option);
                }
                catch {
                    Console.WriteLine();
                }

                if (mark == 1) {
                    Console.WriteLine("");
                    Console.WriteLine("What Schedule would you like to view?");
                    Console.WriteLine("1) This week");
                    Console.WriteLine("2) A day this week");
                    Console.WriteLine("3) A meal today");
                    Console.WriteLine("Any other number/character to Cancel");
                    Console.Write("Choice: ");
                    option = Console.ReadLine();
                    
                    try {
                        mark = int.Parse(option);
                    }
                    catch {
                        Console.WriteLine();
                    }

                    if (mark == 1) {
                        foreach (Schedule s in schedule) {
                            s.DisplayDay();
                            Console.WriteLine("");
                        }
                    }
                    else if (mark == 2) {
                        Console.WriteLine("What day would you like to view?");
                        Console.WriteLine("1) Today");
                        Console.WriteLine("2) Monday");
                        Console.WriteLine("3) Tuesday");
                        Console.WriteLine("4) Wednesday");
                        Console.WriteLine("5) Thursday");
                        Console.WriteLine("6) Friday");
                        Console.WriteLine("7) Saturday");
                        Console.WriteLine("8) Sunday");
                        string day = Console.ReadLine();

                        try {
                            mark = int.Parse(day);
                        }
                        catch {
                            Console.WriteLine();
                        }

                        if (mark == 1) {
                            DayOfWeek today = DateTime.Now.DayOfWeek;
                            if (String.Equals(today.ToString(), "monday", StringComparison.OrdinalIgnoreCase)) {
                                schedule[0].DisplayDay();
                            }
                            else if (String.Equals(today.ToString(), "tuesday", StringComparison.OrdinalIgnoreCase)) {
                                schedule[1].DisplayDay();
                            }
                            else if (String.Equals(today.ToString(), "wednesday", StringComparison.OrdinalIgnoreCase)) {
                                schedule[2].DisplayDay();
                            }
                            else if (String.Equals(today.ToString(), "thursday", StringComparison.OrdinalIgnoreCase)) {
                                schedule[3].DisplayDay();
                            }
                            else if (String.Equals(today.ToString(), "friday", StringComparison.OrdinalIgnoreCase)) {
                                schedule[4].DisplayDay();
                            }
                            else if (String.Equals(today.ToString(), "saturday", StringComparison.OrdinalIgnoreCase)) {
                                schedule[5].DisplayDay();
                            }
                            else if (String.Equals(today.ToString(), "sunday", StringComparison.OrdinalIgnoreCase)) {
                                schedule[6].DisplayDay();
                            }
                            else {
                                continue;
                            }

                        }
                        else if (mark == 2) {
                            schedule[0].DisplayDay();
                        }
                        else if (mark == 3) {
                            schedule[1].DisplayDay();
                        }
                        else if (mark == 4) {
                            schedule[2].DisplayDay();
                        }
                        else if (mark == 5) {
                            schedule[3].DisplayDay();
                        }
                        else if (mark == 6) {
                            schedule[4].DisplayDay();
                        }
                        else if (mark == 7) {
                            schedule[5].DisplayDay();
                        }
                        else if (mark == 8) {
                            schedule[6].DisplayDay();
                        }
                        else {
                            Console.WriteLine("Please enter a number between 1 and 8");
                        }
                    }
                    else if (mark == 3) {
                        Console.WriteLine("What meal would you like to view?");
                        Console.WriteLine("1) Breakfast");
                        Console.WriteLine("2) Lunch");
                        Console.WriteLine("3) Dinner");
                        Console.WriteLine("4) Other");
                        string meal = Console.ReadLine();
                        Schedule day;

                        DayOfWeek today = DateTime.Now.DayOfWeek;
                        if (String.Equals(today.ToString(), "monday", StringComparison.OrdinalIgnoreCase)) {
                            day = schedule[0];
                        }
                        else if (String.Equals(today.ToString(), "tuesday", StringComparison.OrdinalIgnoreCase)) {
                            day = schedule[1];
                        }
                        else if (String.Equals(today.ToString(), "wednesday", StringComparison.OrdinalIgnoreCase)) {
                            day = schedule[2];
                        }
                        else if (String.Equals(today.ToString(), "thursday", StringComparison.OrdinalIgnoreCase)) {
                            day = schedule[3];
                        }
                        else if (String.Equals(today.ToString(), "friday", StringComparison.OrdinalIgnoreCase)) {
                            day = schedule[4];
                        }
                        else if (String.Equals(today.ToString(), "saturday", StringComparison.OrdinalIgnoreCase)) {
                            day = schedule[5];
                        }
                        else if (String.Equals(today.ToString(), "sunday", StringComparison.OrdinalIgnoreCase)) {
                            day = schedule[6];
                        }
                        else {
                            continue;
                        }

                        try {
                            mark = int.Parse(meal);
                        }
                        catch {
                            Console.WriteLine();
                        }

                        if (mark == 1) {
                            day.DisplayMeal("Breakfast");
                        }
                        else if (mark == 2) {
                            day.DisplayMeal("Lunch");
                        }
                        else if (mark == 3) {
                            day.DisplayMeal("Dinner");
                        }
                        else if (mark == 4) {
                            day.DisplayMeal("Other");
                        }
                        else {
                            continue;
                        }
                    }
                    else {
                        Console.WriteLine("Please enter a number between 1 and 4");
                    }
                }
                else if (mark == 2) { //Nutrition
                    Console.WriteLine("");
                    Console.WriteLine("What food would you like to look at the nutrition of?");
                    Food nutrients = FoodSelect(_allFood);
                    nutrients.DisplayNutrientInfo();

                }
                else if (mark == 3) { //Ingredients
                    Console.WriteLine("");
                    Console.WriteLine("What food would you like to look at the nutrition of?");
                    Food ingredients = FoodSelect(_madeFood);
                    if (ingredients is Made_Food madefood) {
                        madefood.DisplayIngredients();
                    }
                    else {
                        Console.WriteLine("This food does not have ingredients to display.");
                    }
                }
                else if (mark == 4) { //Foods saved
                    foreach (Food f in _allFood) {
                        Console.WriteLine($"-{f.Name}");
                    }
                }
                //else if (mark == 5) { //Shopping List

                //}
                else {
                    Console.WriteLine("Please enter a number between 1 and 4");
                }
            }
            else if (choice == 3) {
                Console.WriteLine("");
                Console.WriteLine("Are you saving or loading a file?");
                Console.WriteLine("1) Save");
                Console.WriteLine("2) Load");
                Console.WriteLine("Any other number/character to Cancel");
                Console.Write("Choice: ");
                option = Console.ReadLine();
                
                try {
                    mark = int.Parse(option);
                }
                catch {
                    Console.WriteLine();
                }

                if (mark == 1) {
                    using (StreamWriter writer = new StreamWriter("food.csv")) {
                        writer.WriteLine("Food Type,Name,Brand,Food Group,Stock,Units");
                        
                        using (StreamWriter nutrientswriter = new StreamWriter("nutrition.csv")) {
                            nutrientswriter.WriteLine("Food Name,Name,Amount,Units,Percentage");
                        
                            using (StreamWriter recipewriter = new StreamWriter("recipies.csv")) {
                                recipewriter.WriteLine("Food Name,Ingredient,Amount,Unit");
                            
                                foreach (Food food in _allFood){
                                    string foodType = food.Type();
                                    writer.WriteLine($"{foodType},{food.Name},{food.Brand},{food.FoodGroup},{food.Stock},{food.Units}");
                                    
                                    List<Nutrition> _nutrients = food.Nutrients;
                                    
                                    foreach(Nutrition nutrient in _nutrients){
                                        nutrientswriter.WriteLine($"{food.Name},{nutrient.Name},{nutrient.Amount},{nutrient.Units},{nutrient.Percentage}");
                                    
                                    }
                                    if (food is Made_Food madefood) {
                                        
                                        for (int i = 0; i < madefood.Ingredients().Count; i++) {
                                            
                                            Food ingredient = madefood.Ingredients()[i];
                                            int amount = madefood.Amounts()[i];
                                            string unit = madefood.IngUnits()[i];

                                            recipewriter.WriteLine($"{madefood.Name},{ingredient.Name},{amount},{unit}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (mark == 2) {
                    string foodFilePath = "food.csv";
                    string nutrientsPath = "nutrition.csv";
                    string recipePath = "recipies.csv";

                    _allFood.Clear();
                    _madeFood.Clear();
                    
                    try {

                        var foodList = new List<Food>();
                        var foodDict = new Dictionary<string, Food>();

                        using (StreamReader reader = new StreamReader(foodFilePath)) {
                            
                            reader.ReadLine();
                            
                            while (!reader.EndOfStream) {

                                string line = reader.ReadLine();
                                
                                var values = line.Split(',');

                                Food food = null;

                                if (values[0] == "Base_Food") {
                                    food = new Base_Food {
                                        Name = values[1].Trim(),
                                        Brand = values[2].Trim(),
                                        FoodGroup = values[3].Trim(),
                                        Stock = int.Parse(values[4].Trim()),
                                        Units = values[5].Trim()
                                    };

                                } else if (values[0] == "Made_Food") {
                                    food = new Made_Food {
                                        Name = values[1].Trim(),
                                        Brand = values[2].Trim(),
                                        FoodGroup = values[3].Trim(),
                                        Stock = int.Parse(values[4].Trim()),
                                        Units = values[5].Trim()
                                    };
                                    _madeFood.Add(food);

                                } else if (values[0] == "Baking") {
                                    food = new Baking {
                                        Name = values[1].Trim(),
                                        Brand = values[2].Trim(),
                                        FoodGroup = values[3].Trim(),
                                        Stock = int.Parse(values[4].Trim()),
                                        Units = values[5].Trim()
                                        
                                    };
                                    
                                }
                                if (food != null) {
                                    foodList.Add(food);
                                    foodDict[food.Name] = food;
                                    _allFood.Add(food); 
                                }

                            }
                        }
                        using (StreamReader reader = new StreamReader(nutrientsPath)) {
                            reader.ReadLine();
                            
                            while (!reader.EndOfStream) {
                                string line = reader.ReadLine();


                                var values = line.Split(',');

                                string foodName = values[0].Trim();
                                string nutrientname = values[1].Trim();
                                int amount = int.Parse(values[2].Trim());
                                string units = values[3].Trim();
                                int percentage = int.Parse(values[4].Trim());

                                Nutrition nutrition = new Nutrition(nutrientname, amount, units, percentage);
                                
                                if (foodDict.ContainsKey(foodName)) {
                                    foodDict[foodName].Nutrients.Add(nutrition);
                                }
                            }
                        }
                        using (StreamReader reader = new StreamReader(recipePath)) {
                            
                            reader.ReadLine();
                            
                            while (!reader.EndOfStream) {
                                string line = reader.ReadLine();

                                var values = line.Split(',');

                                string foodName = values[0].Trim();
                                string ingredientName = values[1].Trim();
                                int amount = int.Parse(values[2].Trim());
                                string units = values[3].Trim();

                                //Nutrition nutrition = new Nutrition(nutrientname, amount, units, percentage);
                                
                                if (foodDict.ContainsKey(foodName) && foodDict.ContainsKey(ingredientName)) {

                                    if (foodDict[foodName] is Made_Food updatemade) {
                                        updatemade.AddIngredient(foodDict[ingredientName], amount, units);
                                    }
                                
                                }
                            }
                        }
                        //_allFood.Clear();
                    }
                    catch (Exception ex) {
                        Console.WriteLine($"Error reading file: {ex.Message}");
                    }
                    
                } else {
                    break;
                }
            } 
            else if (choice == 4) {
                Console.WriteLine("Thank you for using your Food Schedule and Tracker app today!");
                continue;
            }
            else {
                Console.WriteLine("Please enter a number 1-4.");
            }
        }
    }
}
