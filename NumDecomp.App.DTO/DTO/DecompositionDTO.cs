using System.Collections.Generic;

namespace NumDecomp.App.DTO.DTO
{
    public class DecompositionDTO
    {
        public List<int> Dividers { get; set; }
        public List<int> Primes { get; set; }
        public string Error { get; set; }

        public DecompositionDTO()
        {
            Dividers = new List<int>();
            Primes = new List<int>();
        }
    }   
}
