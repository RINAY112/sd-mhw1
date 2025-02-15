using MHW1.Services.Abstractions;
using MHW1.Models.Animals;

namespace MHW1.Services;

public class VeterinaryClinic : IVeterinaryClinic
{
    public bool ApproveForZoo(Animal? animal) => animal?.IsHealthy ?? false;
}
