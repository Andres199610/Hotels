﻿using Hotel.Shared.Entities;
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
        }

    }
}