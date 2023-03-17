using System.Diagnostics;
using System.Linq;
using AnimalLibrary.Enums;

namespace AnimalLibrary.Classes;

public class Train
{
    private List<Wagon> _wagons = new List<Wagon>();

    public List<Wagon> Wagons
    {
        get => _wagons;
        set => _wagons = value;
    }

    private List<Animal> _animals = new List<Animal>();

    public List<Animal> Animals
    {
        get => _animals;
        set => _animals = value;
    }

    public void CalculateWagons()
    {
        AssignCarnivoresToWagons();
        FillCarnivoreWagonsWithHerbivores();
        AssignRemainingHerbivoresToNewWagons();
    }

    private void AssignCarnivoresToWagons()
    {
        List<Animal> animals = _animals.FindAll(a=> a.DietType == DietTypes.Carnivore).ToList();

        foreach (Animal animal in animals)
        {
            Wagon wagon = new Wagon();
            wagon.AddAnimal(animal);

            _wagons.Add(wagon);
            _animals.Remove(animal);
        }
    }
    
    private void FillCarnivoreWagonsWithHerbivores()
    {
        List<Wagon> wagons = _wagons.OrderByDescending(w => (int)w.Animals[0].Size).ToList();

        foreach (Wagon wagon in wagons)
        {
            if (wagon.Animals.Count == 1 && wagon.Animals[0].DietType == DietTypes.Carnivore && wagon.Animals[0].Size == Size.Large)
            {
                continue;
            }
            
            List<Animal> animals = _animals.OrderByDescending(a=> (int)a.Size).ToList();
            Size carnivoreSize = wagon.Animals[0].Size;
            
            foreach (Animal herbivore in animals)
            {
                bool willFit = wagon.Points + (int)herbivore.Size <= Wagon.MaxAnimalPoints;
                bool isSafe = (int)carnivoreSize < (int)herbivore.Size;
                
                if (willFit && isSafe)
                {
                    wagon.AddAnimal(herbivore);
                    _animals.Remove(herbivore);
                }
            }
        }
    }
    
    private void AssignRemainingHerbivoresToNewWagons()
    {
        Wagon wagon = new Wagon();

        foreach (Animal herbivore in _animals.ToList())
        {
            int index = _animals.IndexOf(herbivore);
            bool isLastIteration = index == _animals.Count - 1;
            
            bool willFit = wagon.Points + (int)herbivore.Size <= Wagon.MaxAnimalPoints;
                
            if (willFit)
            {
                wagon.AddAnimal(herbivore);
                _animals.Remove(herbivore);

                if (isLastIteration)
                {
                    _wagons.Add(wagon);
                }
            }
            else
            {
                _wagons.Add(wagon);
                wagon = new Wagon()
                    ;
                wagon.AddAnimal(herbivore);
                _animals.Remove(herbivore);
            }
        }

        Debug.Write(_animals);
    }
}