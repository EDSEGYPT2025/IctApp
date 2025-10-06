using IctApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IctApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Stage> Stages { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<QuizQuestion> QuizQuestions { get; set; }
        public DbSet<QuizOption> QuizOptions { get; set; }
        public DbSet<GlossaryTerm> GlossaryTerms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Stage>().ToTable("Stages");
            modelBuilder.Entity<Grade>().ToTable("Grades");
            modelBuilder.Entity<Unit>().ToTable("Units");
            modelBuilder.Entity<Lesson>().ToTable("Lessons");
            modelBuilder.Entity<QuizQuestion>().ToTable("QuizQuestions");
            modelBuilder.Entity<QuizOption>().ToTable("QuizOptions");
            modelBuilder.Entity<GlossaryTerm>().ToTable("GlossaryTerms");
        }
    }
}

