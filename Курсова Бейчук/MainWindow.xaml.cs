using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Path = System.IO.Path;

namespace Курсова_Бейчук
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            Loaded += OnMainWindowLoaded;          
        }


        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            ChangeView(new Page0());
        }

        public void ChangeView(Page view)
        {
            Main.NavigationService.Navigate(view);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)    //Exit
        {
            System.Environment.Exit(0);
        }
    }
}
