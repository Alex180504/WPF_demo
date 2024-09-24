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
using System.Windows.Controls.Primitives;

namespace Курсова_Бейчук
{
    /// <summary>
    /// Interaction logic for Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        public Page5()
        {
            InitializeComponent();

            Company_name_found_box.Clear();
            Yearly_orders_lbl2.Content = string.Empty;
            Yearly_prod_lbl2.Content = string.Empty;
            Yearly_profit_lbl2.Content = string.Empty;
            Company_name_not_found_lbl.Content= string.Empty;
        }

        private void SearchByNameBtn_Click(object sender, RoutedEventArgs e)
        {
            Company_name_not_found_lbl.Content = string.Empty;
            var key = Company_search_box.Text;
            if (DBManager.CheckKey(key) == false) 
            {
                Company_name_not_found_lbl.Content = "Помилка: запису з таким іменем не існує";
            }
            else
            {
                var l = DBManager.GetRecords();
                var result = FindRecord(l, key);

                Company_name_found_box.Text = result.Name;
                Yearly_orders_lbl2.Content = result.Yearly_orders;
                Yearly_prod_lbl2.Content = result.Yearly_prod;
                Yearly_profit_lbl2.Content = result.Yearly_profit;
            }
        }

        private AerospaceCompany FindRecord(List<AerospaceCompany> l, string key)   // Returns item with specified name from the input list
        {
            AerospaceCompany temp = new AerospaceCompany("", 0, 0, 0);
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i].Name == key)
                {
                    return l[i];
                }
            }
            return temp;
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

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchByNameBtn.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
            }
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
