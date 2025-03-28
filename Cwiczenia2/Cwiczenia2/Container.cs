namespace Cwiczenia2;

public abstract class Container
{
    public double Weight{ get; set; }
    public double Height { get; set; }
    public double OwnWeight { get; set; }
    public double Depth { get; set; }
    public double MaxPayload { get; set; }
    public string SerialNumber { get; set; }
    
    static int SerialNumberCounter = 1;

    protected abstract string GetConteinerType();
    protected abstract double GetMaxFill();
    
    
    protected Container(double weight, double height, double ownWeight, double depth, double maxPayload)
    {
        Weight = weight;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        MaxPayload = maxPayload;
        SerialNumber = GenerateSerialNumber();
    }

    public virtual void UnloadCargo()
    {
        Weight = 0;
    }

    public void LoadCargo(double weight)
    {
        if(weight > (MaxPayload*GetMaxFill()))
            throw new OverfillException("The weight is greater than the max payload. This is an attempt to perform a dangerous operation.");
        Weight = weight;
    }

    private string GenerateSerialNumber()
    {
        return "KON-" + GetConteinerType()+"-"+SerialNumberCounter++;
    }
}