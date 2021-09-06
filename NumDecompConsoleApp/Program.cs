using System;
using NumDecomp.Domain.Models;
using NumDecomp.Domain.Core.Interfaces.Services;
using NumDecomp.Infra.CC.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace NumDecompConsoleApp
{
    static class Program
    {
        private static IServiceDecomposition _serviceDecomp;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = MInjector.GetProvider(serviceCollection);

            _serviceDecomp = serviceProvider.GetService<IServiceDecomposition>();

            StartMenu();
        }

        public static void StartMenu()
        {
            Console.WriteLine("Este programa irá decompor o número que será digitado e enumerará os primos.");
            Console.WriteLine("Digite um número para prosseguir: ");

            string entryNumber = Console.ReadLine();

            if (ValidateEntryNumber(entryNumber))
            {
                Decomposition decomp = new Decomposition();
                decomp.EntryNumber = int.Parse(entryNumber);

                MakeDecomposition(decomp);
                Console.Write("Os números divisores são: ");

                for (int x = 0; x < decomp.DividingNumbers.Count; x++)
                {
                    Console.Write(decomp.DividingNumbers[x] + " ");
                }

                if (decomp.PrimeNumbers.Count > 0)
                {
                    Console.Write("\r\nOs números primos são: ");

                    for (int x = 0; x < decomp.PrimeNumbers.Count; x++)
                    {
                        Console.Write(decomp.PrimeNumbers[x] + " ");
                    }
                } else
                {
                    Console.Write("\r\nSem divisores primos");
                }
            }
        }

        private static void MakeDecomposition(Decomposition decomp)
        {
            decomp.DividingNumbers = _serviceDecomp.GetDecomposition(decomp).Dividers;
            decomp.PrimeNumbers = _serviceDecomp.GetPrimes(decomp.DividingNumbers).Primes;
        }

        private static bool ValidateEntryNumber(string entryNumber)
        {
            if (!int.TryParse(entryNumber, out int number) || number <= 0)
            {
                Console.WriteLine("O número digitado é inválido para a operação que será executada.");
                return false;
            }

            return true;
        }
    }
}
