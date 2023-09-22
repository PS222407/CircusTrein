using CircusTrain.Enums;

namespace CircusTrain.Classes;

public class Train
{
    private List<Animal> _animals = new();

    public void AddAnimals(List<Animal> animals)
    {
        _animals = animals;
    }

    public List<Wagon> CalculateWagons()
    {
        List<Animal> animalsSortedByLargeCarnivores = GetAnimalsSortedByLargeCarnivores();
        List<Wagon> wagons1 = GetOptimizedWagons(animalsSortedByLargeCarnivores);

        List<Animal> animalsSortByLargeHerbivores = GetAnimalsSortedByLargeHerbivores();
        List<Wagon> wagons2 = GetOptimizedWagons(animalsSortByLargeHerbivores);

        return wagons1.Count > wagons2.Count ? wagons2 : wagons1;
    }

    private List<Animal> GetAnimalsSortedByLargeHerbivores()
    {
        List<Animal> animalsSortByLargeHerbivores = new List<Animal>(_animals);
        List<Animal> carnivores = animalsSortByLargeHerbivores.Where(a => a.DietType == DietTypes.Carnivore).OrderByDescending(a => a.Size).ToList();
        List<Animal> herbivores = animalsSortByLargeHerbivores.Where(a => a.DietType == DietTypes.Herbivore).OrderByDescending(a => a.Size).ToList();
        return herbivores.Concat(carnivores).ToList();
    }

    private List<Animal> GetAnimalsSortedByLargeCarnivores()
    {
        List<Animal> animalsSortedByLargeCarnivores = new List<Animal>(_animals);
        List<Animal> carnivores = animalsSortedByLargeCarnivores.Where(a => a.DietType == DietTypes.Carnivore).OrderByDescending(a => a.Size).ToList();
        List<Animal> herbivores = animalsSortedByLargeCarnivores.Where(a => a.DietType == DietTypes.Herbivore).OrderByDescending(a => a.Size).ToList();
        return carnivores.Concat(herbivores).ToList();
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