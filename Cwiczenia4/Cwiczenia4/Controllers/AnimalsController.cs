using Cwiczenia4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia4.Controllers;

[ApiController] 
[Route("api/[controller]")]
public class AnimalsController : ControllerBase
{
    
    public AnimalsController()
    {
        // DataStore._animals.Add(new Animal{Id = 1, Color = "red", Weight = 7, Name = "rafal"});
        // DataStore._animals.Add(new Animal{Id = 2, Color = "blue", Weight = 10, Name="Basia"});
        // DataStore._animals.Add(new Animal{Id = 3, Color = "black", Weight = 8, Name="Lala"});
    }
    
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(DataStore._animals);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetAnimals(int id)
    {
        var animal = DataStore._animals.FirstOrDefault(a => a.Id == id);
        return Ok(animal);
    }
    
    [HttpPost]
    public IActionResult InsertAnimal(Animal animal)
    {
        DataStore._animals.Add(animal);
        return Ok(DataStore._animals);
    }
    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animalUpdated)
    {
        var animal = DataStore._animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound();
        
        animal.Name = animalUpdated.Name;
        animal.Category = animalUpdated.Category;
        animal.Weight = animalUpdated.Weight;
        animal.Color = animalUpdated.Color;
        
        return Ok(DataStore._animals);
    }
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = DataStore._animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
            return NotFound();
        DataStore._animals.Remove(animal);
        DataStore._visits.RemoveAll(v => v.AnimalId == id);
        return Ok(DataStore._animals);
    }

    //[HttpGet("search")]
    [HttpGet("{name}")]
    public IActionResult SearchAnimals(string name)
    {
        var animals = DataStore._animals.Where(a => a.Name.ToLower().Contains(name.ToLower()));
        return Ok(animals);
    }
}