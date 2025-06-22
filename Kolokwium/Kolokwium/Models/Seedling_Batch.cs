using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium.Models;

public class Seedling_Batch
{
    [Key]
    public int BatchId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public DateTime SownDate { get; set; }
    
    [Required]
    public DateTime ReadyDate { get; set; }
    
    public int SpeciesId { get; set; }
    
    [ForeignKey(nameof(SpeciesId))]
    public Tree_Species? Species { get; set; }
    
    public int NurseryId { get; set; }
    
    [ForeignKey(nameof(NurseryId))]
    public Nursery? Nursery { get; set; }
    
    public ICollection<Responsible>? Responsible { get; set; }
}