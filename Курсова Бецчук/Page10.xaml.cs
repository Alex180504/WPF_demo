using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using Курсова_Бейчук;
using Курсова_Бейчук;

namespace Курсова_Бейчук
{
    /// <summary>
    /// Interaction logic for Page10.xaml
    /// </summary>
    public partial class Page10 : Page
    {
        public Page10()
        {
            InitializeComponent();

            var l = DBManager.GetRecords();
            List<OutputExtended> list1= new List<OutputExtended>();
            int n = l.Count;
            for (int i = 0; i < n; i++)
            {
                list1.Add(new OutputExtended(l[i].Name, l[i].Yearly_prod, l[i].Yearly_orders, l[i].Yearly_profit, l[i].OrdersProduction(), l[i].AvgProfitPerPlane()));
            }
            DG.ItemsSource = list1;
        }

        internal class OutputExtended   // Class used to input additional values to DataGrid
        {

            private string _name; 
            private int _yearly_prod; 
            private int _yearly_orders; 
            private double _yearly_profit; 
            private int _orders_prod; 
            private double _avg_profit_per_plane; 

            public string Name
            {
                get => _name;
                set => _name = value;
            }

            public int Yearly_prod
            {
                get => _yearly_prod;
                set => _yearly_prod = value;
            }

            public int Yearly_orders
            {
                get => _yearly_orders;
                set => _yearly_orders = value;
            }

            public double Yearly_profit
            {
                get => _yearly_profit;
                set => _yearly_profit = value;
            }
            public int Orders_prod
            {
                get => _orders_prod;
                set => _orders_prod = value;
            }
            public double Avg_profit_per_plane
            {
                get => _avg_profit_per_plane;
                set => _avg_profit_per_plane = value;
            }

            public OutputExtended(string name, int yearly_prod, int yearly_orders, double yearly_profit, int orders_prod, double avg_profit_per_plane)
            {
                this.Name = name;
                this.Yearly_prod = yearly_prod;
                this.Yearly_orders = yearly_orders;
                this.Yearly_profit = yearly_profit;
                this._orders_prod = orders_prod;
                this._avg_profit_per_plane = avg_profit_per_plane;
            }
        }

        private void MenuItem11_Click(object sender, RoutedEventArgs e)    //Add
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page1());
        }

        private void MenuItem12_Click(object sender, RoutedEventArgs e)    //Remove
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page2());
        }

        private void MenuItem13_Click(object sender, RoutedEventArgs e)    //View all
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page3());
        }

        private void MenuItem14_Click(object sender, RoutedEventArgs e)    //Edit record
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page6());
        }

        private void MenuItem21_Click(object sender, RoutedEventArgs e)    //Find highest yearly profit
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page4());
        }

        private void MenuItem22_Click(object sender, RoutedEventArgs e)    //Find by name
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page5());
        }

        private void MenuItem23_Click(object sender, RoutedEventArgs e)    //Find lowest yearly profit
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page7());
        }

        private void MenuItem24_Click(object sender, RoutedEventArgs e)    //Find company with most orders
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page8());
        }

        private void MenuItem25_Click(object sender, RoutedEventArgs e)    //Find company with most planes produced
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page9());
        }

        private void MenuItem26_Click(object sender, RoutedEventArgs e)    //Display all with additional values
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page10());
        }

        private void Exit_Click(object sender, RoutedEventArgs e)    //Exit
        {
            if (MessageBox.Show("Вийти з програми?", "Вихід", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                System.Environment.Exit(0);
            }
        }

        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page11());
        }
    }
}
