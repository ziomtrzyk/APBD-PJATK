namespace Cwiczenia2;

public class ProductTemperatureRequirements
{
    private static Dictionary<string, double> RequiredTemperatures = new Dictionary<string, double>()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18.0 },
        { "Fish", 2.0 },
        { "Meat", -15.0 },
        { "Ice cream", -18.0 },
        { "Frozen pizza", -30.0 },
        { "Cheese", 7.2 },
        { "Sausages", 5.0 },
        { "Butter", 20.5 },
        { "Eggs", 19.0 }
    };

    public static double GetRequiredTemperature(string product)
    {
        if(RequiredTemperatures.ContainsKey(product))
            return RequiredTemperatures[product];
        throw new ArgumentException("The product " + product + " does not exist.");
    } 
}