using PrescriptionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace PrescriptionApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.IdDoctor);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany(pat => pat.Prescriptions)
                .HasForeignKey(p => p.IdPatient);

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdMedicament);

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdPrescription);

           

            modelBuilder.Entity<Doctor>().HasData(new Doctor
            {
                IdDoctor = 1,
                FirstName = "Oleh",
                LastName = "Koval",
                Email = "oleh.koval@example.com"
            });

            modelBuilder.Entity<Patient>().HasData(new Patient
            {
                IdPatient = 1,
                FirstName = "Iryna",
                LastName = "Melnyk",
                BirthDate = new DateTime(1992, 6, 10)
            });

            modelBuilder.Entity<Medicament>().HasData(
                new Medicament
                {
                    IdMedicament = 1,
                    Name = "Analgin",
                    Type = "Painkiller",
                    Description = "Relieves moderate pain"
                },
                new Medicament
                {
                    IdMedicament = 2,
                    Name = "Zitromax",
                    Type = "Antibiotic",
                    Description = "Used for respiratory infections"
                },
                new Medicament
                {
                    IdMedicament = 3,
                    Name = "Fenkarol",
                    Type = "Antihistamine",
                    Description = "Used for allergies"
                }
            );

            modelBuilder.Entity<Prescription>().HasData(new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2025, 5, 25),
                DueDate = new DateTime(2025, 6, 5),
                IdDoctor = 1,
                IdPatient = 1
            });

            modelBuilder.Entity<PrescriptionMedicament>().HasData(
                new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 1,
                    Dose = 1,
                    Details = "Take twice a day after meal"
                },
                new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 2,
                    Dose = 2,
                    Details = "Once a day in the morning"
                }
            );
        }
    }
}
