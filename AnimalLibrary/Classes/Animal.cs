using AnimalLibrary.Enums;

namespace AnimalLibrary.Classes;

public class Animal
{
    static int nextId;
    
    public int Id { get; set;}
    
    private DietTypes _dietType;
    public DietTypes DietType
    {
        get => _dietType;
        set => _dietType = value;
    }

    private Size _size;
    public Size Size
    {
        get => _size;
        set => _size = value;
    }

    public Animal()
    {
        Id = Interlocked.Increment(ref nextId);
        
        Random random = new Random();
        
        Array dietTypes = Enum.GetValues(typeof(DietTypes));
        Array sizeTypes = Enum.GetValues(typeof(Size));
        
        _dietType = (DietTypes)dietTypes.GetValue(random.Next(dietTypes.Length))!;
        _size = (Size)sizeTypes.GetValue(random.Next(sizeTypes.Length))!;
    }
    
    public override string ToString()
    {
        return $"id = {Id}; Size = {Size}; DietType = {DietType}; points = {(int)Size};";
    }
}