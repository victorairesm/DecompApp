using NumDecomp.Domain.Models;
using NumDecomp.Domain.Services.Services;
using System.Collections.Generic;
using Xunit;

namespace NumDecomp.Test
{
    public class DecompositionTest
    {
        [Fact]
        public void DecompositionUnitTest()
        {
            //Arrange
            ServiceDecomposition serviceDecomposition = new ServiceDecomposition();
            Decomposition divisor = new Decomposition
            {
                EntryNumber = 75
            };

            var expectedList = new List<int> { 1, 3, 5, 15, 25, 75 };

            //Act
            var result = serviceDecomposition.GetDecomposition(divisor);

            //Assert
            if (result.Dividers.Count > 0)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }

            Assert.Null(result.Error);
            Assert.Equal(expectedList, result.Dividers);
        }

        [Fact]
        public void PrimeUnitTest()
        {
            //Arrange
            ServiceDecomposition serviceDecomposition = new ServiceDecomposition();
            Decomposition divisor = new Decomposition
            {
                DividingNumbers = new List<int> { 1, 3, 5, 15, 25, 75 }
            };

            var expectedList = new List<int> { 3, 5 };

            //Act
            var result = serviceDecomposition.GetPrimes(divisor.DividingNumbers);

            //Assert
            if (result.Primes.Count > 0)
            {
                Assert.True(true);
            }
            else
            {
                Assert.True(false);
            }

            Assert.Null(result.Error);
            Assert.Equal(expectedList, result.Primes);
        }
    }
}
