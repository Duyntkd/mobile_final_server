using System;
namespace MobileFinalProjectServer.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public int RoleId { get; set; }
        public int GroupId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }


        public User()
        {
        }
    }
}
