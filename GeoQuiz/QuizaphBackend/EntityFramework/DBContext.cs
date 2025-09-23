using Microsoft.EntityFrameworkCore;
using QuizaphBackend.Models;

namespace GeoQuizBackend.EntityFramework
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Quiz> Quizzes { get; set; } = default!;
        public DbSet<QuizResult> QuizResults { get; set; } = default!;
        public DbSet<QuizRule> QuizRules { get; set; } = default!;
        public DbSet<QuizRating> QuizRatings { get; set; } = default!;
        public DbSet<QuizDataset> QuizDatasets { get; set; } = default!;
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = default!;
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
                .HasKey(q => q.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<QuizResult>()
                .HasOne(q => q.User)
                .WithMany(u => u.QuizResults)
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<QuizQuestion>()
                .HasOne(q => q.QuizDataset)
                .WithMany(ds => ds.Questions)
                .HasForeignKey(q => q.QuizDataSetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}