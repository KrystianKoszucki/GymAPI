using Microsoft.EntityFrameworkCore;

namespace GymAPI.Models
{
    public class GymDbContext: DbContext
    {
        private readonly string _connectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=GymDb;Trusted_Connection=True;";
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<Exercise>()
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Training>()
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(25);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

        }


    }
}
