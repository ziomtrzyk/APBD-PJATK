namespace Cwiczenia2;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double weight, double height, double ownWeight, double depth, double maxPayload, bool isDangerous) : base(weight, height, ownWeight, depth, maxPayload)
    {
        this.isDangerous = isDangerous;
    }

    public bool isDangerous{ get; set; }
    public double GetMaxFill() => isDangerous ? 0.5 : 0.9;

    protected override string GetConteinerType()
    {
        return "L";
    }

    public override void LoadCargo(double weight)
    {
        if(weight > (GetMaxFill()*MaxPayload))
            throw new OverfillException("The weight is greater than the max payload. This is an attempt to perform a dangerous operation.");
        Weight = weight;
    }

    public void NotifyHazard()
    {
        Console.WriteLine("There is a dangerous situation now. "+SerialNumber);
    }
}