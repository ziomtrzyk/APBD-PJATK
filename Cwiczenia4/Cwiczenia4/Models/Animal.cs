using System.ComponentModel.DataAnnotations;

namespace Cwiczenia4.Models;

public class Animal
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public int Weight { get; set; }
    [Required]
    public string Color { get; set; }
}