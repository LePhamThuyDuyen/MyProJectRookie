using ShareModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject_Backend.InterfaceService
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAllUserAsync();
    }
}
