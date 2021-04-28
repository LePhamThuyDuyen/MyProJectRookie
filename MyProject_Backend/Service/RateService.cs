using Microsoft.AspNetCore.Http;
using MyProject_Backend.Data;
using MyProject_Backend.InterfaceService;
using MyProject_Backend.Models;
using ShareModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyProject_Backend.Service
{
    public class RateService: IRate
    {
        private readonly ApplicationDbContext _applicationDb;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RateService (ApplicationDbContext applicationDb, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDb = applicationDb;
            _httpContextAccessor = httpContextAccessor;
        }


        public async  Task<bool> CreateRate(RateShare rateShare)
        {
            var rates = new Rate { ProductId = rateShare.ProductId, Value = rateShare.value};

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            rates.UserId = userId.ToString();
            _applicationDb.Add(rates);
            await _applicationDb.SaveChangesAsync();
            return true;

        }
    }
}
