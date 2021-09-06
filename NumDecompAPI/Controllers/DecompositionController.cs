using Microsoft.AspNetCore.Mvc;
using NumDecomp.Domain.Models;
using NumDecomp.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace NumDecompAPI.Controllers
{
    [Route("NumDecompAPI/[controller]")]
    [ApiController]
    public class DecompositionController : ControllerBase
    {
        private readonly IServiceDecomposition _serviceDecomp;

        public DecompositionController(IServiceDecomposition divisorService)
        {
            _serviceDecomp = divisorService;
        }

        [HttpGet("{entryNumber}", Name = "Get")]
        public ActionResult<IList<long>> GetDecomposition(int entryNumber)
        {
            Decomposition decomp = new Decomposition
            {
                EntryNumber = entryNumber
            };

            var result = _serviceDecomp.GetDecomposition(decomp);
            result.Primes = _serviceDecomp.GetPrimes(result.Dividers).Primes;

            if (result.Dividers.Count > 0)
            {
                return Ok(result);
            } else
            {
                return BadRequest(result);
            }
        }
    }
}
