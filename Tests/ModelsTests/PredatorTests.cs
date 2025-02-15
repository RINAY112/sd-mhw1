using MHW1.Models.Animals;

namespace Tests.ModelsTests;

public class PredatorTests
{
    [Fact]
    public void Predator_ToString_DoesNotIncludeKindness()
    {
        var predator = new Tiger(10, 789);

        var result = predator.ToString();

        Assert.DoesNotContain("Kindness", result);
    }
}
