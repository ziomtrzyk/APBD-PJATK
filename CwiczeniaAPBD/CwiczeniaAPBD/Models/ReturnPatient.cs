namespace CwiczeniaAPBD.Models;

public class ReturnPatient
{
    public Patient Patient { get; set; }
    
    public ICollection<Prescription>? Prescriptions { get; set; }
    
    public ICollection<Medicament>? Medicaments { get; set; }
    
    public ReturnPatient(Patient patient, List<Prescription> prescriptions, List<Medicament> medicaments)
    {
        Patient = patient;
        Prescriptions = prescriptions;
        Medicaments = medicaments;
    }
}