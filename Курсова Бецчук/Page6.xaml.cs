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
    /// Interaction logic for Page6.xaml
    /// </summary>
    public partial class Page6 : Page
    {
        bool edit_active = false;

        public Page6()
        {
            InitializeComponent();

            Error_lbl.Content = string.Empty;
            Name_error_lbl.Content = string.Empty;
            Yearly_ord_error_lbl.Content= string.Empty;
            Yearly_prod_error_lbl.Content = string.Empty;
            Yearly_prof_error_lbl.Content = string.Empty;

            Name_lbl1.Opacity = 0;
            Name_box.Opacity = 0;
            Yearly_orders_lbl1.Opacity = 0;
            Ord_box.Opacity = 0;
            Yearly_prod_lbl1.Opacity = 0;
            Prod_box.Opacity = 0;
            Yearly_profit_lbl1.Opacity = 0;
            Prof_box.Opacity = 0;
            Edit_btn.Opacity = 0;
            Done_txtblock.Opacity = 0;

        }

        private void SearchByNameBtn_Click(object sender, RoutedEventArgs e)    
        {
            Name_box.Clear();
            Ord_box.Clear();
            Prod_box.Clear();
            Prof_box.Clear();

            Done_txtblock.Opacity = 0;
            Name_lbl1.Opacity = 0;
            Name_box.Opacity = 0;
            Yearly_orders_lbl1.Opacity = 0;
            Ord_box.Opacity = 0;
            Yearly_prod_lbl1.Opacity = 0;
            Prod_box.Opacity = 0;
            Yearly_profit_lbl1.Opacity = 0;
            Prof_box.Opacity = 0;
            Edit_btn.Opacity = 0;
            Error_lbl.Opacity = 0;
            var key = Company_search_box.Text;

            if (DBManager.CheckKey(key) == true)
            {
                Name_lbl1.Opacity = 1;
                Name_box.Opacity = 1;
                Yearly_orders_lbl1.Opacity = 1;
                Ord_box.Opacity = 1;
                Yearly_prod_lbl1.Opacity = 1;
                Prod_box.Opacity = 1;
                Yearly_profit_lbl1.Opacity = 1;
                Prof_box.Opacity = 1;
                Edit_btn.Opacity = 1;
                edit_active = true;

                var r = FindRecord(DBManager.GetRecords(), key);
                Name_box.Text = r.Name;
                Prod_box.Text = r.Yearly_prod.ToString();
                Ord_box.Text = r.Yearly_orders.ToString();
                Prof_box.Text += r.Yearly_profit.ToString();
            }
            else
            {
                Error_lbl.Content = "Помилка: запису з таким іменем не існує";
            }
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            bool c = true;    // True = user input contains no errors
            string name = "";
            int prod = 0;
            int ord = 0;
            double prof = 0.0;
            var key = Company_search_box.Text;

            if (edit_active == true)
            {
                name = Name_box.Text;
                if (name.Length == 0) 
                {
                    Name_error_lbl.Content = "Це поле не може бути порожнім";
                    c = false;
                }

                try
                {
                    if (Prod_box.Text.Length != 0)
                    {
                        prod = Convert.ToInt32(Prod_box.Text);
                    }
                    else
                    {
                        Yearly_prod_error_lbl.Content = "Це поле не може бути порожнім";
                        c = false;
                    }
                }
                catch(FormatException)
                {
                    Yearly_prod_error_lbl.Content = "Недопустиме значення";
                    c = false;
                }
                catch(OverflowException)
                {
                    Yearly_prod_error_lbl.Content = "Надто велике значення";
                    c = false;
                }

                try
                {
                    if (Ord_box.Text.Length != 0)
                    {
                        ord = Convert.ToInt32(Ord_box.Text);
                    }
                    else
                    {
                        Yearly_ord_error_lbl.Content = "Це поле не може бути порожнім";
                        c = false;
                    }
                }
                catch (FormatException)
                {
                    Yearly_ord_error_lbl.Content = "Недопустиме значення";
                    c = false;
                }
                catch (OverflowException)
                {
                    Yearly_ord_error_lbl.Content = "Надто велике значення";
                    c = false;
                }

                try
                {
                    if (Prof_box.Text.Length != 0)
                    {
                        prof = Convert.ToDouble(Prof_box.Text);
                    }
                    else
                    {
                        Yearly_prof_error_lbl.Content = "Це поле не може бути порожнім";
                        c = false;
                    }
                }
                catch (FormatException)
                {
                    Yearly_prof_error_lbl.Content = "Недопустиме значення";
                    c = false;
                }
                catch (OverflowException)
                {
                    Yearly_prof_error_lbl.Content = "Надто велике значення";
                    c = false;
                }

                if (c == true)
                {
                    var l = DBManager.GetRecords();
                    for (int i = 0; i < l.Count; i++)
                    {
                        if (l[i].Name == key)
                        {
                            l[i].Name = name;
                            l[i].Yearly_prod = prod;
                            l[i].Yearly_orders = ord;
                            l[i].Yearly_profit = prof;
                        }
                    }
                    DBManager.OverwriteList(l);
                    Done_txtblock.Opacity = 1;

                    Name_box.Clear();
                    Ord_box.Clear();
                    Prod_box.Clear();
                    Prof_box.Clear();
                    Company_search_box.Clear();

                    Name_lbl1.Opacity = 0;
                    Name_box.Opacity = 0;
                    Yearly_orders_lbl1.Opacity = 0;
                    Ord_box.Opacity = 0;
                    Yearly_prod_lbl1.Opacity = 0;
                    Prod_box.Opacity = 0;
                    Yearly_profit_lbl1.Opacity = 0;
                    Prof_box.Opacity = 0;
                    Edit_btn.Opacity = 0;
                    Error_lbl.Opacity = 0;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
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
            else
            {
                Done_txtblock.Opacity = 0;
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
