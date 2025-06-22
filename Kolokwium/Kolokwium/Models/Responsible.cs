using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.Models;

[PrimaryKey(nameof(BatchId), nameof(EmployeeId))]
public class Responsible
{
    public int BatchId { get; set; }
    
    [ForeignKey(nameof(BatchId))]
    public Seedling_Batch? Batch { get; set; }
    
    public int EmployeeId { get; set; }
    
    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Role { get; set; }
}