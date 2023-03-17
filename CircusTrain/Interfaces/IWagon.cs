using CircusTrain.Classes;

namespace CircusTrain.Interfaces;

public interface IWagon
{
    public bool IsRoomForAnimal(Animal animal);

    public bool IsSafeForAnimal(Animal newAnimal);
}