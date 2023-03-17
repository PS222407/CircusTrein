using CircusTrain.Classes;
using CircusTrain.Enums;
using NUnit.Framework;

namespace CircusTrainUnitTests;

public class AnimalTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void HasConflictWith_ReturnsTrue()
    {
        // Assign
        Animal animal = new Animal();
        animal.SetDietType(DietTypes.Carnivore);
        animal.SetSize(Size.Large);
        
        // Act
        bool result = animal.HasConflictWith(animal);

        // Assert
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void HasConflictWith_ReturnsFalse()
    {
        // Assign
        Animal animal = new Animal();
        animal.SetDietType(DietTypes.Carnivore);
        animal.SetSize(Size.Medium);
        Animal animal2 = new Animal();
        animal2.SetDietType(DietTypes.Herbivore);
        animal2.SetSize(Size.Large);
        
        // Act
        bool result = animal.HasConflictWith(animal2);

        // Assert
        Assert.That(result, Is.EqualTo(false));
    }
}