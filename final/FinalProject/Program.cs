using System;
using System.ComponentModel.DataAnnotations;


class Program
{
    static void Main(string[] args)
    {
        int choice = 0;
        int mark = 0;
        int cancel = 0;
        List<Food> _allFood =  new List<Food>();
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
        while (choice != 7) {
            Console.WriteLine("");
            Console.WriteLine("Please choose an option below: ");
            Console.WriteLine("1) Add Food, update food, add to schedule"); //Add: New food, to schedule, update food info
            Console.WriteLine("2) View Schedule");//View: Schedule, Nutrition, Ingredients, Shopping List, Foods saved
            Console.WriteLine("3) View Nutrition");
            Console.WriteLine("4) View Ingredients");
            Console.WriteLine("5) View Shopping List");
            Console.WriteLine("6) Save or Load File");
            Console.WriteLine("7) Exit the program");
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
                    option = Console.ReadLine();
                    
                    if (option == "0") {
                        break;
                    }
                    
                    var matchingFoods = _allFood
                        .Where(f => f.Name.Contains(option, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (matchingFoods.Count == 0)
                    {
                        Console.WriteLine("No matching food items found. Please check the name and try again.");
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
                        Food update = matchingFoods[selection - 1];
                    
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
                }
                else if (mark == 3) {
                    Console.WriteLine("");
                    Console.WriteLine("What day are you adding this to? (Ex: Sunday, Monday, etc)");
                    string day = Console.ReadLine();
                    Console.WriteLine("What meal? (Ex: Breakfast, Lunch, Dinner, Other)");
                    string meal = Console.ReadLine();
                    Console.Write("What food are you adding?");
                    option = Console.ReadLine();
                    
                    var matchingFoods = _allFood
                        .Where(f => f.Name.Contains(option, StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    if (matchingFoods.Count == 0)
                    {
                        Console.WriteLine("No matching food items found. Please check the name and try again.");
                    }
                    else
                    {
                        Console.WriteLine("Matching food items:");
                        
                        for (int i = 0; i < matchingFoods.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {matchingFoods[i].Name}");
                        }


                        Console.Write("Please select a food item by number: ");
                        int selection;
                        while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > matchingFoods.Count)
                        {
                            Console.Write("Invalid selection. Please enter a number between 1 and " + matchingFoods.Count + ": ");
                        }


                        Food selectedFood = matchingFoods[selection - 1];
                        
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

                }
            }
            else if (choice == 2) {

                
            }
            else if (choice ==3) {
                
            }
            else if (choice == 4) {

            }
            else if (choice == 6) {

            }
            else if (choice == 6) {
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
                            foreach (Food food in _allFood){
                                string foodType = food.Type();
                                writer.WriteLine($"{foodType},{food.Name},{food.Brand},{food.FoodGroup},{food.Stock},{food.Units}");
                                
                                List<Nutrition> _nutrients = food.Nutrients;
                                
                                foreach(Nutrition nutrient in _nutrients){
                                    nutrientswriter.WriteLine($"{food.Name},{nutrient.Name},{nutrient.Amount},{nutrient.Units},{nutrient.Percentage}");
                                

                                }
                            }
                        }
                    }
                } else if (mark == 2) {
                    string foodFilePath = "food.csv";
                    string nutrientsPath = "nutrition.csv";
                    try {

                        var foodList = new List<Food>();
                        var foodDict = new Dictionary<string, Food>();

                        using (StreamReader reader = new StreamReader(foodFilePath))
                        {
                            bool firstLine = true;
                            while (!reader.EndOfStream)
                            {
                                string line = reader.ReadLine();
                                if (firstLine) // Skip header
                                {
                                    firstLine = false;
                                    continue;
                                }
                                var values = line.Split(',');

                                if (values[0] == "Base_Food") {
                                    var food = new Base_Food {
                                        Name = values[1].Trim(),
                                        Brand = values[2].Trim(),
                                        FoodGroup = values[3].Trim(),
                                        Stock = int.Parse(values[4].Trim()),
                                        Units = values[5].Trim()
                                    };
                                    foodList.Add(food);
                                    foodDict[food.Name] = food;
                                } else if (values[0] == "Made_Food") {
                                    var food = new Made_Food {
                                        Name = values[1].Trim(),
                                        Brand = values[2].Trim(),
                                        FoodGroup = values[3].Trim(),
                                        Stock = int.Parse(values[4].Trim()),
                                        Units = values[5].Trim()
                                    };
                                } else if (values[0] == "Baking") {
                                    var food = new Baking {
                                        Name = values[1].Trim(),
                                        Brand = values[2].Trim(),
                                        FoodGroup = values[3].Trim(),
                                        Stock = int.Parse(values[4].Trim()),
                                        Units = values[5].Trim()
                                        
                                    };
                                    foodList.Add(food);
                                    foodDict[food.Name] = food;
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
            else if (choice == 7) {
                Console.WriteLine("Thank you for using your Food Schedule and Tracker app today!");
                continue;
            }
            else {
                Console.WriteLine("Please enter a number 1-5.");
            }
        }
    }
}