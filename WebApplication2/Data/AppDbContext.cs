using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data.Configurations;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore.Proxies;
using WebApplication2.Models.Annoucements;

namespace WebApplication2.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //base.OnConfiguring(optionsBuilder.UseLazyLoadingProxies());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Town>(new TownConfiguration());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration<Annoucement>(new AnnoucementConfiguration());
            modelBuilder.ApplyConfiguration<VehicleAnnoucement>(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration<Message>(new MessageConfiguration());
            //modelBuilder.ApplyConfiguration<Chat>(new ChatConfiguration());
            modelBuilder.ApplyConfiguration<UserProfile>(new UserProfileConfiguration());
            modelBuilder.Entity<VehicleAnnoucement>();
            modelBuilder.Entity<ElectronicsAnnoucement>();
            modelBuilder.Entity<ClothesAnnoucement>();

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Annoucement> Annoucements { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        //public DbSet<Chat> Chats { get; set; }
        //public DbSet<MessageSent> MessagesSent { get; set; }
        //public DbSet<MessageRecieved> MessagesRecieved { get; set; }
        
    }
}
