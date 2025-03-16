using System;
using System.ComponentModel.DataAnnotations;
//I completed the assignment requirements, and added into it 
//the ability to save your goals and points then load them later
//to pick up where you left off at


class Program
{
    static void Main(string[] args)
    {
        int _points = 0;
        int i = 0;
        int choice = 0;
        int type = 0;
        string name;
        string description;
        string totaltimes;
        int amount = 0;
        int mark = 0;
        Console.WriteLine("Welcome to your Goal Tracker!");
        List<Basic> basics = new List<Basic>();
        List<Checklist> checklists = new List<Checklist>();
        List<Eternal> eternals = new List<Eternal>();
        List<Goals> allGoals = new List<Goals>();
        while (choice != 6) {
            Console.WriteLine("");
            Console.WriteLine("Please choose an option below: ");
            Console.WriteLine("1) Add goals");
            Console.WriteLine("2) List of goals");
            Console.WriteLine("3) Complete a goal");
            Console.WriteLine("4) Check points");
            Console.WriteLine("5) Save or Load File");
            Console.WriteLine("6) Exit the program");
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
                Console.WriteLine("What type of goal would you like to add?");
                Console.WriteLine("1) Basic goal");
                Console.WriteLine("2) Checklist goal");
                Console.WriteLine("3) Eternal goal");
                Console.WriteLine("Any other number/character to Cancel");
                Console.Write("Choice: ");
                option = Console.ReadLine();
                
                try {
                    type = int.Parse(option);
                }
                catch {
                    Console.WriteLine();
                }

                if (type == 1) {
                    Console.WriteLine("Sweet! To make your Basic goal, please answer the following questions: ");
                    Console.Write("What would you like to name this goal? ");
                    name = Console.ReadLine();
                    Console.Write("What would you like the description of it to be? ");
                    description = Console.ReadLine();
                    basics.Add(new Basic(name, description));
                    allGoals.Clear(); // Clear previous contents
                    allGoals.AddRange(basics);     // Add all items from 'basics'
                    allGoals.AddRange(checklists); // Add all items from 'checklists'
                    allGoals.AddRange(eternals);   // Add all items from 'eternals'
                    Console.WriteLine($"Added \"{name}\" to your Basic goals list with the description: {description}.");
                } 
                else if (type == 2) {
                    Console.WriteLine("Sweet! To make your Checklist goal, please answer the following questions: ");
                    Console.Write("What would you like to name this goal? ");
                    name = Console.ReadLine();
                    Console.Write("What would you like the description of it to be? ");
                    description = Console.ReadLine();
                    Console.Write("How many times would you like to complete this goal? ");
                    totaltimes = Console.ReadLine();
                    try {
                        amount = int.Parse(totaltimes);
                    }
                    catch {
                        Console.WriteLine("Please enter a number");
                        break;
                    }
                    checklists.Add(new Checklist(name, description, amount));
                    allGoals.Clear(); // Clear previous contents
                    allGoals.AddRange(basics);     // Add all items from 'basics'
                    allGoals.AddRange(checklists); // Add all items from 'checklists'
                    allGoals.AddRange(eternals);   // Add all items from 'eternals'
                    Console.WriteLine($"Added \"{name}\" to your Checklist goals list to be completed {amount} times, and with the description: {description}.");
                }
                else if (type == 3) {
                    Console.WriteLine("Sweet! To make your Eternal goal, please answer the following questions: ");
                    Console.Write("What would you like to name this goal? ");
                    name = Console.ReadLine();
                    Console.Write("What would you like the description of it to be? ");
                    description = Console.ReadLine();
                    eternals.Add(new Eternal(name, description));
                    allGoals.Clear(); // Clear previous contents
                    allGoals.AddRange(basics);     // Add all items from 'basics'
                    allGoals.AddRange(checklists); // Add all items from 'checklists'
                    allGoals.AddRange(eternals);   // Add all items from 'eternals'
                    Console.WriteLine($"Added \"{name}\" to your Eternal goals list with the description: {description}.");
                }
                else {
                    break;
                }
            }
            else if (choice == 2) {
                foreach (Goals g in allGoals) {
                    g.Display();
                }
            }
            else if (choice == 3) { //complete/mark a goal
                
                Console.WriteLine("Which goal would you like to complete?");
                i = 1;
                foreach (Goals g in allGoals) {
                    if (g.IsComplete()) {
                        
                    } else {
                        Console.Write($"{i}) ");
                        g.Display();
                    }
                    i++;
                }
                option = Console.ReadLine();
                try {
                    mark = int.Parse(option);
                }
                catch {
                    Console.WriteLine("Please enter a number");
                    break;
                }
                if (allGoals.Count >= mark) {
                    allGoals[mark-1].RecordEvent(ref _points);
                } else {
                    Console.WriteLine("Please enter a number shown in the list");
                }
            }
            else if (choice == 4) { //points

                Console.WriteLine($"You currently have {_points} points!");
            }
            else if (choice ==5) {
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
                    using (StreamWriter writer = new StreamWriter("goals.csv")) {
                    writer.WriteLine("Goal Type,Name,Description,Complete,CompletionAmount,TotalTimes,Points");
                    foreach (Goals j in allGoals){
                        string _type = j.Type();
                        name = j.Name();
                        description = j.Description();
                        bool complete = j.IsComplete();
                        if (_type == "Basic") {
                            writer.WriteLine($"{_type},{name},{description},{complete}");
                        } else if (_type == "Checklist") {
                            int completionamount = j.CompletionAmount();
                            int totaltime = j.TotalTimes();
                            writer.WriteLine($"{_type},{name},{description},{complete},{completionamount},{totaltime}");
                        } else if (_type == "Eternal") {
                            int completionamount = j.CompletionAmount();
                            writer.WriteLine($"{_type},{name},{description},{complete},{completionamount}");
                        }
                        
                    }
                    writer.WriteLine($",,,,,,{_points}");
                }
                } else if (mark == 2) {
                    string filePath = "goals.csv";
                    try {
                        using (StreamReader reader = new StreamReader(filePath))
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

                                int firstComma = line.IndexOf(',');
                                int secondComma = line.IndexOf(',', firstComma + 1);
                                int thirdComma = line.IndexOf(',', secondComma + 1);
                                int fourthComma = line.IndexOf(',', thirdComma + 1);
                                int fifthComma = line.IndexOf(',', fourthComma + 1);
                                int sixthComma = line.IndexOf(',', fifthComma + 1);                                
                                if (firstComma != -1)
                                {
                                    // Split only at the first comma
                                    string _type = line.Substring(0, firstComma).Trim();
                                    name = line.Substring(firstComma+1, secondComma - firstComma - 1).Trim();
                                    description = line.Substring(secondComma + 1, thirdComma - secondComma - 1).Trim(); // Rest of the line

                                    if (_type == "Basic") {
                                        string complete = line.Substring(thirdComma + 1).Trim();
                                        basics.Add(new Basic(name, description, complete));
                                    } else if (_type == "Checklist") {
                                        string complete = line.Substring(thirdComma + 1, fourthComma - thirdComma - 1).Trim();
                                        string completionamount = line.Substring(fourthComma + 1, fifthComma - fourthComma - 1).Trim();
                                        string totaltime = line.Substring(fifthComma + 1).Trim();
                                        checklists.Add(new Checklist(name, description, complete, completionamount, totaltime));
                                    } else if (_type == "Eternal") {
                                        string complete = line.Substring(thirdComma + 1, fourthComma - thirdComma - 1).Trim();
                                        string completionamount = line.Substring(fourthComma + 1).Trim();
                                        eternals.Add(new Eternal(name, description, complete, completionamount));
                                    } else {
                                        _points = int.Parse(line.Substring(sixthComma + 1).Trim());
                                    }
                                }

                            }
                        }
                        allGoals.Clear(); // Clear previous contents
                        allGoals.AddRange(basics);     // Add all items from 'basics'
                        allGoals.AddRange(checklists); // Add all items from 'checklists'
                        allGoals.AddRange(eternals);   // Add all items from 'eternals'
                    }
                    catch (Exception ex) {
                        Console.WriteLine($"Error reading file: {ex.Message}");
                    }
                    
                } else {
                    break;
                }
            }
            else if (choice == 6) {
                Console.WriteLine("Thank you for using your Goal Tracker today!");
                Console.WriteLine($"You earned {_points} points today!");
                continue;
            }
            else {
                Console.WriteLine("Please enter a number 1-5.");
            }
        }
    }
}