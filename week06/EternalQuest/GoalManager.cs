using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1") CreateGoal();
            else if (choice == "2") ListGoalDetails();
            else if (choice == "3") SaveGoals();
            else if (choice == "4") LoadGoals();
            else if (choice == "5") RecordEvent();
        }
    }

    public void DisplayPlayerInfo()
    {
        string title = "Level 1: Novice";
        if (_score >= 1000) title = "Level 2: Apprentice";
        if (_score >= 5000) title = "Level 3: Master";
        if (_score >= 10000) title = "Level 4: Grandmaster";
        if (_score >= 50000) title = "Level 5: Eternal Champion";

        Console.WriteLine($"\n*** You are a {title} ***");
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        
        // BUG FIXED: We capture the string, but immediately parse it to an integer
        string pointsString = Console.ReadLine();
        int pointsValue = int.Parse(pointsString);

        if (type == "1")
        {
            // BUG FIXED: Passed 'name' instead of 'shortName', and 'pointsValue' instead of the string
            _goals.Add(new SimpleGoal(name, description, pointsValue));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, pointsValue));
        }
        else if (type == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(target, bonus, name, description, pointsValue));
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("The goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        Goal selectedGoal = _goals[goalIndex];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine("You have already completed this goal!");
            return;
        }

        selectedGoal.RecordEvent();
        
        int pointsEarned = selectedGoal.GetPoints();
        _score += pointsEarned;

        if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete())
        {
            int bonus = checklist.GetBonus();
            _score += bonus;
            pointsEarned += bonus;
        }

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score); 
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]); 
            _goals.Clear(); 

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string goalType = parts[0];
                string[] details = parts[1].Split(',');

                string name = details[0];
                string desc = details[1];
                
                // BUG FIXED: Parse the points from the text file into an integer
                int pointsValue = int.Parse(details[2]);

                if (goalType == "SimpleGoal")
                {
                    bool isComplete = bool.Parse(details[3]);
                    _goals.Add(new SimpleGoal(name, desc, pointsValue, isComplete));
                }
                else if (goalType == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(name, desc, pointsValue));
                }
                else if (goalType == "ChecklistGoal")
                {
                    int bonus = int.Parse(details[3]);
                    int target = int.Parse(details[4]);
                    int completed = int.Parse(details[5]);
                    _goals.Add(new ChecklistGoal(name, desc, pointsValue, target, bonus, completed));
                }
            }
        }
    }
}