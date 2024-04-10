using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet <User> Users {get;set;}
        public DbSet <Massion> Massions{get;set;}

        public DbSet <SubMassion> SubMassions{get;set;}

        public DbSet<Tag> Tags {get;set;}
    }
}