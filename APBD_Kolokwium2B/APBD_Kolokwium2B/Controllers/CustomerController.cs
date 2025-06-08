using APBD_Kolokwium2B.Data;
using APBD_Kolokwium2B.DTOs;
using APBD_Kolokwium2B.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APBD_Kolokwium2B.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly DatabaseContext _context;

    public CustomersController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet("{customerId}/purchases")]
    public async Task<ActionResult> GetCustomerPurchases(int customerId)
    {
        var customer = await _context.Customers
            .Include(c => c.PurchasedTickets)
                .ThenInclude(pt => pt.Ticket)
                    .ThenInclude(t => t.TicketConcerts)
                        .ThenInclude(tc => tc.Concert)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        var result = new CustomerPurchasesResponse
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = new List<PurchaseDto>()
        };

        foreach (var pt in customer.PurchasedTickets)
        {
            var purchase = new PurchaseDto
            {
                Date = pt.PurchaseDate,
                Price = pt.Ticket.TicketConcerts.First().Price,
                Ticket = new TicketDto
                {
                    Serial = pt.Ticket.SerialNumber,
                    SeatNumber = pt.Ticket.SeatNumber
                },
                Concert = new ConcertDto
                {
                    Name = pt.Ticket.TicketConcerts.First().Concert.Name,
                    Date = pt.Ticket.TicketConcerts.First().Concert.Date
                }
            };
            result.Purchases.Add(purchase);
        }

        return Ok(result);
    }
}