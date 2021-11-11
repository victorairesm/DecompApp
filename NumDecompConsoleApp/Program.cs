using System;
using NumDecomp.Domain.Models;
using NumDecomp.Domain.Core.Interfaces.Services;
using NumDecomp.Infra.CC.IOC;
using Microsoft.Extensions.DependencyInjection;

namespace NumDecompConsoleApp
{
    internal static class Program
    {
        private static IServiceDecomposition _serviceDecomp;

        private static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            var serviceProvider = MInjector.GetProvider(serviceCollection);

            _serviceDecomp = serviceProvider.GetService<IServiceDecomposition>();

            StartMenu();
        }

        public static void StartMenu()
        {
            Console.WriteLine("Este programa irá decompor o número que será digitado e enumerará os primos.");
            Console.WriteLine("\nDigite um número para prosseguir: ");

            string entryNumber = Console.ReadLine();

            if (ValidateEntryNumber(entryNumber))
            {
                Decomposition decomp = new Decomposition();
                decomp.EntryNumber = int.Parse(entryNumber);

                MakeDecomposition(decomp);

                PrintDividing(decomp);
                PrintPrimes(decomp);
            }
        }

        private static void PrintDividing(Decomposition decomp)
        {
            Console.Write("\nOs números divisores são: ");
            decomp.DividingNumbers.ForEach(i => Console.Write("\n{0}", i));
        }

        private static void PrintPrimes(Decomposition decomp)
        {
            if (decomp.PrimeNumbers.Count > 0)
            {
                Console.Write("\n\nOs números primos são: ");
                decomp.PrimeNumbers.ForEach(i => Console.Write("\n{0}", i));
            }
            else
            {
                Console.Write("\r\nSem divisores primos");
            }
        }

        private static void MakeDecomposition(Decomposition decomp)
        {
            var dto = _serviceDecomp.GetDecomposition(decomp);

            decomp.DividingNumbers = dto.DividingNumbers;
            decomp.PrimeNumbers = dto.PrimeNumbers;
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