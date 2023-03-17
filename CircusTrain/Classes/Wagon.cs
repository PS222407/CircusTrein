using CircusTrain.Interfaces;

namespace CircusTrain.Classes;

public class Wagon : IWagon
{
    public const int MaxAnimalPoints = 10;

    private static int _nextId;
    public int Id { get; }

    public List<Animal> Animals { get; } = new();

    public int Points
    {
        get { return Animals.Sum(a => (int)a.Size); }
    }

    public Wagon()
    {
        Id = Interlocked.Increment(ref _nextId);
    }
    
    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }

    public bool IsRoomForAnimal(Animal animal)
    {
        return Points + (int)animal.Size <= MaxAnimalPoints;
    }

    public bool IsSafeForAnimal(Animal newAnimal)
    {
        foreach (Animal animal in Animals)
        {
            if (animal.HasConflictWith(newAnimal))
            {
                return false;
            }
        }

        return true;
    }
    
    public override string ToString()
    {
        return $"Wagon ID: {Id}; Animal count = {Animals.Count}; Points = {Points};";
    }
}