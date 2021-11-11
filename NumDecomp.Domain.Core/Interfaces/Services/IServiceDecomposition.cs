using NumDecomp.Domain.Models;
using NumDecomp.App.DTO.DTO;

namespace NumDecomp.Domain.Core.Interfaces.Services
{
    public interface IServiceDecomposition
    {
        DecompositionDTO GetDecomposition(Decomposition decomposition);
    }
}