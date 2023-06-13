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
        public string _SqlConnectionString;

        public DbSet<Users> Users { get; set; }
        public DbSet<TypeUser> TypeUser { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TypeTicket> TypeTicket { get; set; }

        

        public DataStoreDbContext(string str)
        {
            _SqlConnectionString = str;
            Database.EnsureCreated();
        }

        //todo: написать конфигурацию приложения.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_SqlConnectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Tickets>().ToTable("Tickets");
            modelBuilder.Entity<TypeTicket>().ToTable("TypeTicket");

            //todo modelbuilder

            modelBuilder.Entity<TypeUser>().HasData(
                new TypeUser[]
                {
                    new TypeUser{Id = 1 ,Type="Клиент"},
                    new TypeUser{Id = 2 ,Type="Сотрудник"}
                });

            modelBuilder.Entity<Users>()
                .HasMany(u => u.ClientTickets)
                .WithOne(t => t.Client)
                .HasForeignKey(t => t.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Users>()
                .HasMany(u => u.SpecialistTickets)
                .WithOne(t => t.Specialist)
                .HasForeignKey(t => t.AssignedTo)
                .OnDelete(DeleteBehavior.Restrict);

            
                

            /*
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

