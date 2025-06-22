using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models;

public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    [Required]
    public DateTime EstablishedDate { get; set; }
    
    public ICollection<Seedling_Batch>? SeedlingBatches { get; set; }
}