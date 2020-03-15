using System;
namespace MobileFinalProjectServer.DataModels
{
    
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public User Manager { get; set; }

        public Group()
        {
        }
    }
}
