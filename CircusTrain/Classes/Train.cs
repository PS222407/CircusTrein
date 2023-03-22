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
        List<Wagon> wagons1 = CalculateWagonsStartsWithCarnivores();
        List<Wagon> wagons2 = CalculateWagonsStartsWithHerbivores();

        return wagons1.Count > wagons2.Count ? wagons2 : wagons1;
    }

    private List<Wagon> CalculateWagonsStartsWithCarnivores()
    {
        List<Wagon> wagons = new List<Wagon>();
        Queue queue = new Queue(_queue.Animals);

        while (true)
        {
            Wagon wagon = new Wagon();

            List<Animal> carnivores = queue.Animals.Where(a => a.DietType == DietTypes.Carnivore).OrderByDescending(a => a.Size).ToList();
            List<Animal> herbivores = queue.Animals.Where(a => a.DietType == DietTypes.Herbivore).OrderByDescending(a => a.Size).ToList();
            List<Animal> animals = carnivores.Concat(herbivores).ToList();

            foreach (Animal animal in animals)
            {
                if (wagon.IsRoomForAnimal(animal) && wagon.IsSafeForAnimal(animal))
                {
                    wagon.AddAnimal(animal);
                    queue.RemoveAnimal(animal);
                }
            }

            wagons.Add(wagon);

            if (queue.Animals.Count != 0)
            {
                continue;
            }

            return wagons;
        }
    }

    private List<Wagon> CalculateWagonsStartsWithHerbivores()
    {
        List<Wagon> wagons = new List<Wagon>();
        Queue queue = new Queue(_queue.Animals);

        while (true)
        {
            Wagon wagon = new Wagon();

            List<Animal> carnivores = queue.Animals.Where(a => a.DietType == DietTypes.Carnivore).OrderByDescending(a => a.Size).ToList();
            List<Animal> herbivores = queue.Animals.Where(a => a.DietType == DietTypes.Herbivore).OrderByDescending(a => a.Size).ToList();
            List<Animal> animals = herbivores.Concat(carnivores).ToList();

            foreach (Animal animal in animals)
            {
                if (wagon.IsRoomForAnimal(animal) && wagon.IsSafeForAnimal(animal))
                {
                    wagon.AddAnimal(animal);
                    queue.RemoveAnimal(animal);
                }
            }

            wagons.Add(wagon);

            if (queue.Animals.Count != 0)
            {
                continue;
            }

            return wagons;
        }
    }
}