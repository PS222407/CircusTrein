using System.Diagnostics;

namespace AnimalLibrary.Classes;

public class Train
{
    private List<Wagon> _wagons = new List<Wagon>();
    private List<Animal> _animals = new List<Animal>();
    
    public void AddAnimal(Animal animal)
    {
        _animals.Add(animal);
    }

    public void CalculateWagons()
    {
        Debug.Write(_animals);
    }
}