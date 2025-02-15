using Microsoft.Extensions.DependencyInjection;
using MHW1.Services.Abstractions;
using MHW1.UI;

namespace MHW1;

class Program
{
    static void Main()
    {
        var provider = DependencyInjection.ConfigureServices();

        using (var scope = provider.CreateScope())
        {
            Options? option;
            var zooService = scope.ServiceProvider.GetRequiredService<IZooService>();
            while ((option = ConsoleHelper.GetMainMenuOption()) is not null)
            {
                if (option == Options.AddAnimal)
                    zooService.AddAnimal(ConsoleHelper.GetAnimal());
                else if (option == Options.AddThing)
                    zooService.AddThing(ConsoleHelper.GetThing());
                else if (option == Options.PrintAnimalReport)
                    ConsoleHelper.PrintAnimalReport(zooService.Animals, zooService.GetContactZooAnimals(), zooService.CalculateTotalFoodConsumption());
                else if (option == Options.PrintThingReport)
                    ConsoleHelper.PrintThingReport(zooService.Things);
            }
        }
    }
}