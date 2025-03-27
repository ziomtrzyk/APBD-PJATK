namespace Cwiczenia2;

public abstract class Cointeiner
{
    public double Weight{ get; set; }
    public double Height { get; set; }
    public double OwnWeight { get; set; }
    public double Depth { get; set; }
    public double MaxPayload { get; set; }
    public string SerialNubmer { get; set; }

    public void UnloadCargo()
    {
        Weight = 0;
    }

    public void LoadCargo(double weight)
    {
        if(weight > MaxPayload)
            throw new OverfillException("The weight is greater than the max payload.");
        Weight = weight;
    }
}