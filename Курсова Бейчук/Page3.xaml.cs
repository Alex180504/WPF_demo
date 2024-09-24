using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using Курсова_Бейчук;

namespace Курсова_Бейчук
{
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page   //View all
    {
        public static string path_to_db = ".\\Data.csv";

        public Page3()
        {
            InitializeComponent();
            PrintList();
        }

        private void Apply_btn_Click(object sender, RoutedEventArgs e)
        {
            Filter_hi_error_lbl.Content= string.Empty;
            Filter_lo_error_lbl.Content = string.Empty;
            if (Sort_check.IsChecked == false && Filter_check.IsChecked == false)
            {
                return;
            }
            else
            {
                var l = DBManager.GetRecords();
                if (Filter_check.IsChecked == true)
                {
                    double filter_hi_val = 0;
                    double filter_lo_val = 0;
                    bool filter_hi = false;
                    if (Filter_high_check.IsChecked == true)
                    {
                        filter_hi = true;
                        if (Filter_high_box.Text != "")
                        {
                            try
                            {
                                filter_hi_val = Convert.ToDouble(Filter_high_box.Text);
                            }
                            catch(FormatException)
                            {
                                Filter_hi_error_lbl.Content = "Недопустиме значення";
                                return;
                            }
                            catch(OverflowException)
                            {
                                Filter_hi_error_lbl.Content = "Надто велике значення";
                                return;
                            }
                        }
                        else
                        {
                            Filter_hi_error_lbl.Content = "Це поле не може бути порожнім";
                            return;
                        }
                    }
                    bool filter_lo = false;
                    if (Filter_low_check.IsChecked == true)
                    {
                        filter_lo = true;
                        if (Filter_low_box.Text != "")
                        {
                            try
                            {
                                filter_lo_val = Convert.ToDouble(Filter_low_box.Text);
                            }
                            catch (FormatException)
                            {
                                Filter_lo_error_lbl.Content = "Недопустиме значення";
                                return;
                            }
                            catch (OverflowException)
                            {
                                Filter_lo_error_lbl.Content = "Надто велике значення";
                                return;
                            }
                        }
                        else
                        {
                            Filter_lo_error_lbl.Content = "Це поле не може бути пустим";
                            return;
                        }
                    }
                    if (filter_hi == true && filter_lo == true && filter_lo_val < filter_hi_val) 
                    {
                        return;
                    }

                    List<bool> to_del= new List<bool>();    // List of items to be excluded from the result
                    for (int i = 0; i < l.Count; i++)
                    {
                        to_del.Add(false);
                    }
                    if (filter_hi == true)
                    {
                        for (int i = 0; i < l.Count; i++)
                        {
                            if (l[i].Yearly_profit < filter_hi_val)
                            {
                                to_del[i] = true;
                            }
                        }
                    }
                    if (filter_lo == true)   
                    {
                        for (int i = 0; i < l.Count; i++)
                        {
                            if (l[i].Yearly_profit > filter_lo_val)
                            {
                                to_del[i] = true;
                            }
                        }
                    }
                    for (int i = 0; i < l.Count; i++)
                    {
                        if (to_del[i] == true)
                        {
                            l.Remove(l[i]);
                            to_del.RemoveAt(i);
                            i--;
                        }
                    }
                }

                if (Sort_check.IsChecked == true)
                {
                    if (Sort_high_to_low_radiobox.IsChecked == true)
                    {
                        List<AerospaceCompany> SortedList = l.OrderBy(o => o.Yearly_profit).ToList();
                        l.Clear();
                        for (int i = 0; i < SortedList.Count; i++)
                        {
                            l.Add(SortedList[i]);
                        }
                        l.Reverse();
                    }
                    else if (Sort_low_to_high_radiobox.IsChecked == true)
                    {
                        List<AerospaceCompany> SortedList = l.OrderBy(o => o.Yearly_profit).ToList();
                        l.Clear();
                        for (int i = 0; i < SortedList.Count; i++)
                        {
                            l.Add(SortedList[i]);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                ShowList(l);
            }
        }

        private void PrintList()    // Outputs unmodified list from the db to DataGrid
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            };
            using (var reader = new StreamReader(path_to_db))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<AerospaceCompany>().ToList();
                DG.ItemsSource = records;
            }
        }

        private void ShowList(List<AerospaceCompany> list)    // Outputs input list to DataGrid
        {
            DG.ItemsSource = list;
        }

        private void Sort_check_Checked(object sender, RoutedEventArgs e)
        {
            Sort_high_to_low_radiobox.IsEnabled = true;
            Sort_low_to_high_radiobox.IsEnabled = true;
        }

        private void Sort_check_Unchecked(object sender, RoutedEventArgs e)
        {
            Sort_high_to_low_radiobox.IsEnabled = false;
            Sort_low_to_high_radiobox.IsEnabled = false;
        }

        private void Filter_check_Checked(object sender, RoutedEventArgs e)
        {
            Filter_high_check.IsEnabled = true;
            Filter_low_check.IsEnabled = true;
        }

        private void Filter_check_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter_high_check.IsEnabled = false;
            Filter_low_check.IsEnabled = false;
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
