using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CircusTrain.Classes;

namespace CircusTrein;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Train _train;
    private readonly Queue _queue;

    public MainWindow()
    {
        InitializeComponent();

        _queue = new Queue();
    }

    private void ButtonBase_OnClick_Add_Animal(object sender, RoutedEventArgs e)
    {
        Animal animal = new Animal();
        animal.AssignRandomProperties();
        _queue.AddAnimal(animal);

        ListBoxAnimals.Items.Add(animal);
    }

    private void ButtonBase_OnClick_Calculate_Train_Wagons(object sender, RoutedEventArgs e)
    {
        _train = new Train();
        _train.AddQueue(_queue);
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