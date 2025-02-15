namespace MHW1.Models.Animals;

public abstract class Herbo : Animal
{
    private int _kindness;

    public int Kindness => _kindness;

    public Herbo(int number, int food, int kindness, bool isHelthy = true) : base(number, food, isHelthy) => _kindness = kindness < 0 ? 0 : kindness > 10 ? 10 : kindness;

    public override string ToString() => $"{base.ToString()} | Kindness: {Kindness}";
}
