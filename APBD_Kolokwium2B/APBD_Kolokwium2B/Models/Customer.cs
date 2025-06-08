using System.ComponentModel.DataAnnotations;

namespace APBD_Kolokwium2B.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
    
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    
    public ICollection<Purchased_Ticket> PurchasedTickets { get; set; } = new List<Purchased_Ticket>();
}