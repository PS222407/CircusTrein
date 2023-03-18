using CircusTrain.Classes;
using CircusTrain.Enums;

namespace CircusTrainUnitTests;

public class Tests
{
    private Train _train;
    private Queue _queue;

    [SetUp]
    public void Setup()
    {
        _queue = new Queue();
    }

    [Test]
    public void CalculateWagons_ReturnsWagonsFilledWithAnimals()
    {
        // Assign
        for (int i = 0; i < 100; i++)
        {
            Animal animal = new Animal();
            animal.AssignRandomProperties();
            _queue.AddAnimal(animal);
        }

        _train = new Train();
        _train.AddQueue(_queue);

        // Act
        List<Wagon> wagons = _train.CalculateWagons();
        if (wagons.Count == 0)
        {
            Assert.Fail();
        }

        foreach (Wagon wagon in wagons)
        {
            if (wagon.Animals.Count(a => a.DietType == DietTypes.Carnivore) > 1)
            {
                Assert.Fail();
            }
        }

        Assert.Pass();
    }
}