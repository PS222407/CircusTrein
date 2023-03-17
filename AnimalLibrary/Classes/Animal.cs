using AnimalLibrary.Enums;

namespace AnimalLibrary.Classes;

public class Animal
{
    private DietTypes _dietTypes;
    public DietTypes DietTypes
    {
        get => _dietTypes;
        set => _dietTypes = value;
    }

    private Size _size;
    public Size Size
    {
        get => _size;
        set => _size = value;
    }

    static int nextId;
    
    public int Id { get; set;}

    public Animal()
    {
        Id = Interlocked.Increment(ref nextId);
        
        Random random = new Random();
        
        Array dietTypes = Enum.GetValues(typeof(DietTypes));
        Array sizeTypes = Enum.GetValues(typeof(Size));
        
        _dietTypes = (DietTypes)dietTypes.GetValue(random.Next(dietTypes.Length))!;
        _size = (Size)sizeTypes.GetValue(random.Next(sizeTypes.Length))!;
    }
}