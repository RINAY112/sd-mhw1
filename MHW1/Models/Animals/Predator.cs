namespace MHW1.Models.Animals;

public abstract class Predator : Animal
{
    public Predator(int number, int food, bool isHealthy = true) : base(number, food, isHealthy) { }
}
