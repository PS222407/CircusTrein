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
using AnimalLibrary.Classes;

namespace CircusTrein
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Train _train;
        
        public MainWindow()
        {
            InitializeComponent();
            _train = new Train();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Animal animal = new Animal();
            _train.AddAnimal(animal);
            
            AddAnimalToListBox(animal);
        }

        private void AddAnimalToListBox(Animal animal)
        {
            string displayAnimalString = "id = " + animal.Id + "; Height = " + animal.Size + "; DietType = " + animal.DietTypes.ToString() + "; points = " + (int)animal.Size + ";";
            ListBoxAnimals.Items.Add(displayAnimalString);
        }
    }
}