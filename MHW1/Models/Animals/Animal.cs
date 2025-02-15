using MHW1.Models.Abstractions;
namespace MHW1.Models.Animals;

public abstract class Animal : IAlive, IInventory
{
    private int _food;

    private int _number;

    private bool _isHealthy;

    public int Food => _food;

    public int Number => _number;

    public bool IsHealthy => _isHealthy;

    public Animal(int number, int food, bool isHealthy = true) => (_number, _food, _isHealthy) = (number, food, isHealthy);

    public override string ToString() => $"Number: {Number} | Kind: {GetType().Name} | Type: {GetType().BaseType?.Name ?? "Unknown"} | Food consumption: {Food}";
}
