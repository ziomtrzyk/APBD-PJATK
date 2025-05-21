using System.ComponentModel.DataAnnotations;

namespace Cwiczenia4.Models;

public class Visit
{
    [Required]
    public int Id { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public int  AnimalId { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Price { get; set; }
}