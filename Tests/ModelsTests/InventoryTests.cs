using MHW1.Models.Abstractions;
using MHW1.Models.Inventory;

namespace Tests.ModelsTests;

public class InventoryTests
{
    [Fact]
    public void Thing_ImplementsIInventory()
    {
        var table = new Table(123);
        var computer = new Computer(456);

        Assert.IsAssignableFrom<IInventory>(table);
        Assert.IsAssignableFrom<IInventory>(computer);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(9999)]
    public void Thing_NumberInitialization(int number)
    {
        var table = new Table(number);
        var computer = new Computer(number);

        Assert.Equal(number, table.Number);
        Assert.Equal(number, computer.Number);
    }

    [Fact]
    public void Thing_ToString_ReturnsCorrectFormat()
    {
        var table = new Table(456);
        var computer = new Computer(789);

        Assert.Equal("Number: 456 | Type: Table", table.ToString());
        Assert.Equal("Number: 789 | Type: Computer", computer.ToString());
    }

    [Fact]
    public void Table_InheritsFromThing()
    {
        var table = new Table(123);

        Assert.IsAssignableFrom<Thing>(table);
        Assert.Equal(123, table.Number);
        Assert.Equal("Number: 123 | Type: Table", table.ToString());
    }

    [Fact]
    public void Computer_InheritsFromThing()
    {
        var computer = new Computer(456);

        Assert.IsAssignableFrom<Thing>(computer);
        Assert.Equal(456, computer.Number);
        Assert.Equal("Number: 456 | Type: Computer", computer.ToString());
    }
}