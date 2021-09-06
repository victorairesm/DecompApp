using NumDecomp.Domain.Models;
using NumDecomp.App.DTO.DTO;
using System.Collections.Generic;

namespace NumDecomp.Domain.Core.Interfaces.Services
{
    public interface IServiceDecomposition
    {
        DecompositionDTO GetDecomposition(Decomposition decomposition);
        DecompositionDTO GetPrimes(List<int> dividingNumbers);
    }
}
