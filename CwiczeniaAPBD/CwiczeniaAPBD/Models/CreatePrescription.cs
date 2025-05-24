namespace CwiczeniaAPBD.Models;

public class CreatePrescription
{
    public Patient Patient { get; set; }
    
    public Doctor Doctor { get; set; }
    
    public ICollection<Medicament>? Medicaments { get; set; }

    public DateTime Date { get; set; }//pr

    public DateTime DueDate { get; set; }//pr

    public int ?Dose { get; set; }//pm

    public string Details { get; set; }//pm
    
}