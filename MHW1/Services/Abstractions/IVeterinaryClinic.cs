using MHW1.Models.Animals;

namespace MHW1.Services.Abstractions;

public interface IVeterinaryClinic
{
    public bool ApproveForZoo(Animal? animal);
}
