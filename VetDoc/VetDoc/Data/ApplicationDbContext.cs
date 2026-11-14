using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetDoc.Models;

namespace VetDoc.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Appointment>()
                .HasIndex(a => new { a.VetId, a.StartTime })
                .IsUnique()
                .HasFilter("[IsCancelled] = 0");

            builder.Entity<Appointment>()
                .HasOne(a => a.Vet)
                .WithMany(v => v.Appointments)
                .HasForeignKey(a => a.VetId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Pet)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PetId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedRoles(builder);
            SeedClinics(builder);
            SeedVets(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "1" },
                new IdentityRole { Id = "2", Name = "Vet", NormalizedName = "VET", ConcurrencyStamp = "2" },
                new IdentityRole { Id = "3", Name = "Owner", NormalizedName = "OWNER", ConcurrencyStamp = "3" }
            );
        }

        private static void SeedClinics(ModelBuilder builder)
        {
            builder.Entity<Clinic>().HasData(
                new Clinic { Id = 1, Name = "Ветклиника Здраве", City = "София", Address = "ул. Витоша 15", Phone = "0888100100" },
                new Clinic { Id = 2, Name = "Ветклиника Лапичка", City = "Пловдив", Address = "бул. Марица 22", Phone = "0888200200" },
                new Clinic { Id = 3, Name = "Ветклиника Морско", City = "Варна", Address = "ул. Приморска 8", Phone = "0888300300" },
                new Clinic { Id = 4, Name = "Ветклиника Св. Франциск", City = "Бургас", Address = "ул. Александровска 40", Phone = "0888400400" },
                new Clinic { Id = 5, Name = "Ветклиника Дунав", City = "Русе", Address = "ул. Борисова 12", Phone = "0888500500" }
            );
        }

        private static void SeedVets(ModelBuilder builder)
        {
            builder.Entity<Vet>().HasData(
                new Vet { Id = 1, FirstName = "Иван", LastName = "Петров", Specialty = "Обща медицина", AnimalTypes = "Кучета, Котки",
                          WorkStart = new TimeSpan(9, 0, 0), WorkEnd = new TimeSpan(17, 0, 0), ClinicId = 1 },
                new Vet { Id = 2, FirstName = "Мария", LastName = "Георгиева", Specialty = "Хирургия", AnimalTypes = "Кучета, Котки",
                          WorkStart = new TimeSpan(10, 0, 0), WorkEnd = new TimeSpan(18, 0, 0), ClinicId = 1 },
                new Vet { Id = 3, FirstName = "Георги", LastName = "Димитров", Specialty = "Дерматология", AnimalTypes = "Кучета, Котки",
                          WorkStart = new TimeSpan(9, 0, 0), WorkEnd = new TimeSpan(15, 0, 0), ClinicId = 2 },
                new Vet { Id = 4, FirstName = "Елена", LastName = "Николова", Specialty = "Екзотични животни", AnimalTypes = "Птици, Гризачи, Влечуги",
                          WorkStart = new TimeSpan(11, 0, 0), WorkEnd = new TimeSpan(19, 0, 0), ClinicId = 3 },
                new Vet { Id = 5, FirstName = "Петър", LastName = "Стоянов", Specialty = "Обща медицина", AnimalTypes = "Кучета, Котки, Зайци",
                          WorkStart = new TimeSpan(8, 0, 0), WorkEnd = new TimeSpan(16, 0, 0), ClinicId = 4 },
                new Vet { Id = 6, FirstName = "Десислава", LastName = "Иванова", Specialty = "Дентална медицина", AnimalTypes = "Кучета, Котки",
                          WorkStart = new TimeSpan(9, 0, 0), WorkEnd = new TimeSpan(17, 0, 0), ClinicId = 5 }
            );
        }
    }
}
