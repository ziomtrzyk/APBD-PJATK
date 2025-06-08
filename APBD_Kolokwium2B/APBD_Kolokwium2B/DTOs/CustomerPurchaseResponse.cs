namespace APBD_Kolokwium2B.DTOs;

public class CustomerPurchasesResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public List<PurchaseDto> Purchases { get; set; } = new List<PurchaseDto>();
}

public class PurchaseDto
{
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public TicketDto Ticket { get; set; }
    public ConcertDto Concert { get; set; }
}

public class TicketDto
{
    public string Serial { get; set; }
    public int SeatNumber { get; set; }
}

public class ConcertDto
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
}

// Request DTOs
public class CustomerWithPurchasesRequest
{
    public CustomerDto Customer { get; set; }
    public List<PurchaseRequestDto> Purchases { get; set; } = new List<PurchaseRequestDto>();
}

public class CustomerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
}

public class PurchaseRequestDto
{
    public int SeatNumber { get; set; }
    public string ConcertName { get; set; }
    public decimal Price { get; set; }
}