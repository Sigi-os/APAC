using APAC.Garb.Data.Models.Definition.Common;
using Microsoft.EntityFrameworkCore;
using APAC.Garb;
using System;
using System.Collections.Generic;
using System.Text;

namespace APAC.Garb.Data.DbContexts
{
    public class RequestItemContext:DbContext
    {
        public DbSet<ILookup> RequestItems { get; set; }

        public RequestItemContext(DbContextOptions<RequestItemContext> options)
            :base(options)
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
                }
            );
           
        }
    }
}
