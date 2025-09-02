using Microsoft.EntityFrameworkCore;
using QuizaphBackend.Models;
using QuizaphBackend.Models.QuizResults;

namespace GeoQuizBackend.EntityFramework
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<QuizResult>()
                .HasKey(q => new { q.UserId, q.QuizType, q.QuizMode });

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<QuizResult>()
                .HasOne(q => q.User)
                .WithMany(u => u.QuizResults)
                .HasForeignKey(q => q.UserId);
        }
    }
} 