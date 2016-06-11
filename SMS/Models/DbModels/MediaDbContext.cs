using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using SMS.Models.MediaModels;

namespace SMS.Models.DbModels
{
    public class MediaDbContext : DbContext
    {
        public MediaDbContext() :base("MediaDbConnection")
        {
            
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
     
        public DbSet<Image> Images { get; set; }

        public static MediaDbContext Create()
        {
            return new MediaDbContext();
        }
    }
}