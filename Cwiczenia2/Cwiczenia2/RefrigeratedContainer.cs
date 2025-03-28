namespace Cwiczenia2;

public class RefrigeratedContainer : Container
{
    public RefrigeratedContainer(double weight, double height, double ownWeight, double depth, double maxPayload, double temperature, string product) : base(weight, height, ownWeight, depth, maxPayload)
    {
        if(ProductTemperatureRequirements.GetRequiredTemperature(product) > temperature)
            throw new ArgumentException("The product " + product + " does not have a temperature requirement.");
        
        this.temperature = temperature;
        this.product = product;
    }

    public double temperature { get; set; }
    public string product { get; set; }
    

    protected override string GetConteinerType() => "C";

    protected override double GetMaxFill() => 1.0;


}