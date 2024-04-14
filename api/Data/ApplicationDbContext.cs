using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext:IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }
        public DbSet <User> Users {get;set;}
        public DbSet <Massion> Massions{get;set;}

        public DbSet <SubMassion> SubMassions{get;set;}

        public DbSet<Tag> Tags {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Name="Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Name="User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}