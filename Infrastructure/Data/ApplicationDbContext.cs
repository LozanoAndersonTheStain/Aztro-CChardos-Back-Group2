using aztro_cchardos_back_group2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace aztro_cchardos_back_group2.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<QuestionEntity> Questions { get; set; } = null!;
        public DbSet<QuestionOptionEntity> QuestionOptions { get; set; } = null!;
        public DbSet<AnswerEntity> Answers { get; set; } = null!;
        public DbSet<CityEntity> Cities { get; set; } = null!;
        public DbSet<DestinationEntity> Destinations { get; set; } = null!;
        public DbSet<CombinationEntity> Combinations { get; set; } = null!;
        public DbSet<TravelPlanEntity> TravelPlans { get; set; } = null!;

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

            //* Configuración para Destination y sus relaciones
            modelBuilder.Entity<DestinationEntity>()
                .HasOne(d => d.FirstCity)
                .WithMany(c => c.FirstCityDestinations)
                .HasForeignKey(d => d.FirstCityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DestinationEntity>()
                .HasOne(d => d.SecondCity)
                .WithMany(c => c.SecondCityDestinations)
                .HasForeignKey(d => d.SecondCityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CityEntity>()
                .HasOne(c => c.TravelPlan)
                .WithMany()
                .HasForeignKey(c => c.TravelPlanId);
        }
    }
}