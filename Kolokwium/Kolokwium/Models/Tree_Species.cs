using System.ComponentModel.DataAnnotations;

namespace Kolokwium.Models;

public class Tree_Species
{
    [Key]
    public int SpeciesId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LatinName { get; set; }
    
    [Required]
    public int GrowthTimeInYears { get; set; }
    
    public ICollection<Seedling_Batch>? Batches { get; set; }
}