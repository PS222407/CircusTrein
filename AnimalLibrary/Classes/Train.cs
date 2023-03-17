using System.Linq;

namespace AnimalLibrary.Classes;

public class Train
{
    public List<Wagon> Wagons { get; private set; } = new();

    public List<Animal> Animals { get; private set; } = new();

    public void AddAnimals(List<Animal> animals)
    {
        Animals = new List<Animal>(animals);
    }

    public void CalculateWagons()
    {
        Wagon wagon = new Wagon();
        
        foreach (Animal animal in Animals.ToList())
        {
            if (wagon.IsRoomForAnimal(animal) && wagon.IsSafeForAnimal(animal))
            {
                wagon.AddAnimal(animal);
                Animals.Remove(animal);
            }
        }
        
        Wagons.Add(wagon);

        if (Animals.Count != 0)
        {
            CalculateWagons();
        }
    }
}