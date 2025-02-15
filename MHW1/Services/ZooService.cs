using MHW1.Services.Abstractions;
using MHW1.Models.Animals;
using MHW1.Models.Inventory;

namespace MHW1.Services;

public class ZooService : IZooService
{
    private List<Animal> _animals = new();

    private List<Thing> _things = new();

    private IVeterinaryClinic _veterinaryClinic;

    public ZooService(IVeterinaryClinic veterinaryClinic) => _veterinaryClinic = veterinaryClinic;

    public void AddAnimal(Animal? animal)
    {
        if (_veterinaryClinic.ApproveForZoo(animal))
            _animals.Add(animal!);
    }

    public void AddThing(Thing? thing)
    {
        if (thing is not null)
            _things.Add(thing);
    }

    public int CalculateTotalFoodConsumption() => _animals.Sum(a => a.Food);

    public List<Animal> GetContactZooAnimals() => _animals.OfType<Herbo>().
                                                           Where(h => h.Kindness > 5).
                                                           Cast<Animal>().
                                                           ToList();

    public IReadOnlyCollection<Animal> Animals => _animals;

    public IReadOnlyCollection<Thing> Things => _things;
}
