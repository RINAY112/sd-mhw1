using MHW1.Models.Animals;

namespace Tests.ModelsTests;

public class HerboTests
{
    [Theory]
    [InlineData(15, 10)]
    [InlineData(-5, 0)]
    [InlineData(7, 7)]
    public void Herbo_KindnessClampingWorks(int input, int expected)
    {
        var herbo = new Rabbit(5, 1, input);

        Assert.Equal(expected, herbo.Kindness);
    }

    [Fact]
    public void Herbo_ToString_IncludesKindness()
    {
        var herbo = new Rabbit(3, 456, 8);

        var result = herbo.ToString();

        Assert.Contains("Kindness: 8", result);
        Assert.Contains("Type: Herbo", result);
    }
}
