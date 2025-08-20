using GeoQuiz.Models.QuizModels;
using GeoQuizBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoQuizBackend.EntityFramework
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        DbSet<Quiz> Quiz { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("TestDb")
                    .EnableSensitiveDataLogging()
                    .LogTo(Console.WriteLine, LogLevel.Information); // Logs to console
            }
        }
    }
} 