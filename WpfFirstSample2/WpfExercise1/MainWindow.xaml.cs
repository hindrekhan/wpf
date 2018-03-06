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

namespace WpfExercise1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Human> items = new List<Human>();
            items.Add(new Human() { FirstName = "Elmo", LastName = "Kelmo", Age = 25 });
            items.Add(new Human() { FirstName = "Juhan", LastName = "Aabits", Age = 34 });
            items.Add(new Human() { FirstName = "Mari", LastName = "Maasikas", Age = 21 });



            TodoListBox.ItemsSource = items;
        }
    }

    public class Human
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
