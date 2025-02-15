using MHW1.Models.Animals;
using MHW1.Models.Inventory;

namespace MHW1.UI;

public enum Options { 
    AddAnimal,
    AddThing,
    PrintAnimalReport,
    PrintThingReport
}

public enum AnimalKinds
{
    Monkey, 
    Rabbit,
    Tiger,
    Wolf
}

public enum Herbo
{
    Monkey = AnimalKinds.Monkey,
    Rabbit = AnimalKinds.Rabbit
}

public enum ThingTypes
{
    Table,
    Computer
}

public static class ConsoleHelper
{
    public static readonly ConsoleColor originalBackground;
    public static readonly ConsoleColor originalForeground;

    static ConsoleHelper()
    {
        originalBackground = Console.BackgroundColor;
        originalForeground = Console.ForegroundColor;
    }

    public static void PrintError(in string message = "Incorrect value")
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine(message);
        Console.ForegroundColor = originalForeground;
    } 

    public static void GetInt(in string req, out int res)
    {
        Console.Write(req);
        while (!int.TryParse(Console.ReadLine(), out res))
        {
            PrintError();
            Console.Write(req);
        }
    }

    private static int? GetOption(in List<string> options)
    {
        int currentOption = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select the option(ecs to exit)");
            for (int i = 0; i < options.Count(); ++i)
            {
                if (i == currentOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(options[i]);

                if (i == currentOption)
                {
                    Console.BackgroundColor = originalBackground;
                    Console.ForegroundColor = originalForeground;
                }
            }

            var keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.Enter)
                return currentOption;
            else if (keyInfo.Key == ConsoleKey.DownArrow && currentOption != options.Count() - 1)
                ++currentOption;
            else if (keyInfo.Key == ConsoleKey.UpArrow && currentOption != 0)
                --currentOption;
            else if (keyInfo.Key == ConsoleKey.Escape)
                return null;
        }

    }

    public static Options? GetMainMenuOption()
    {
        return (Options?)GetOption(["Add an animal", "Add a thing", "Print animal report", "Print thing report"]);
    }

    public static Animal? GetAnimal()
    {
        var option = GetOption(["Monkey", "Rabbit", "Tiger", "Wolf"]);
        if (option is null)
            return null;

        var kind = (AnimalKinds)option;
        Console.Clear();

        int number;
        GetInt("Enter the number: ", out number);

        int food;
        GetInt("Enter the food consumption: ", out food);

        Console.WriteLine("Is it healthy? (Y/N)");
        bool isHealthy;
        while (true)
        {
            var keyInfo = Console.ReadKey(intercept: true);
            if (keyInfo.Key == ConsoleKey.Y)
            {
                isHealthy = true;
                break;
            }
            else if (keyInfo.Key == ConsoleKey.N)
            {
                isHealthy = false;
                break;
            }
        }

        int kindness = 0;
        if (Enum.IsDefined(typeof(Herbo), option!))
        {
            GetInt("Enter the kindness: ", out kindness);
        }

        return kind switch
        {
            AnimalKinds.Monkey => new Monkey(number, food, kindness, isHealthy),
            AnimalKinds.Rabbit => new Rabbit(number, food, kindness, isHealthy),
            AnimalKinds.Wolf => new Wolf(number, food, isHealthy),
            AnimalKinds.Tiger => new Tiger(number, food, isHealthy)
        };
    }

    public static Thing? GetThing()
    {
        var option = GetOption(["Table", "Computer"]);
        if (option is null)
            return null;

        var type = (ThingTypes)option;
        Console.Clear();

        int number;
        GetInt("Enter the number: ", out number);

        return type switch
        {
            ThingTypes.Table => new Table(number),
            ThingTypes.Computer => new Computer(number)
        };
    }

    public static void WaitForExit()
    {
        Console.WriteLine("\nEsc to exit");
        while (Console.ReadKey(intercept: true).Key != ConsoleKey.Escape) ;
    }

    public static void PrintAnimalReport(in IReadOnlyCollection<Animal> animals, in IReadOnlyCollection<Animal> contactZooAnimals, int totalFood)
    {
        Console.Clear();
        if (animals.Count == 0)
            Console.WriteLine("The zoo is empty");
        else
        {
            Console.WriteLine($"Total animals: {animals.Count()} with total food consumption: {totalFood} per day");
            foreach (var a in animals)
                Console.WriteLine($"\t{a.ToString()}");
            Console.WriteLine("-------------------------------------------- \n");
            if (contactZooAnimals.Count == 0)
                Console.WriteLine("No animal can be placed in the contact zoo");
            else
                Console.WriteLine("Animals that can be placed in the contact zoo:");
            foreach (var a in contactZooAnimals)
                Console.WriteLine($"\t{a.ToString()}");
        }
        WaitForExit();
    }

    public static void PrintThingReport(in IReadOnlyCollection<Thing> things)
    {
        Console.Clear();
        if (things.Count == 0)
            Console.WriteLine("Inventory is empty");
        else
        {
            Console.WriteLine($"Total things: {things.Count()}");
            foreach (var thing in things)
                Console.WriteLine($"\t{thing.ToString()}");
        }
        WaitForExit();
    }
}
