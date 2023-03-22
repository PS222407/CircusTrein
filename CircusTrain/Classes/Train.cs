using CircusTrain.Enums;

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

        List<Animal> carnivores = _queue.Animals.Where(a => a.DietType == DietTypes.Carnivore).OrderByDescending(a => a.Size).ToList();
        List<Animal> herbivores = _queue.Animals.Where(a => a.DietType == DietTypes.Herbivore).OrderByDescending(a => a.Size).ToList();
        List<Animal> animals = carnivores.Concat(herbivores).ToList();

        foreach (Animal animal in animals)
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
            return CalculateWagons();
        }

        return Wagons;
    }
}