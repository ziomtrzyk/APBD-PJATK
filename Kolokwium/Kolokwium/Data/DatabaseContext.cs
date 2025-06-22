using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Nursery> Nurseries { get; set; }
    public DbSet<Tree_Species> Tree_Species { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Seedling_Batch> Seedling_Batches { get; set; }
    public DbSet<Responsible> Responsibles { get; set; }
    
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
        
        modelBuilder.Entity<Seedling_Batch>()
            .HasOne(sb => sb.Species)
            .WithMany(s => s.Batches)
            .HasForeignKey(sb => sb.SpeciesId);
            
        modelBuilder.Entity<Seedling_Batch>()
            .HasOne(sb => sb.Nursery)
            .WithMany(n => n.SeedlingBatches)
            .HasForeignKey(sb => sb.NurseryId);
            
        modelBuilder.Entity<Responsible>()
            .HasOne(r => r.Batch)
            .WithMany(sb => sb.Responsible)
            .HasForeignKey(r => r.BatchId);
            
        modelBuilder.Entity<Responsible>()
            .HasOne(r => r.Employee)
            .WithMany(e => e.Responsibilities)
            .HasForeignKey(r => r.EmployeeId);
        
        modelBuilder.Entity<Nursery>().HasData(
            new Nursery
            {
                NurseryId = 1,
                Name = "Green Forest",
                EstablishedDate = new DateTime(2000, 1, 1)
            },
            new Nursery
            {
                NurseryId = 2,
                Name = "Mountain Trees",
                EstablishedDate = new DateTime(2010, 2, 2)
            }
        );

        modelBuilder.Entity<Tree_Species>().HasData(
            new Tree_Species
            {
                SpeciesId = 1,
                LatinName = "Quercus robur",
                GrowthTimeInYears = 5
            },
            new Tree_Species
            {
                SpeciesId = 2,
                LatinName = "Pinus sylvestris",
                GrowthTimeInYears = 3
            }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                EmployeeId = 1,
                FirstName = "Anna",
                LastName = "Kowalska",
                HireDate = new DateTime(2020, 1, 15)
            },
            new Employee
            {
                EmployeeId = 2,
                FirstName = "Jan",
                LastName = "Nowak",
                HireDate = new DateTime(2019, 6, 10)
            }
        );

        modelBuilder.Entity<Seedling_Batch>().HasData(
            new Seedling_Batch
            {
                BatchId = 1,
                Quantity = 100,
                SownDate = new DateTime(2015, 5, 25),
                ReadyDate = new DateTime(2016, 2, 15),
                SpeciesId = 1,
                NurseryId = 1
            },
            new Seedling_Batch
            {
                BatchId = 2,
                Quantity = 200,
                SownDate = new DateTime(2020, 4, 19),
                ReadyDate = new DateTime(2025, 6, 12),
                SpeciesId = 2,
                NurseryId = 1
            }
        );

        modelBuilder.Entity<Responsible>().HasData(
            new Responsible
            {
                BatchId = 1,
                EmployeeId = 1,
                Role = "Supervisor"
            },
            new Responsible
            {
                BatchId = 1,
                EmployeeId = 2,
                Role = "Planter"
            },
            new Responsible
            {
                BatchId = 2,
                EmployeeId = 2,
                Role = "Supervisor"
            }
        );
    }
}