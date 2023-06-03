using Microsoft.EntityFrameworkCore;
using MinimalWebApiHelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerAppHelpDesk.DataBase
{
    public class DataStoreDbContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Specialists> Specialists { get; set; }
        public DbSet<TypeTicket> TypeTicket { get; set; }

        public DataStoreDbContext()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L93R2E4;Database=HDDataBase;Trusted_Connection=True;TrustServerCertificate=True");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>().ToTable("Clients");
            modelBuilder.Entity<Tickets>().ToTable("Tickets");
            modelBuilder.Entity<Specialists>().ToTable("Specialists");
            
            //todo modelbuilder


            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.Client)
                .WithMany(c => c.Tickets)
                .HasForeignKey(t => t.ClientId);

            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.AssignedSpecialist)
                .WithMany(s => s.AssignedTickets)
                .HasForeignKey(t => t.AssignedTo);

             /**/
        }
       
    }
}

