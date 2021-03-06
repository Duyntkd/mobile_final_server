﻿using System;
using Microsoft.EntityFrameworkCore;

namespace MobileFinalProjectServer.DataModels
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }


    }
}
