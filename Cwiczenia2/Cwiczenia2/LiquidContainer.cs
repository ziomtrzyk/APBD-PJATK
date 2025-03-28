namespace Cwiczenia2;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double weight, double height, double ownWeight, double depth, double maxPayload, bool isDangerous) : base(weight, height, ownWeight, depth, maxPayload)
    {
        this.isDangerous = isDangerous;
    }

    public bool isDangerous{ get; set; }
    protected override double GetMaxFill() => isDangerous ? 0.5 : 0.9;

    protected override string GetConteinerType() => "L";

    public void NotifyHazard()
    {
        Console.WriteLine("There is a dangerous situation now. "+SerialNumber);
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"     Type: Liquid, Hazardous, {isDangerous}");
    }
}