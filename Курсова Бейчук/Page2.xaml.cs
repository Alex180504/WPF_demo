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

namespace Курсова_Бейчук
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page   //Remove record
    {

        public Page2()
        {
            InitializeComponent();
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

        private void DeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            Deleted_label.Content = string.Empty;
            Error_label.Content = string.Empty;

            var key = Name_todelete_box1.Text;
            if (DBManager.CheckKey(key) == true)
            {
                var l = DBManager.GetRecords();
                var l1 = DBManager.RemoveKey(l, key);
                DBManager.OverwriteList(l1);
                Deleted_label.Content = "Запис видалено";
            }
            else
            {
                Error_label.Content = "Помилка: запису з таким іменем не існує";
            }
        }

        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Page11());
        }
    }
}
