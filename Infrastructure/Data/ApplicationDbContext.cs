using aztro_cchardos_back_group2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<QuestionEntity> Questions { get; set; }
        public DbSet<QuestionOptionEntity> QuestionOptions { get; set; }
        public DbSet<AnswerEntity> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Id)
                .IsUnique();

            //* Configuración para Question y sus relaciones
            modelBuilder.Entity<QuestionEntity>()
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}