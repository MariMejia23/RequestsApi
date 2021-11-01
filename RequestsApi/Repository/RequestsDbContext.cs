using Microsoft.EntityFrameworkCore;
using RequestsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestsApi.Repository
{
    public class RequestsDbContext : DbContext
    {
        public RequestsDbContext(DbContextOptions<RequestsDbContext> options)
              : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            modelBuilder.Entity<Person>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.HasMany(e => e.Requests).WithOne(e => e.Person);
                b.Property(x => x.Photo)
                .HasColumnType("varchar(max)");
            });
            modelBuilder.Entity<Request>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.HasOne(e => e.Person).WithMany(e => e.Requests).HasForeignKey(e => e.PersonId);
                b.HasOne(e => e.Status).WithMany(e => e.Requests).HasForeignKey(e => e.StatusId);
            });
            modelBuilder.Entity<Equipment>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Status>(b =>
            {
                b.HasData(
                    new Status
                    {
                       Id = 1,
                       Description = "Abiertas"
                    },
                    new Status
                    {
                        Id = 2,
                        Description = "Aprobadas"
                    }, 
                    new Status
                    {
                        Id = 3,
                        Description = "Canceladas"
                    }
                    );  
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}

