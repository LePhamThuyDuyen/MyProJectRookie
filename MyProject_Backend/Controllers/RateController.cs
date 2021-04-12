using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject_Backend.InterfaceService;
using ShareModel;
using System.Threading.Tasks;

namespace MyProject_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RateController : ControllerBase
    {
        private readonly IRate _rate;
       

        public RateController(IRate rate)
        {
            _rate = rate;
          
        }

        [HttpPost]
         [Authorize("Bearer")]
        //[Authorize]
        public async Task<IActionResult> CreateRate(RateShare rateShare)
        {
            var result = await _rate.CreateRate(rateShare);
            return Ok(result);
        }
    }
}
