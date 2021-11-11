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

            var DividingExpectedList = new List<int> { 1, 3, 5, 15, 25, 75 };
            var PrimesExpectedList = new List<int> { 3, 5 };

            //Act
            var result = serviceDecomposition.GetDecomposition(divisor);

            //Assert
            Assert.True(result.DividingNumbers.Count > 0);
            Assert.Null(result.Error);
            Assert.Equal(DividingExpectedList, result.DividingNumbers);
            Assert.Equal(PrimesExpectedList, result.PrimeNumbers);
        }
    }
}