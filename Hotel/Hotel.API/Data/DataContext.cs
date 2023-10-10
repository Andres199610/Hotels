using Hotel.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Hotel.API.Data
{
    public class DataContext:DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }

        public DbSet<Cancellation> Cancellations { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            modelBuilder.Entity<State>().HasIndex("CountryId", "Name").IsUnique();
            modelBuilder.Entity<City>().HasIndex("StateId", "Name").IsUnique();
            modelBuilder.Entity<Room>().HasIndex("RoomId", "Name").IsUnique();
            modelBuilder.Entity<Cancellation>().HasIndex("CancellationId", "Name").IsUnique();
            modelBuilder.Entity<RoomImage>().HasIndex("RoomImageId", "Name").IsUnique();
            modelBuilder.Entity<Company>().HasIndex("CompanyId", "Name").IsUnique();
            modelBuilder.Entity<Booking>().HasIndex("BookingId", "Name").IsUnique();

            modelBuilder.Entity<ServiceType>().HasIndex("ServiceTypeId", "Name").IsUnique();
        }

    }
}
