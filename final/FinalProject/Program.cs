using System;
using System.ComponentModel.DataAnnotations;
//Shopping list?


class Program
{
    //Food Select function to call
    static Food FoodSelect(List<Food> _allFood) {
        Console.Write("Search: ");
        string option = Console.ReadLine();
        
        //Cancel option
        if (option == "0") {
            return null;
        }
        
        //Finds matching foods and adds to list
        var matchingFoods = _allFood
            .Where(f => f.Name.Contains(option, StringComparison.OrdinalIgnoreCase))
            .ToList();

        //If you got none, exit
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

            return foodSelect; //return selected food
        }
    }
    static void Main(string[] args)
    {
        
        //starting variables and lists
        int choice = 0;
        int mark = 0;
        int cancel = 0;
        List<Food> _allFood =  new List<Food>();
        List<Food> _madeFood = new List<Food>();
        List<Food> _ingredients = new List<Food>();
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
        string foodFilePath = "food.csv";
        string nutrientsPath = "nutrition.csv";
        string recipePath = "recipies.csv";

        //clears lists, just in case
        _allFood.Clear();
        _madeFood.Clear();
        
        //to load in files if you have them
        try {

            var foodList = new List<Food>();
            var foodDict = new Dictionary<string, Food>();

            //Load in the food names and details
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
            //Load in the nutrition info
            using (StreamReader reader = new StreamReader(nutrientsPath)) {
                reader.ReadLine();
                
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();


                    var values = line.Split(',');

                    string foodName = values[0].Trim();
                    string nutrientname = values[1].Trim();
                    double amount = double.Parse(values[2].Trim());
                    string units = values[3].Trim();
                    double percentage = double.Parse(values[4].Trim());

                    Nutrition nutrition = new Nutrition(nutrientname, amount, units, percentage);
                    
                    if (foodDict.ContainsKey(foodName)) {
                        foodDict[foodName].Nutrients.Add(nutrition);
                    }
                }
            }
            //Load in the ingredients for the made food
            using (StreamReader reader = new StreamReader(recipePath)) {
                
                reader.ReadLine();
                
                while (!reader.EndOfStream) {
                    string line = reader.ReadLine();

                    var values = line.Split(',');

                    string foodName = values[0].Trim();
                    string ingredientName = values[1].Trim();
                    double amount = double.Parse(values[2].Trim());
                    string units = values[3].Trim();

                    //Nutrition nutrition = new Nutrition(nutrientname, amount, units, percentage);
                    
                    if (foodDict.ContainsKey(foodName) && foodDict.ContainsKey(ingredientName)) {

                        if (foodDict[foodName] is Made_Food updatemade) {
                            updatemade.AddIngredient(foodDict[ingredientName], amount, units);
                        }
                    
                    }
                }
            }
        } catch (Exception ex) { //If it doesn't work, explain that it didn't
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
        Console.WriteLine("Welcome to your Food Schedule and Tracker App!");
        while (choice != 5) {
            //Opening menu
            Console.WriteLine("");
            Console.WriteLine("Please choose an option below: ");
            Console.WriteLine("1) Add Food, update food, add to schedule"); //Add: New food, to schedule, update food info
            Console.WriteLine("2) View Schedule, Nutrition, Ingredients, Food");//View: Schedule, Nutrition, Ingredients, Foods saved
            Console.WriteLine("3) Clear Schedule");
            Console.WriteLine("4) Save or Load File");
            Console.WriteLine("5) Exit the program");
            Console.Write("Choice: ");
            string option = Console.ReadLine();
            Console.WriteLine("");
            choice = 0;

            try {
                choice = int.Parse(option);
            }
            catch {
                Console.WriteLine("Please enter a number");
            }

            if (choice == 1) { //Add section
                Console.WriteLine("");
                Console.WriteLine("What are you wanting to add/update?");
                Console.WriteLine("1) New Food");
                Console.WriteLine("2) Update Food Info/Nutrition");
                Console.WriteLine("3) Add to schedule");
                Console.WriteLine("Any other number/character to Cancel");
                Console.Write("Choice: ");
                option = Console.ReadLine();
                mark = 0;
                try {
                    mark = int.Parse(option);
                }
                catch {
                    Console.WriteLine();
                }

                if (mark == 1) { //New food

                    Console.WriteLine("");
                    Console.WriteLine("What kind of food are you adding/creating?");
                    Console.WriteLine("1) Base Food");
                    Console.WriteLine("2) Made Food");
                    Console.WriteLine("3) Baking Ingredient");
                    Console.WriteLine("Any other number/character to Cancel");
                    Console.Write("Choice: ");
                    option = Console.ReadLine();
                    mark = 0;

                    try {
                        mark = int.Parse(option);
                    }
                    catch {
                        Console.WriteLine();
                    }

                    if (mark == 1) { //Basic food
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
                        _ingredients.Add(baseFood);
                        Console.WriteLine($"Perfect! You have now added {baseFood.Name} to your food list option!");

                    }
                    else if (mark == 2) { //made food, or recipe
                        Made_Food madeFood = new Made_Food();
                        Console.WriteLine("Please enter the following data: ");
                        Console.Write("Name: ");
                        madeFood.Name = Console.ReadLine();
                        while (true) {
                            Console.Write("What Ingredient do you want to add? ");
                            Food ingredient = FoodSelect(_allFood);
                            if (ingredient != null) {
                                Console.Write("Amount of this ingredient to use? ");
                                string amount = Console.ReadLine();
                                double intamount;
                                try {
                                    intamount = double.Parse(amount);
                                }
                                catch {
                                    Console.WriteLine("Please enter a number");
                                    continue;
                                }
                                Console.Write("Units of amount? ");
                                string units = Console.ReadLine();
                                madeFood.AddIngredient(ingredient, intamount, units);
                            }
                            else {
                                break;
                            }
                        }
                        _allFood.Add(madeFood);
                        _madeFood.Add(madeFood);
                        madeFood.NutrientUpdate();
                        Console.WriteLine($"Perfect! You have now added {madeFood.Name} to your food list option!");
                    }
                    else if (mark == 3) { //baking ingredient
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
                        _ingredients.Add(baking);
                        Console.WriteLine($"Perfect! You have now added {baking.Name} to your food list option!");

                    }
                    else {
                        continue;
                    }
                }
                else if (mark == 2) { //add nutrition info
                    Console.WriteLine("");
                    Console.WriteLine("Please enter the food name you want to update (enter 0 to cancel): ");
                    Food update = FoodSelect(_ingredients); //calls food select function to find food

                    if (update != null) {
                        Console.WriteLine($"Updating food: {update.Name}");
                        Console.WriteLine("Now you will enter the nutrients data (for one serving). Do it one item at a time, and it will keep going until you cancel/stop it");
                        cancel = 0;
                    
                        while (cancel != 1) { //Collects data for nutrition
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
                            double amount;
                            while (!double.TryParse(Console.ReadLine(), out amount) || amount < 0) 
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
                            double percent;
                            while (!double.TryParse(Console.ReadLine(), out percent) || percent < 0 || percent > 100) 
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
                else if (mark == 3) { //Adding to schedule
                    Console.WriteLine("");
                    Console.WriteLine("What day are you adding this to? (Ex: Sunday, Monday, etc)");
                    Console.Write("Day: ");
                    string day = Console.ReadLine();
                    Console.WriteLine("What meal? (Ex: Breakfast, Lunch, Dinner, Other)");
                    Console.Write("Meal: ");
                    string meal = Console.ReadLine();
                    Console.WriteLine("What food are you adding?");
                    Food selectedFood = FoodSelect(_allFood);
                    meal = meal.Trim();

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
                else {
                    continue;
                }
            }
            else if (choice == 2) {
                Console.WriteLine(""); 
                Console.WriteLine("What are you wanting to view?");
                Console.WriteLine("1) Schedule");
                Console.WriteLine("2) Nutrition of a food item");
                Console.WriteLine("3) Ingredients of a Food");
                Console.WriteLine("4) Foods saved");
                Console.WriteLine("Any other number/character to Cancel");
                Console.Write("Choice: ");
                option = Console.ReadLine();
                mark = 0;

                try {
                    mark = int.Parse(option);
                }
                catch {
                    Console.WriteLine();
                }

                if (mark == 1) {
                    Console.WriteLine("");
                    Console.WriteLine("What Schedule would you like to view?");
                    Console.WriteLine("1) All meals this week");
                    Console.WriteLine("2) All meals for a day");
                    Console.WriteLine("3) A meal today");
                    Console.WriteLine("Any other number/character to Cancel");
                    Console.Write("Choice: ");
                    option = Console.ReadLine();
                    mark = 0;
                    string nutrientmeal;
                    int mealnutrient = 0;

                    try {
                        mark = int.Parse(option);
                    }
                    catch {
                        Console.WriteLine();
                    }

                    if (mark == 1) { //All meals this week
                        foreach (Schedule s in schedule) {
                            s.DisplayDay();
                            Console.WriteLine("");
                        }
                    }
                    else if (mark == 2) { //meals for a specific day

                        //Allows to see daily nutrition info
                        Console.WriteLine("");
                        Console.WriteLine("Would you like to view the meals (1) or the nutrition for the meals (2)? (anything else to cancel)");
                        Console.Write("Choice: ");
                        nutrientmeal = Console.ReadLine();

                        try {
                            mealnutrient = int.Parse(nutrientmeal);
                        }
                        catch {
                            Console.WriteLine();
                        }

                        Console.WriteLine("");
                        Console.WriteLine("Now, what day would you like to view?");
                        Console.WriteLine("1) Today");
                        Console.WriteLine("2) Monday");
                        Console.WriteLine("3) Tuesday");
                        Console.WriteLine("4) Wednesday");
                        Console.WriteLine("5) Thursday");
                        Console.WriteLine("6) Friday");
                        Console.WriteLine("7) Saturday");
                        Console.WriteLine("8) Sunday");
                        Console.WriteLine("Any other number/character to Cancel");
                        Console.Write("Choice: ");
                        string day = Console.ReadLine();
                        mark = 0;

                        try {
                            mark = int.Parse(day);
                        }
                        catch {
                            Console.WriteLine();
                        }


                        if (mark == 1) {
                            DayOfWeek today = DateTime.Now.DayOfWeek;
                            if (String.Equals(today.ToString(), "monday", StringComparison.OrdinalIgnoreCase)) {
                                if (mealnutrient == 1) {
                                    schedule[0].DisplayDay();
                                }
                                else if (mealnutrient == 2) {
                                    schedule[0].DisplaySummary();
                                }
                            }
                            else if (String.Equals(today.ToString(), "tuesday", StringComparison.OrdinalIgnoreCase)) {
                                if (mealnutrient == 1) {
                                    schedule[1].DisplayDay();
                                }
                                else if (mealnutrient == 2) {
                                    schedule[1].DisplaySummary();
                                }                            }
                            else if (String.Equals(today.ToString(), "wednesday", StringComparison.OrdinalIgnoreCase)) {
                                if (mealnutrient == 1) {
                                    schedule[2].DisplayDay();
                                }
                                else if (mealnutrient == 2) {
                                    schedule[2].DisplaySummary();
                                }
                            }
                            else if (String.Equals(today.ToString(), "thursday", StringComparison.OrdinalIgnoreCase)) {
                                if (mealnutrient == 1) {
                                    schedule[3].DisplayDay();
                                }
                                else if (mealnutrient == 2) {
                                    schedule[3].DisplaySummary();
                                }
                            }
                            else if (String.Equals(today.ToString(), "friday", StringComparison.OrdinalIgnoreCase)) {
                                if (mealnutrient == 1) {
                                    schedule[4].DisplayDay();
                                }
                                else if (mealnutrient == 2) {
                                    schedule[4].DisplaySummary();
                                }
                            }
                            else if (String.Equals(today.ToString(), "saturday", StringComparison.OrdinalIgnoreCase)) {
                                if (mealnutrient == 1) {
                                    schedule[5].DisplayDay();
                                }
                                else if (mealnutrient == 2) {
                                    schedule[5].DisplaySummary();
                                }
                            }
                            else if (String.Equals(today.ToString(), "sunday", StringComparison.OrdinalIgnoreCase)) {
                                if (mealnutrient == 1) {
                                    schedule[6].DisplayDay();
                                }
                                else if (mealnutrient == 2) {
                                    schedule[6].DisplaySummary();
                                }
                            }
                            else {
                                continue;
                            }

                        }
                        else if (mark == 2) {
                            if (mealnutrient == 1) {
                                schedule[0].DisplayDay();
                            }
                            else if (mealnutrient == 2) {
                                schedule[0].DisplaySummary();
                            }
                        }
                        else if (mark == 3) {
                            if (mealnutrient == 1) {
                                schedule[1].DisplayDay();
                            }
                            else if (mealnutrient == 2) {
                                schedule[1].DisplaySummary();
                            }
                        }
                        else if (mark == 4) {
                            if (mealnutrient == 1) {
                                schedule[2].DisplayDay();
                            }
                            else if (mealnutrient == 2) {
                                schedule[2].DisplaySummary();
                            }
                        }
                        else if (mark == 5) {
                            if (mealnutrient == 1) {
                                schedule[3].DisplayDay();
                            }
                            else if (mealnutrient == 2) {
                                schedule[3].DisplaySummary();
                            }
                        }
                        else if (mark == 6) {
                            if (mealnutrient == 1) {
                                schedule[4].DisplayDay();
                            }
                            else if (mealnutrient == 2) {
                                schedule[4].DisplaySummary();
                            }
                        }
                        else if (mark == 7) {
                            if (mealnutrient == 1) {
                                schedule[5].DisplayDay();
                            }
                            else if (mealnutrient == 2) {
                                schedule[5].DisplaySummary();
                            }
                        }
                        else if (mark == 8) {
                            if (mealnutrient == 1) {
                                schedule[6].DisplayDay();
                            }
                            else if (mealnutrient == 2) {
                                schedule[6].DisplaySummary();
                            }
                        }
                        else {
                            Console.WriteLine("Please enter a number between 1 and 8");
                        }
                    }
                    else if (mark == 3) { //a meal today
                        Console.WriteLine("What meal would you like to view?");
                        Console.WriteLine("1) Breakfast");
                        Console.WriteLine("2) Lunch");
                        Console.WriteLine("3) Dinner");
                        Console.WriteLine("4) Other");
                        Console.WriteLine("Any other number/character to Cancel");
                        Console.Write("Choice: ");
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
                else if (mark == 2) { //Nutrition of a food item
                    Console.WriteLine("");
                    Console.WriteLine("What food would you like to look at the nutrition of?");
                    Food nutrients = FoodSelect(_allFood);
                    nutrients.DisplayNutrientInfo();

                }
                else if (mark == 3) { //Ingredients
                    Console.WriteLine("");
                    Console.WriteLine("What food would you like to look at the ingredients of?");
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
                else {
                    Console.WriteLine("Please enter a number between 1 and 4");
                }
            }
            else if (choice == 3) { //clear week schedule
                foreach (var day in schedule) {
                    day.ClearSchedule();
                }
            }
            else if (choice == 4) { //save or load file
                Console.WriteLine("");
                Console.WriteLine("Are you saving or loading a file?");
                Console.WriteLine("1) Save");
                Console.WriteLine("2) Load");
                Console.WriteLine("Any other number/character to Cancel");
                Console.Write("Choice: ");
                option = Console.ReadLine();
                mark = 0;

                try {
                    mark = int.Parse(option);
                }
                catch {
                    Console.WriteLine();
                }

                if (mark == 1) { //saves file
                    using (StreamWriter writer = new StreamWriter(foodFilePath)) {
                        writer.WriteLine("Food Type,Name,Brand,Food Group,Stock,Units");
                        
                        using (StreamWriter nutrientswriter = new StreamWriter(nutrientsPath)) {
                            nutrientswriter.WriteLine("Food Name,Name,Amount,Units,Percentage");
                        
                            using (StreamWriter recipewriter = new StreamWriter(recipePath)) {
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
                                            double amount = madefood.Amounts()[i];
                                            string unit = madefood.IngUnits()[i];

                                            recipewriter.WriteLine($"{madefood.Name},{ingredient.Name},{amount},{unit}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else if (mark == 2) { //loads file

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
                                double amount = double.Parse(values[2].Trim());
                                string units = values[3].Trim();
                                double percentage = double.Parse(values[4].Trim());

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
                                double amount = double.Parse(values[2].Trim());
                                string units = values[3].Trim();

                                //Nutrition nutrition = new Nutrition(nutrientname, amount, units, percentage);
                                
                                if (foodDict.ContainsKey(foodName) && foodDict.ContainsKey(ingredientName)) {

                                    if (foodDict[foodName] is Made_Food updatemade) {
                                        updatemade.AddIngredient(foodDict[ingredientName], amount, units);
                                    }
                                
                                }
                            }
                        }
                    }
                    catch (Exception ex) {
                        Console.WriteLine($"Error reading file: {ex.Message}");
                    }
                    
                } else {
                    continue;
                }
            } 
            else if (choice == 5) { //exits program
                Console.WriteLine("Thank you for using your Food Schedule and Tracker app today!");
                continue;
            }
            else {
                Console.WriteLine("Please enter a number 1-4.");
            }
        }
    }
}
