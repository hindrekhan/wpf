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

namespace WpfList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string[] allLines = System.IO.File.ReadAllLines("../../names.txt");
            List<TodoItem> todo = new List<TodoItem>();

            foreach(string line in allLines)
            {
                TodoItem item = new TodoItem();

                item.Title = line;
                item.Completion = 5;

                todo.Add(item);
            }

            TodoListBox.ItemsSource = todo;            
        }

        private void todoListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TodoListBox.SelectedItem != null)
            {
                Title = (TodoListBox.SelectedItem as TodoItem).Title;
            }
        }

        private void btnShowSelectedItem_Click(object sender, RoutedEventArgs e)
        {            
            foreach (var item in TodoListBox.SelectedItems)
            {
                MessageBox.Show((item as TodoItem).Title);

            }
        }

        private void btnSelectLast_Click(object sender, RoutedEventArgs e)
        {
            TodoListBox.SelectedIndex = TodoListBox.Items.Count - 1;
        }

        private void btnSelectNext_Click(object sender, RoutedEventArgs e)
        {
            int nextIndex = 0;
            if((TodoListBox.SelectedIndex >= 0) && (TodoListBox.SelectedIndex < (TodoListBox.Items.Count - 1)))
            {
                nextIndex = TodoListBox.SelectedIndex + 1;
            }
            TodoListBox.SelectedIndex = nextIndex;
        }

        private void btnSelectCSharp_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in TodoListBox.Items)
            {
                if((item is TodoItem) && ((item as TodoItem).Title.Contains("C#")))
                {
                    TodoListBox.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in TodoListBox.Items)
            {
                TodoListBox.SelectedItems.Add(item);
            }
        }
    }

    public class TodoItem
    {
        public string Title { get; set; }
        public int Completion { get; set; }
    }
}
