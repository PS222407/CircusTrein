using CircusTrain.Enums;
using CircusTrain.Interfaces;

namespace CircusTrain.Classes;

public class Animal : IAnimal
{
    static int _nextId;

    private int Id { get; }

    public DietTypes? DietType { get; private set; }

    public Size? Size { get; private set; }

    public Animal(Size? size = null, DietTypes? dietType = null)
    {
        Id = Interlocked.Increment(ref _nextId);

        if (size != null)
        {
            Size = size;
        }
        if (dietType != null)
        {
            DietType = dietType;
        }
    }

    public void AssignRandomProperties()
    {
        Random random = new Random();

        Array dietTypes = Enum.GetValues(typeof(DietTypes));
        Array sizeTypes = Enum.GetValues(typeof(Size));

        DietType = (DietTypes)dietTypes.GetValue(random.Next(dietTypes.Length))!;
        Size = (Size)sizeTypes.GetValue(random.Next(sizeTypes.Length))!;
    }

    public void SetDietType(DietTypes dietType)
    {
        DietType = dietType;
    }

    public void SetSize(Size size)
    {
        Size = size;
    }

    public bool HasConflictWith(Animal animal)
    {
        if (animal.DietType == DietTypes.Carnivore && (int)animal.Size! >= (int)Size!)
        {
            return true;
        }

        if (DietType == DietTypes.Carnivore && (int)Size! >= (int)animal.Size!)
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