using Microsoft.EntityFrameworkCore;
using MyProject_Backend.Data;
using MyProject_Backend.InterfaceService;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_Backend.Service
{
    public class UserService : IUser
    {
        private readonly ApplicationDbContext _dbContext;

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var user = await _dbContext.Users.ToListAsync();
            return user;
        }
    }
}
