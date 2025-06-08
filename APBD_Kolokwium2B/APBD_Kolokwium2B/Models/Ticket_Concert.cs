using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_Kolokwium2B.Models;

[PrimaryKey(nameof(TicketId), nameof(ConcertId))]
public class Ticket_Concert
{
    public int TicketId { get; set; }
    
    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; }
    
    public int ConcertId { get; set; }
    
    [ForeignKey(nameof(ConcertId))]
    public Concert Concert { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
}