using TuProyecto.Models;
using System.Collections.Generic;
using System.Linq;

namespace TuProyecto.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "password" },
            new User { Id = 2, Username = "testuser", Password = "password123" }
        };

        public User GetUser(string username, string password)
        {
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}