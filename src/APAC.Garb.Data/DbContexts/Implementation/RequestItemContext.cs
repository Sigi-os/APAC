using APAC.Garb.Data.Models.Definition.Common;
using Microsoft.EntityFrameworkCore;
using APAC.Garb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace APAC.Garb.Data.DbContexts.Implementations
{
    public class RequestItemContext:DbContext
    {       
        public DbSet<ILookup> RequestItems { get; set; }

        public RequestItemContext(DbContextOptions<RequestItemContext> options)
            :base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                  
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APAC.Garb.Data.Entities.Garb>().HasData(
                new APAC.Garb.Data.Entities.Garb
                { 
                     Active = true,
                     Description = "Shirt",
                     Id = 1,
                     TypeId = 1,
                     Name = "Shirt",
                },
                new APAC.Garb.Data.Entities.Garb
                {
                    Active = true,
                    Description = "Pants",
                    Id = 2,
                    TypeId = 2,
                    Name = "Pants",
                }
            );
           
        }
    }
}
