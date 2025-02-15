using MHW1.Models.Abstractions;
using MHW1.Models.Animals;

namespace Tests.ModelsTests;

public class AnimalTests
{
    [Fact]
    public void Animal_ImplementsInterfaces()
    {
        var animal = new Tiger(1, 5);

        Assert.IsAssignableFrom<IAlive>(animal);
        Assert.IsAssignableFrom<IInventory>(animal);
    }

    [Fact]
    public void Animal_ToString_ReturnsBaseInfo()
    {
        var animal = new Tiger(1, 5);

        var result = animal.ToString();

        Assert.Contains("Number: 1", result);
        Assert.Contains("Kind: Tiger", result);
        Assert.Contains("Type: Predator", result);
        Assert.Contains("Food consumption: 5", result);
    }


}
