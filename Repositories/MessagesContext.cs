using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Repositories.MessagesContext;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories
{
    public class MessagesContext : DbContext
    {
        //Entitées
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ASPNetDemo;Integrated Security=True");
            //optionsBuilder.LogTo(Console.WriteLine);

            base.OnConfiguring(optionsBuilder);
        }

        // Données par défaut
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var m1 = new Message() { Id = 1, Contenu = "content default"  };
            var m2 = new Message() { Id = 2, Contenu = "content default 2"};

            modelBuilder.Entity<Message>().HasData(m1);
            modelBuilder.Entity<Message>().HasData(m2);

            base.OnModelCreating(modelBuilder);
        }


    }
}
