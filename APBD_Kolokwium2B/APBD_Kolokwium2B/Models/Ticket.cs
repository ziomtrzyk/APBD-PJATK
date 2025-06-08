using System.ComponentModel.DataAnnotations;

namespace APBD_Kolokwium2B.Models;

public class Ticket
{
    [Key]
    public int TicketId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string SerialNumber { get; set; }
    
    public int SeatNumber { get; set; }
    
    public ICollection<Ticket_Concert> TicketConcerts { get; set; } = new List<Ticket_Concert>();
    public ICollection<Purchased_Ticket> PurchasedTickets { get; set; } = new List<Purchased_Ticket>();
}