using CircusTrain.Classes;
using CircusTrain.Enums;
using NUnit.Framework;

namespace CircusTrainUnitTests;

public class WagonTests
{
    private Wagon _wagon;
    
    [SetUp]
    public void Setup()
    {
        _wagon = new Wagon();
    }

    [Test]
    public void IsRoomForAnimal_ReturnsTrue()
    {
        // Assign
        Animal animal = new Animal();
        animal.SetDietType(DietTypes.Carnivore);
        animal.SetSize(Size.Large);
        _wagon.AddAnimal(animal);
        
        // Act
        bool result = _wagon.IsRoomForAnimal(animal);

        // Assert
        Assert.That(result, Is.EqualTo(true));
    }
    
    [Test]
    public void IsRoomForAnimal_ReturnsFalse()
    {
        // Assign
        Animal animal = new Animal();
        animal.SetDietType(DietTypes.Carnivore);
        animal.SetSize(Size.Large);
        _wagon.AddAnimal(animal);
        _wagon.AddAnimal(animal);
        
        // Act
        bool result = _wagon.IsRoomForAnimal(animal);

        // Assert
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void IsSafeForAnimal_ReturnsTrue()
    {
        // Assign
        Animal animal = new Animal();
        animal.SetDietType(DietTypes.Carnivore);
        animal.SetSize(Size.Medium);
        _wagon.AddAnimal(animal);
        Animal animal2 = new Animal();
        animal2.SetDietType(DietTypes.Herbivore);
        animal2.SetSize(Size.Large);

        // Act
        bool result = _wagon.IsSafeForAnimal(animal2);

        // Assert
        Assert.That(result, Is.EqualTo(true));
    }
    
    [Test]
    public void IsSafeForAnimal_ReturnsFalse()
    {
        // Assign
        Animal animal = new Animal();
        animal.SetDietType(DietTypes.Carnivore);
        animal.SetSize(Size.Large);
        _wagon.AddAnimal(animal);
        
        // Act
        bool result = _wagon.IsSafeForAnimal(animal);

        // Assert
        Assert.That(result, Is.EqualTo(false));
    }
}