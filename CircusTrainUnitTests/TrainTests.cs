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

        // Assert
        foreach (Wagon wagon in wagons)
        {
            if (wagon.Animals.Count(a => a.DietType == DietTypes.Carnivore) > 1)
            {
                Assert.Fail();
            }
        }

        Assert.Pass();
    }

    #region TestScenarios1-7

    [Test]
    public void GetWagonCountScenario1_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Small, DietTypes.Carnivore),
            
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void GetWagonCountScenario2_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Small, DietTypes.Carnivore),
            
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void GetWagonCountScenario3_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),
            
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(4));
    }
    
    [Test]
    public void GetWagonCountScenario4_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
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
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(5));
    }
    
    [Test]
    public void GetWagonCountScenario5_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Small, DietTypes.Carnivore),
            
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void GetWagonCountScenario6_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
            
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(3));
    }
    
    [Test]
    public void GetWagonCountScenario7_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
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
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
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
        List<Animal> animals = new List<Animal>
        {
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void GetWagonsCountScenario2_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            
            new(Size.Small, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Medium, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),
            new(Size.Large, DietTypes.Carnivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(6));
    }
    
    [Test]
    public void GetWagonsCountScenario3_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
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
            new(Size.Large, DietTypes.Carnivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(8));
    }
    
    [Test]
    public void GetWagonsCountScenario4_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Small, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void GetWagonsCountScenario5_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),

            new(Size.Small, DietTypes.Carnivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void GetWagonsCountScenario6_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
        {
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Medium, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),
            new(Size.Large, DietTypes.Herbivore),

            new(Size.Small, DietTypes.Carnivore),
            new(Size.Small, DietTypes.Carnivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(2));
    }
    
    [Test]
    public void GetWagonsCountScenario7_ReturnsWagonsFilledWithAnimals()
    {
        // ASSIGN
        List<Animal> animals = new List<Animal>
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
            new(Size.Small, DietTypes.Carnivore),
        };
        foreach (Animal animal in animals)
        {
            _queue.AddAnimal(animal);
        }
        _train = new Train();
        _train.AddQueue(_queue);
        
        // ACT
        List<Wagon> wagons = _train.CalculateWagons();

        // ASSERT
        Assert.That(wagons, Has.Count.EqualTo(3));
    }
    
    
    #endregion
}