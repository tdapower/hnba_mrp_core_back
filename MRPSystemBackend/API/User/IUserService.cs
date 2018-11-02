using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.User
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password,string company);
        Task<IEnumerable<User>> GetAll();
    }
}
