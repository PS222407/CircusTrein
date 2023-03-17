using AnimalLibrary.Enums;

namespace AnimalLibrary.Classes;

public class Animal
{
    static int _nextId;

    public int Id { get; }

    public DietTypes DietType { get; private set; }

    public Size Size { get; private set; }

    public Animal()
    {
        Id = Interlocked.Increment(ref _nextId);
        AssignRandomProperties();
    }

    private void AssignRandomProperties()
    {
        Random random = new Random();
        
        Array dietTypes = Enum.GetValues(typeof(DietTypes));
        Array sizeTypes = Enum.GetValues(typeof(Size));
        
        DietType = (DietTypes)dietTypes.GetValue(random.Next(dietTypes.Length))!;
        Size = (Size)sizeTypes.GetValue(random.Next(sizeTypes.Length))!;
    }

    public bool HasConflictWith(Animal animal)
    {
        if (animal.DietType == DietTypes.Carnivore && (int)animal.Size >= (int)Size)
        {
            return true;
        }
        if (DietType == DietTypes.Carnivore && (int)Size >= (int)animal.Size)
        {
            return true;
        }

        return false;
    }
    
    public override string ToString()
    {
        return $"id = {Id}; Size = {Size}; DietType = {DietType}; points = {(int)Size};";
    }
}