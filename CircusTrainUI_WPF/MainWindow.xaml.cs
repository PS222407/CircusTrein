using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CircusTrain.Classes;

namespace CircusTrein;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Train _train;

    private List<Animal> _animals = new();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void ButtonBase_OnClick_Add_Animal(object sender, RoutedEventArgs e)
    {
        Animal animal = new Animal();
        animal.AssignRandomProperties();
        _animals.Add(animal);
        
        ListBoxAnimals.Items.Add(animal);
    }

    private void ButtonBase_OnClick_Calculate_Train_Wagons(object sender, RoutedEventArgs e)
    {
        _train = new Train();
        _train.AddAnimals(_animals);
        List<Wagon> wagons = _train.CalculateWagons();

        ListBoxWagons.Items.Clear();

        foreach (Wagon wagon in wagons)
        {
            ListBox wagonUi = new ListBox();

            wagonUi.Items.Add(wagon);
            foreach (Animal animal in wagon.Animals)
            {
                wagonUi.Items.Add(animal);
            }

            ListBoxWagons.Items.Add(wagonUi);
        }
    }
}