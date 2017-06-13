using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Threading;

namespace RandomNamePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Random random = new Random();

        List<string> names = new List<string>()
        {
            "Matt",
            "Andrew",
            "Andre",
            "Eric",
            "Carlos",
            "Marco",
            "Mike",
            "Micheal",
            "Ashish",
            "Shiva",
            "Josh",
            "Jordan",
            "Jose",
            "Nickolous",
            "Cristian"

        };

        List<string> resetNames = new List<string>(); // empty list

        public MainWindow()
        {
            InitializeComponent();
            AddNamesToList();
            NamesBox.ItemsSource = names;

        }

        private void btnPickName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var r = random.Next(names.Count()); // random item
                string randomName = names[r]; // assign random name to variable

                //results.Add(randomName); // add name to results list
                ResultsBox.ItemsSource = new List<string> { randomName }; // add name to list to result list box
                
                ResultsBox.Items.Refresh(); // refresh result list box

                names.Remove(randomName); // remove from first list
                NamesBox.Items.Refresh(); // refresh first list box
            }
            catch { }
            
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                NamesBox.ItemsSource = resetNames; // return all names to list box
                ResultsBox.ItemsSource = ""; // clear result list box

                ResultsBox.Items.Refresh(); // refresh names in results list box
                NamesBox.Items.Refresh(); // refresh names list box

                foreach (var name in resetNames) // put names back in names list
                {
                    names.Add(name);
                }
                NamesBox.ItemsSource = names;
            }
            catch { }
            
        }

        public void AddNamesToList()
        {
            try
            {
                foreach (var name in names)
                {
                    resetNames.Add(name);
                }
            }
            catch
            {

            }
        }
    }
}
