using NumDecomp.Domain.Core.Interfaces.Services;
using NumDecomp.App.DTO.DTO;
using NumDecomp.Domain.Models;
using System.Collections.Generic;
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
                {
                    throw new ArithmeticException("O número digitado é inválido para a operação que será executada.");
                }

                for (int x = 1; x <= Math.Sqrt(decomposition.EntryNumber); x++)
                {
                    if (decomposition.EntryNumber % x == 0)
                    {
                        returnRes.Dividers.Add(x);

                        if (x != decomposition.EntryNumber / x)
                        {
                            returnRes.Dividers.Add(decomposition.EntryNumber / x);
                        }
                    }
                }

                returnRes.Dividers.Sort();

                return returnRes;
            }
            catch (Exception ex)
            {
                returnRes.Error = ex.Message;
                return returnRes;
            }         
        }

        public DecompositionDTO GetPrimes(List<int> dividingNumbers)
        {
            DecompositionDTO returnRes = new DecompositionDTO();

            try
            {
                bool isPrime = true;

                for (int x = 0; x < dividingNumbers.Count; x++)
                {
                    if (dividingNumbers[x] == 2)
                    {
                        returnRes.Primes.Add(dividingNumbers[x]);
                    }

                    if (dividingNumbers[x] <= 1)
                    {
                        continue;
                    }

                    if (dividingNumbers[x] < 2 || (dividingNumbers[x] % 2 == 0))
                    {
                        continue;
                    }

                    for (int y = 3; y * y <= dividingNumbers[x]; y += 2)
                    {
                        if (dividingNumbers[x] % y == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        returnRes.Primes.Add(dividingNumbers[x]);
                    }
                }

                return returnRes;
            }
            catch (Exception ex)
            {
                returnRes.Error = ex.Message;
                return returnRes;
            }           
        }
    }
}
