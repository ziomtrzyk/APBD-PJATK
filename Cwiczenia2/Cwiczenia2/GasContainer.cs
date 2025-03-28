namespace Cwiczenia2;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double weight, double height, double ownWeight, double depth, double maxPayload, double pressure) : base(weight, height, ownWeight, depth, maxPayload)
    {
        this.pressure = pressure;
    }

    public double pressure { get; set; }

    protected override string GetConteinerType() => "G";

    protected override double GetMaxFill() => 1.0;

    public override void UnloadCargo()
    {
        Weight = Weight*0.05;
    }

    public void NotifyHazard()
    {
        Console.WriteLine("There is a dangerous situation now. "+SerialNumber);
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"     Type: Gas, Pressure: {pressure} atm");
    }
}