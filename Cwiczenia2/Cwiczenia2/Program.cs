namespace Cwiczenia2;

class Program
{
    static void Main(string[] args)
    {
        RefrigeratedContainer refrigeratedContainer1 =
            new RefrigeratedContainer(1.0, 1.0, 1.0, 1.0, 2.0, 30.0, "Bananas");
        Console.WriteLine(refrigeratedContainer1.SerialNumber);
        RefrigeratedContainer refrigeratedContainer2 =
            new RefrigeratedContainer(1.0, 1.0, 1.0, 1.0, 2.0, 30.0, "Bananas");
        Console.WriteLine(refrigeratedContainer2.SerialNumber);
        
        LiquidContainer liquidContainer1 =
            new LiquidContainer(1.0, 1.0, 1.0, 1.0, 2.0, true );
        Console.WriteLine(liquidContainer1.SerialNumber);
    }
}