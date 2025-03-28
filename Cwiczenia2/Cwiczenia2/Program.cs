namespace Cwiczenia2;

class Program
{
    static void Main(string[] args)
    {
        var liquidContainer = new LiquidContainer(200.0, 100.0, 100.0, 100.0, 300.0, true );
        var gasContainer = new GasContainer(400.0 ,200.0 , 100.0, 50.0, 500.0,2.0 );
        var refrigeratedContainer = new RefrigeratedContainer(250.0, 150.0, 50.0, 500.0, 350.0, 30.0, "Bananas");
        
        List<Container> containers = [];
        containers.Add(liquidContainer);
        containers.Add(gasContainer);
        
        ContainerShip ship1 = new ContainerShip(20.0 , 100, 6000);
        ContainerShip ship2 = new ContainerShip(15.0 , 120, 7200);

        ship1.LoadContainers(containers);
        ship2.LoadContainer(refrigeratedContainer);
        
        ship1.UnloadContainer("KON-G-2");
        
        gasContainer.UnloadCargo();
        
        ship2.ReplaceContainer(gasContainer, "KON-C-3");
        
        ship1.UnloadContainer("KON-L-1");
        ship2.LoadContainer(liquidContainer);
        
        liquidContainer.PrintInfo();
        
        ship2.PrintInfo();
        
    }
}