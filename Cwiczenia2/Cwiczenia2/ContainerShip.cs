namespace Cwiczenia2;

public class ContainerShip
{
    public List<Container> Containers { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxContainerCount { get; set; }
    public double MaxWeight { get; set; }

    public ContainerShip(double maxSpeed, int maxContainerCount, double maxWeight)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        double totalWeight = Containers.Sum(c => c.Weight);
        if(Containers.Count >= MaxContainerCount || totalWeight > MaxWeight*1000)
            throw new Exception("Too many containers or too much weight");
        Containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(string serialNumber)
    {
        Containers.RemoveAll(c => c.SerialNumber == serialNumber);
    }

    public void ReplaceContainer(Container container, string serialNumber)
    {
        UnloadContainer(serialNumber);
        LoadContainer(container);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ship info: Max Speed: {MaxSpeed} knots, Max Container Count: {MaxContainerCount}, Max Weight: {MaxWeight}");
        foreach (var container in Containers)
            container.PrintInfo();
    }
}