using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WEBAPI.Models;

namespace WEBAPI.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Quote>()
                .HasData(
                    new Quote() { Id = 1, Author = "-'\'_|_/-", Text = "Если ты устал, то присять", InsertDate = DateTime.Now},
                    new Quote() { Id = 2, Author = "-'\'_|_/-", Text = "Если ты покушал, то делай свое дело", InsertDate = DateTime.Now},
                    new Quote() { Id = 3, Author = "-'\'_|_/-", Text = "Если ты не хочешь работать, то не работай", InsertDate = DateTime.Now},
                    new Quote() { Id = 4, Author = "-'\'_|_/-", Text = "Если ты хочешь пить, то открой кран и выпей", InsertDate = DateTime.Now},
                    new Quote() { Id = 5, Author = "-'\'_|_/-", Text = "Если ты хочешь есть, то открой холодильник", InsertDate = DateTime.Now}
                ) ;
        }

    }

}
