using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_Kolokwium2B.Models;

[PrimaryKey(nameof(TicketId), nameof(CustomerId))]
public class Purchased_Ticket
{
    public int TicketId { get; set; }
    
    [ForeignKey(nameof(TicketId))]
    public Ticket Ticket { get; set; }
    
    public int CustomerId { get; set; }
    
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; }
    
    [Required]
    public DateTime PurchaseDate { get; set; }
}