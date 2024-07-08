using Microsoft.EntityFrameworkCore;

namespace cs208.Models
{
    // Context for working with the connected database
    public class Context : DbContext
    {
        public DbSet<DogModel> Dogs { get; set; }
        public DbSet<ShelterModel> Shelters { get; set; }

        // Specify 1:N relationship between Dogs and Shelters tables and data constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DogModel>()
                .HasOne(d => d.Shelter)
                .WithMany(s => s.Dogs)
                .HasForeignKey(d => d.ShelterId);

            modelBuilder.Entity<DogModel>().Property(d => d.Name).HasMaxLength(50);
            modelBuilder.Entity<DogModel>().ToTable(t => t.HasCheckConstraint("Ck_DogModel_Name", "LEN(Name) <= 50"));
            modelBuilder.Entity<DogModel>().Property(d => d.Breed).HasMaxLength(50);
            modelBuilder.Entity<DogModel>().ToTable(t => t.HasCheckConstraint("CK_DogModel_Sex", "[Sex] IN ('M', 'F')"));
            modelBuilder.Entity<DogModel>().ToTable(t => t.HasCheckConstraint("CK_DogModel_Age", "[Age] >= 0"));
            modelBuilder.Entity<DogModel>().Property(d => d.Description).HasMaxLength(250);

            modelBuilder.Entity<ShelterModel>().Property(s => s.Name).HasMaxLength(50);
            modelBuilder.Entity<ShelterModel>().Property(s => s.Street).HasMaxLength(50);
            modelBuilder.Entity<ShelterModel>().Property(s => s.HouseNo).HasMaxLength(10);
            modelBuilder.Entity<ShelterModel>().Property(s => s.ZipCode).HasMaxLength(5).IsFixedLength();
            modelBuilder.Entity<ShelterModel>().Property(s => s.City).HasMaxLength(50);
            modelBuilder.Entity<ShelterModel>().Property(s => s.Country).HasMaxLength(50);
            modelBuilder.Entity<ShelterModel>().Property(s => s.Phone).HasMaxLength(15);
            modelBuilder.Entity<ShelterModel>().Property(s => s.Email).HasMaxLength(320);
            modelBuilder.Entity<ShelterModel>().Property(s => s.Description).HasMaxLength(250);
    }

        // Configure connection to the SQL server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=SheltersAndDogs");
        }
    }
}
