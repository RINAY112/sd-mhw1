using MHW1.Models.Animals;
using MHW1.Models.Abstractions;
using MHW1.Models.Inventory;

namespace MHW1.Services.Abstractions
{
    public interface IZooService
    {
        void AddAnimal(Animal? animal);

        void AddThing(Thing? thing);

        int CalculateTotalFoodConsumption();

        List<Animal> GetContactZooAnimals();

        public IReadOnlyCollection<Animal> Animals { get; }

        public IReadOnlyCollection<Thing> Things { get; }
    }
}
