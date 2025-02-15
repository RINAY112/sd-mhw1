using MHW1.Models.Abstractions;

namespace MHW1.Models.Inventory;

public abstract class Thing : IInventory
{
    private int _number;

    public int Number => _number;

    protected Thing(int number) => _number = number;

    public override string ToString() => $"Number: {Number} | Type: {GetType().Name}";
}
