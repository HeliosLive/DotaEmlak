using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmlakProjesi.Models
{
    public class AdvertContext:DbContext
    {
        public DbSet<Advert> Tbl_Advert { get; set; }
        public DbSet<City> Tbl_City { get; set; }
        public DbSet<District> Tbl_District { get; set; }
        public DbSet<AdvertType> Tbl_AdvertType { get; set; }
        public DbSet<Heating> Tbl_Heating { get; set; }
        public DbSet<Image> Tbl_Image { get; set; }
        public DbSet<PropertyType> Tbl_PropertyType { get; set; }
        public DbSet<Qualification> Tbl_Qualification { get; set; }
        public DbSet<Room> Tbl_Room { get; set; }
        public DbSet<User> Tbl_User { get; set; }
        public DbSet<SellingType> Tbl_SellingType { get; set; }
        public DbSet<UserRole> Tbl_UserRole { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Advert>().HasMany(i => i.User).WithRequired().WillCascadeOnDelete(false);
        //}
    }
}