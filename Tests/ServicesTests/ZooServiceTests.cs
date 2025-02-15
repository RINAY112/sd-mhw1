using MHW1.Models.Animals;
using MHW1.Services.Abstractions;
using MHW1.Services;

namespace Tests.ServicesTests;

public class ZooServiceTests
{
    private readonly IVeterinaryClinic _clinic = new VeterinaryClinic();

    [Fact]
    public void AddAnimal_UnhealthyHerbo_DoesNotAddToCollection()
    {
        var zooService = new ZooService(_clinic);
        var unhealthyRabbit = new Rabbit(
            number: 1,
            food: 2,
            kindness: 7,
            isHealthy: false 
        );

        zooService.AddAnimal(unhealthyRabbit);

        Assert.Empty(zooService.Animals);
    }

    [Fact]
    public void AddAnimal_UnhealthyPredator_DoesNotAddToCollection()
    {
        var zooService = new ZooService(_clinic);
        var unhealthyTiger = new Tiger(
            number: 1,
            food: 5,
            isHealthy: false 
        );

        zooService.AddAnimal(unhealthyTiger);

        Assert.Empty(zooService.Animals);
    }

    [Fact]
    public void AddAnimal_HealthyHerboWithLowKindness_AddsButNotToContactZoo()
    {
        var zooService = new ZooService(_clinic);
        var rabbit = new Rabbit(
            number: 1,
            food: 2,
            kindness: 4, 
            isHealthy: true
        );

        zooService.AddAnimal(rabbit);

        Assert.Single(zooService.Animals);
        Assert.Empty(zooService.GetContactZooAnimals());
    }

    [Fact]
    public void CalculateTotalFood_OnlyAddsHealthyAnimals()
    {
        var zooService = new ZooService(_clinic);
        var healthyTiger = new Tiger(1, 5, isHealthy: true);
        var unhealthyRabbit = new Rabbit(2, 2, 7, isHealthy: false);

        zooService.AddAnimal(healthyTiger);
        zooService.AddAnimal(unhealthyRabbit);

        Assert.Equal(5, zooService.CalculateTotalFoodConsumption());
    }

    [Fact]
    public void GetContactZooAnimals_RequiresHealthAndKindnessAndHerbo()
    {
        var zooService = new ZooService(_clinic);
        var healthyRabbit = new Rabbit(1, 2, 7, isHealthy: true);
        var unhealthyRabbit = new Rabbit(2, 2, 9, isHealthy: false);
        var healthyTiger = new Tiger(3, 5, isHealthy: true);
        var unhealthyTiger = new Tiger(4, 5, isHealthy: false);

        zooService.AddAnimal(healthyRabbit);
        zooService.AddAnimal(unhealthyRabbit);
        zooService.AddAnimal(healthyTiger);
        zooService.AddAnimal(unhealthyTiger);

        var result = zooService.GetContactZooAnimals();
        Assert.Single(result);
        Assert.Contains(healthyRabbit, result);
        Assert.DoesNotContain(unhealthyRabbit, result);
    }
}