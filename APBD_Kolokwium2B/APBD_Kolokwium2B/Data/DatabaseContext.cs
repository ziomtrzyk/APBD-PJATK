
using APBD_Kolokwium2B.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_Kolokwium2B.Data;

public class DatabaseContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Ticket_Concert> Ticket_Concerts { get; set; }
    public DbSet<Purchased_Ticket> Purchased_Tickets { get; set; }
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
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
        
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                CustomerId = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "589437534"
            },
            new Customer
            {
                CustomerId = 2,
                FirstName = "Jane",
                LastName = "Smith",
                PhoneNumber = "5483975834"
            }
        );
        
        modelBuilder.Entity<Concert>().HasData(
            new Concert
            {
                ConcertId = 1,
                Name = "Concert 1",
                Date = new DateTime(2025, 6, 7, 9, 0, 0),
                AvailableTickets = 100
            },
            new Concert
            {
                ConcertId = 2,
                Name = "Concert 2",
                Date = new DateTime(2025, 6, 10, 9, 0, 0),
                AvailableTickets = 150
            }
        );
        
        modelBuilder.Entity<Ticket>().HasData(
            new Ticket
            {
                TicketId = 1,
                SerialNumber = "s1231",
                SeatNumber = 124
            },
            new Ticket
            {
                TicketId = 2,
                SerialNumber = "s5453",
                SeatNumber = 330
            },
            new Ticket
            {
                TicketId = 3,
                SerialNumber = "s5444",
                SeatNumber = 125
            }
        );
        
        modelBuilder.Entity<Ticket_Concert>().HasData(
            new Ticket_Concert
            {
                TicketId = 1,
                ConcertId = 1,
                Price = 33.4m
            },
            new Ticket_Concert
            {
                TicketId = 2,
                ConcertId = 2,
                Price = 48.4m
            },
            new Ticket_Concert
            {
                TicketId = 3,
                ConcertId = 1,
                Price = 32.4m
            }
        );
        
        modelBuilder.Entity<Purchased_Ticket>().HasData(
            new Purchased_Ticket
            {
                TicketId = 1,
                CustomerId = 1,
                PurchaseDate = new DateTime(2025, 6, 3, 9, 0, 0)
            },
            new Purchased_Ticket
            {
                TicketId = 2,
                CustomerId = 1,
                PurchaseDate = new DateTime(2025, 6, 3, 9, 0, 0)
            }
        );
    }
}