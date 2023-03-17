namespace CircusTrain.Classes;

public class Train
{
    private Queue _queue;
    public List<Wagon> Wagons { get; } = new();
    
    public void AddQueue(Queue queue)
    {
        _queue = new Queue(queue.Animals);
    }

    public List<Wagon> CalculateWagons()
    {
        Wagon wagon = new Wagon();

        foreach (Animal animal in _queue.Animals.ToList())
        {
            if (wagon.IsRoomForAnimal(animal) && wagon.IsSafeForAnimal(animal))
            {
                wagon.AddAnimal(animal);
                _queue.RemoveAnimal(animal);
            }
        }

        Wagons.Add(wagon);

        if (_queue.Animals.Count != 0)
        {
            CalculateWagons();
        }
        
        return Wagons;
    }
}