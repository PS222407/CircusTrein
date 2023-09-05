using CircusTrain.Enums;

namespace CircusTrain.Classes;

public class Queue
{
    private List<Animal> _animals;
    
    public IReadOnlyList<Animal> Animals => _animals;

    public Queue(IReadOnlyList<Animal>? animals = null)
    {
        _animals = animals == null ? new List<Animal>() : new List<Animal>(animals);
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public void SortByLargeCarnivores()
    {
        List<Animal> carnivores = _animals.Where(a => a.DietType == DietTypes.Carnivore).OrderByDescending(a => a.Size).ToList();
        List<Animal> herbivores = _animals.Where(a => a.DietType == DietTypes.Herbivore).OrderByDescending(a => a.Size).ToList();
        _animals = carnivores.Concat(herbivores).ToList();
    }
    
    public void SortByLargeHerbivores()
    {
        List<Animal> carnivores = Animals.Where(a => a.DietType == DietTypes.Carnivore).OrderByDescending(a => a.Size).ToList();
        List<Animal> herbivores = Animals.Where(a => a.DietType == DietTypes.Herbivore).OrderByDescending(a => a.Size).ToList();
        _animals = herbivores.Concat(carnivores).ToList();
    }
}