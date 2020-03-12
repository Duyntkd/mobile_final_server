using System;
using System.Linq;
using MobileFinalProjectServer.DataModels;

namespace MobileFinalProjectServer.Repositories
{
    public class UserRepository
    {
        private MyDbContext _context;

        public UserRepository(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }

        public User checkLogin(string username, string password)
        {
           User user =  _context.Users.Where(u => u.Username == username && u.Password == password).Select(u => new User {Username = u.Username, Role = u.Role, GroupId = u.GroupId, Status = u.Status, Phone = u.Phone, Id = u.Id}).SingleOrDefault();
           return user;
        }
    }
}
