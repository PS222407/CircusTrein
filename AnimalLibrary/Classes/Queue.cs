namespace AnimalLibrary.Classes;

public class Queue
{
    public List<Animal> Animals { get; private set; } = new();

    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }
}