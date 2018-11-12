using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MRPSystemBackend.API.User
{
    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { UserName = "Test", Company = "Life", Password = "test" },
             new User { UserName = "tda", Company = "Life",  Password = "tda" }

        };

        public async Task<User> Authenticate(string username, string password,string company)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.UserName == username && x.Password == password && x.Company==company));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            // return users without passwords
            return await Task.Run(() => _users.Select(x => {
                x.Password = null;
                return x;
            }));
        }
    }
}
