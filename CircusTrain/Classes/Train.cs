namespace CircusTrain.Classes;

public class Train
{
    private Queue _queue;

    public void AddQueue(Queue queue)
    {
        _queue = new Queue(queue.Animals);
    }

    public List<Wagon> CalculateWagons()
    {
        _queue.SortByLargeCarnivores();
        List<Wagon> wagons1 = GetOptimizedWagons(_queue.Animals);

        _queue.SortByLargeHerbivores();
        List<Wagon> wagons2 = GetOptimizedWagons(_queue.Animals);

        return wagons1.Count > wagons2.Count ? wagons2 : wagons1;
    }

    private List<Wagon> GetOptimizedWagons(IReadOnlyList<Animal> readOnlyAnimals)
    {
        List<Wagon> wagons = new List<Wagon>();
        List<Animal> animals = new List<Animal>(readOnlyAnimals);

        while (animals.Count != 0)
        {
            Wagon wagon = new Wagon();

            foreach (Animal animal in animals.ToList())
            {
                if (wagon.TryAddAnimal(animal))
                {
                    animals.Remove(animal);
                }
            }

            wagons.Add(wagon);
        }

        return wagons;
    }
}