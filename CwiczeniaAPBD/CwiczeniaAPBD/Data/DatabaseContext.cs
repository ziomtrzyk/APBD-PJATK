using CwiczeniaAPBD.Models;
using Microsoft.EntityFrameworkCore;

namespace CwiczeniaAPBD.Data;

public class DatabaseContext : DbContext
{
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        ///================
        /*modelBuilder.Entity<Prescription_Medicament>()
            .HasKey(pm => new { pm.IdPrescription, pm.IdMedicament });

        
        modelBuilder.Entity<Prescription_Medicament>()
            .HasOne(pm => pm.Prescription)
            .WithMany(p => p.Prescription_Medicaments)
            .HasForeignKey(pm => pm.IdPrescription);

        modelBuilder.Entity<Prescription_Medicament>()
            .HasOne(pm => pm.Medicament)
            .WithMany(m => m.Prescription_Medicaments)
            .HasForeignKey(pm => pm.IdMedicament);*/
        ///================


        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                IdPatient = 1,
                FirstName = "Jan",
                LastName = "Kowalski",
                Birthdate = new DateTime(1980, 5, 15)
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Anna",
                LastName = "Nowak",
                Birthdate = new DateTime(1990, 3, 22)
            }
        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "Adam",
                LastName = "Lekarski",
                Email = "adam.lekarski@wp.com"
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "Ewa",
                LastName = "Medyczna",
                Email = "ewa.medyczna@wp.com"
            }
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                IdPrescription = 1,
                Date = new DateTime(2012, 1, 1),
                DueDate = new DateTime(2012, 1, 15),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = new DateTime(2012, 2, 1),
                DueDate = new DateTime(2012, 2, 15),
                IdPatient = 1,
                IdDoctor = 2
            },
            new Prescription
            {
                IdPrescription = 3,
                Date = new DateTime(2012, 3, 1),
                DueDate = new DateTime(2012, 3, 15),
                IdPatient = 2,
                IdDoctor = 1
            }
        );


    }
}