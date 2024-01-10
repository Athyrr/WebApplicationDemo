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
        public MessagesContext(DbContextOptions<MessagesContext> dbContextOptions) : base(dbContextOptions) { }
   
        //Entitées
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(Console.WriteLine);

            base.OnConfiguring(optionsBuilder);
        }

        // Données par défaut
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Message> messages = new List<Message>()
            {
                new Message()
                {
                    Id = 1,
                    Contenu = "Contenu 1",
                    Date = "01/01/2000",
                    Emeteur = "Emet 1"
                }
                ,new Message()
                {
                    Id = 2,
                    Contenu = "Contenu 2",
                    Date = "02/02/2010",
                    Emeteur = "Emet 2"
                }
                ,new Message()
                {
                    Id = 3,
                    Contenu = "Contenu 3",
                    Date = "03/03/2020",
                    Emeteur = "Emet 3"
                }
            };

            modelBuilder.Entity<Message>().HasData(messages);
            
            base.OnModelCreating(modelBuilder);
        }


    }
}
