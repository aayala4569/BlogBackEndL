using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEndL.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogBackEndL.Services.Context
{
    public class DataContext : DbContext
    {

        public DbSet<UserModel> UserInfor {get; set;}

        public DbSet<BlogitemModel> BlogInfo {get; set;}
        public DataContext(DbContextOptions options) : base(options){

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}