using MHW1.Models.Animals;
using MHW1.Services;

namespace Tests.ServicesTests;

public class VeterinaryClinicTests
{
    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    [InlineData(null, false)]
    public void ApproveForZoo_ReturnsCorrectResult(bool? isHealthy, bool expected)
    {
        var clinic = new VeterinaryClinic();
        Animal? animal = isHealthy.HasValue ? new Rabbit(2, 1, 6, isHealthy.Value) : null;

        var result = clinic.ApproveForZoo(animal);

        Assert.Equal(expected, result);
    }
}
