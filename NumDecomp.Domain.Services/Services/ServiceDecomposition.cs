using NumDecomp.Domain.Core.Interfaces.Services;
using NumDecomp.App.DTO.DTO;
using NumDecomp.Domain.Models;
using System;

namespace NumDecomp.Domain.Services.Services
{
    public class ServiceDecomposition : IServiceDecomposition
    {
        public DecompositionDTO GetDecomposition(Decomposition decomposition)
        {
            DecompositionDTO returnRes = new DecompositionDTO();
            try
            {
                if (!int.TryParse(decomposition.EntryNumber.ToString(), out int number) || number <= 0)
                    throw new ArithmeticException("O número digitado é inválido para a operação que será executada.");

                AddDividersToList(returnRes, decomposition);
                AddPrimesToList(returnRes);

                return returnRes;
            }
            catch (Exception ex)
            {
                returnRes.Error = ex.Message;
                return returnRes;
            }
        }

        public void AddDividersToList(DecompositionDTO returnRes, Decomposition decomposition)
        {
            for (int x = 1; x <= Math.Sqrt(decomposition.EntryNumber); x++)
            {
                if (decomposition.EntryNumber % x == 0)
                {
                    returnRes.DividingNumbers.Add(x);
                    if (x != decomposition.EntryNumber / x) returnRes.DividingNumbers.Add(decomposition.EntryNumber / x);
                }
            }

            returnRes.DividingNumbers.Sort();
        }

        public void AddPrimesToList(DecompositionDTO returnRes)
        {
            foreach (int divider in returnRes.DividingNumbers)
                if (IsPrime(divider)) returnRes.PrimeNumbers.Add(divider);

            returnRes.PrimeNumbers.Sort();
        }

        public bool IsPrime(int n)
        {
            if (n == 2) return true;
            if (n < 2 || n % 2 == 0) return false;

            for (int x = 3; x * x <= n; x += 2)
                if (n % x == 0)
                    return false;

            return true;
        }
    }
}