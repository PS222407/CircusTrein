namespace AnimalLibrary.Classes;

public class Wagon
{
    public const int MaxAnimalPoints = 10;
    
    static int nextId;
    
    public int Id { get; set;}
    
    private List<Animal> _animals = new List<Animal>();
    
    public List<Animal> Animals
    {
        get => _animals;
        set => _animals = value;
    }

    private int _points = 0;

    public int Points
    {
        get => _points;
        set => _points = value;
    }

    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
        _points += (int)animal.Size;
    }

    public Wagon()
    {
        Id = Interlocked.Increment(ref nextId);
    }
    
    public override string ToString()
    {
        return $"Wagon ID: {Id}; Animal count = {Animals.Count}; Points = {Points};";
    }
}