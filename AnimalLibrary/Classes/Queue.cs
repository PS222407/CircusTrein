namespace AnimalLibrary.Classes;

public class Queue
{
    private List<Animal> _animals = new List<Animal>();

    public List<Animal> Animals
    {
        get => _animals;
        set => _animals = value;
    }
}