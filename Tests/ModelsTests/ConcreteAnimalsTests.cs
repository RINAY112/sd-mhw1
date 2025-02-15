using MHW1.Models.Animals;

namespace Tests.ModelsTests;

public class ConcreteAnimalsTests
{
    [Fact]
    public void Rabbit_InheritsFromHerbo()
    {
        var rabbit = new Rabbit(1, 2, 5);

        Assert.IsType<Herbo>(rabbit, exactMatch: false);
        Assert.Equal(5, rabbit.Kindness);
    }

    [Fact]
    public void Monkey_InheritsFromHerbo()
    {
        var monkey = new Monkey(2, 3, 7);

        Assert.IsType<Herbo>(monkey, exactMatch: false);
        Assert.Equal(7, monkey.Kindness);
    }

    [Fact]
    public void Tiger_InheritsFromPredator()
    {
        var tiger = new Tiger(3, 15);

        Assert.IsType<Predator>(tiger, exactMatch: false);
        Assert.Equal(15, tiger.Food);
    }

    [Fact]
    public void Wolf_InheritsFromPredator()
    {
        var wolf = new Wolf(4, 12);

        Assert.IsType<Predator>(wolf, exactMatch: false);
        Assert.Equal(12, wolf.Food);
    }

    [Theory]
    [InlineData(9, true)]
    [InlineData(4, false)]
    public void HerboAnimals_ContactZooEligibility(int input, bool expected)
    {
        var herbo = new Rabbit(1, 2, input);

        Assert.Equal(expected, herbo.Kindness > 5);
    }
}
