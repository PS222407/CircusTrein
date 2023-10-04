using CircusTrain.Classes;
using CircusTrain.Enums;

namespace CircusTrainUnitTests;

public class Tests
{
    private Train _train = new();

    [SetUp]
    public void Setup()
    {
        _train = new Train();
    }

    [Test]
    public void CalculateWagons_ReturnsWagonsFilledWithAnimals()
    {
        // Assign
        List<Animal> animals = new();
        for (int i = 0; i < 100; i++)
        {
            Animal animal = new();
            animal.AssignRandomProperties();
            animals.Add(animal);
        }

        _train = new Train();
        _train.AddAnimals(animals);

        // Act
        List<Wagon> wagons = _train.CalculateWagons();

        // Assert
        Assert.That(wagons, Has.Count.GreaterThan(0));
    }

    #region TestScenarios1-7

    [Test]
    public void GetWagonCountScenario1_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Carnivore),

            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),

            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }

    [Test]
    public void GetWagonCountScenario2_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Carnivore),

            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),

            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),

            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }

    [Test]
    public void GetWagonCountScenario3_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),

            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(4));
    }

    [Test]
    public void GetWagonCountScenario4_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),

            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(5));
    }

    [Test]
    public void GetWagonCountScenario5_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Carnivore),

            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }

    [Test]
    public void GetWagonCountScenario6_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),

            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),

            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(3));
    }

    [Test]
    public void GetWagonCountScenario7_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),

            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(13));
    }

    #endregion


    #region TestCases2

    [Test]
    public void GetWagonsCountScenario1_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }

    [Test]
    public void GetWagonsCountScenario2_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),

            new(Size.Small, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(6));
    }

    [Test]
    public void GetWagonsCountScenario3_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),

            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(8));
    }

    [Test]
    public void GetWagonsCountScenario4_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }

    [Test]
    public void GetWagonsCountScenario5_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),

            new(Size.Small, DietTypes.Carnivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }

    [Test]
    public void GetWagonsCountScenario6_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),

            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }

    [Test]
    public void GetWagonsCountScenario7_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new()
        {
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),

            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore)
        };
        _train.AddAnimals(animals);

        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(3));
    }

    #endregion
}