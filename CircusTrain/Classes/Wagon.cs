using CircusTrain.Interfaces;

namespace CircusTrain.Classes;

public class Wagon : IWagon
{
    private const int MaxAnimalPoints = 10;

    private static int _nextId;
    
    private int Id { get; }

    public IReadOnlyList<Animal> Animals => _animals;
    
    private List<Animal> _animals = new();

    private int Points
    {
        get { return _animals.Sum(a => (int)a.Size!); }
    }

    public Wagon()
    {
        Id = Interlocked.Increment(ref _nextId);
    }

    public bool IsRoomForAnimal(Animal animal)
    {
        return Points + (int)animal.Size! <= MaxAnimalPoints;
    }

    public bool IsSafeForAnimal(Animal newAnimal)
    {
        foreach (Animal animal in _animals)
        {
            if (animal.HasConflictWith(newAnimal))
            {
                return false;
            }
        }

        return true;
    }

    public bool TryAddAnimal(Animal animal)
    {
        bool canAddAnimal = IsRoomForAnimal(animal) && IsSafeForAnimal(animal);
        if (canAddAnimal)
        {
            _animals.Add(animal);
        }
        
        return canAddAnimal;
    }
    
    public override string ToString()
    {
        return $"Wagon ID: {Id}; Animal count = {Animals.Count}; Points = {Points};";
    }
}