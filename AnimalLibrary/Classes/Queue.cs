namespace AnimalLibrary.Classes;

public class Queue
{
    public List<Animal> Animals { get; }

    public Queue(List<Animal>? animals = null)
    {
        Animals = animals == null ? new List<Animal>() : new List<Animal>(animals);
    }

    public void AddAnimal(Animal animal)
    {
        Animals.Add(animal);
    }

    public void RemoveAnimal(Animal animal)
    {
        Animals.Remove(animal);
    }
}