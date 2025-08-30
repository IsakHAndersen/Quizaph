using GeoQuiz.Models.QuizModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizaphBackend.Models;
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
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizCompletion> QuizCompletions { get; set; }

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