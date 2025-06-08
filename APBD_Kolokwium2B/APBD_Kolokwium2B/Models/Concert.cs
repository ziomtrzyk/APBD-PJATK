using System.ComponentModel.DataAnnotations;

namespace APBD_Kolokwium2B.Models;

public class Concert
{
    [Key]
    public int ConcertId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    public int AvailableTickets { get; set; }
    
    public ICollection<Ticket_Concert> TicketConcerts { get; set; } = new List<Ticket_Concert>();
}