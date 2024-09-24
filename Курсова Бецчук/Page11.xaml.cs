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
    /// Interaction logic for Page11.xaml
    /// </summary>
    public partial class Page11 : Page
    {
        public Page11()
        {
            InitializeComponent();

            // Create a FlowDocument to contain content for the RichTextBox
            FlowDocument myFlowDoc = new FlowDocument();

            // Add content

            /// Line indent = new paragraph
            Bold bold1 = new Bold(new Run("1. Додати запис про авіабудівну фірму до бази данних"));

            Bold bold2 = new Bold(new Run("1) "));
            Run run1 = new Run("натисніть на пункт \"Файл\" навігаційної панелі та виберіть пункт \"Додати фірму\"\n");
            Bold bold3 = new Bold(new Run("2) "));
            Run run2 = new Run("заповніть всі поля форми та натисніть кнопку \"Додати фірму\"");

            Bold bold4 = new Bold(new Run("2. Видалити запис про авіабудівну фірму з бази данних"));

            Bold bold5 = new Bold(new Run("1) "));
            Run run3 = new Run("натисніть на пункт \"Файл\" навігаційної панелі та виберіть пункт \"Видалити фірму\"\n");
            Bold bold6 = new Bold(new Run("2) "));
            Run run4 = new Run("введіть назву фірми, яку хочете видалити та натисніть кнопку \"Видалити\"");

            Bold bold7 = new Bold(new Run("3. Перегляд записів, що містяться базі данних"));

            Bold bold8 = new Bold(new Run("3.1. Перегляд всіх записів\n"));
            Run run5 = new Run("Натисніть на пункт \"Файл\" навігаційної панелі та виберіть пункт \"Переглянути записи\"\n");
            Bold bold9 = new Bold(new Run("\n3.2. Сортування записів за річним прибутком фірм\n"));
            Bold bold10 = new Bold(new Run("1) "));
            Run run6 = new Run("натисніть на прапорець \"Сортувати за річним прибутком\" та оберіть тип сортування\n");
            Bold bold11 = new Bold(new Run("2) "));
            Run run7 = new Run("натисніть на кнопку \"Застосувати\"");

            Bold bold12 = new Bold(new Run("4. Редагування записів"));

            Bold bold13 = new Bold(new Run("1) "));
            Run run8 = new Run("натисніть на пункт \"Файл\" навігаційної панелі та виберіть пункт \"Редагувати запис\"\n");
            Bold bold14 = new Bold(new Run("2) "));
            Run run9 = new Run("введіть назву фірми, інформацію про яку Ви хочете змінити та натисніть кнопку \"Пошук\"\n");
            Bold bold16 = new Bold(new Run("3) "));
            Run run10 = new Run("змініть дані потрібних полях форми та натисніть кнопку \"Редагувати\"");

            Bold bold17 = new Bold(new Run("5. Пошук фірми з найбільшим річним прибутком"));

            Run run11 = new Run("Натисніть на пункт \"Інструменти\" навігаційної панелі та виберіть пункт \"Знайти фірму з найбільшим річним прибутком\"");

            Bold bold18 = new Bold(new Run("6. Пошук фірми з найменшим річним прибутком"));

            Run run12 = new Run("Натисніть на пункт \"Інструменти\" навігаційної панелі та виберіть пункт \"Знайти фірму з найменшим річним прибутком\"");

            Bold bold19 = new Bold(new Run("7. Пошук інформації про фірму за її назвою"));

            Bold bold20 = new Bold(new Run("1) "));
            Run run13 = new Run("натисніть на пункт \"Інструменти\" навігаційної панелі та виберіть пункт \"Пошук за назвою фірми\"\n");
            Bold bold21 = new Bold(new Run("2) "));
            Run run14 = new Run("введіть назву фірми, інформацію про яку Ви хочете знайти та натисніть кнопку \"Пошук\"");

            Bold bold22 = new Bold(new Run("8. Пошук фірми з найбільшим числом замовлень за рік"));

            Run run15 = new Run("Натисніть на пункт \"Інструменти\" навігаційної панелі та виберіть пункт \"Знайти фірму з найбільшим числом замовлень за рік\"");

            Bold bold23 = new Bold(new Run("9. Пошук фірми з найбільшим річним випуском лайнерів"));

            Run run16 = new Run("Натисніть на пункт \"Інструменти\" навігаційної панелі та виберіть пункт \"Знайти фірму з найбільшим річним випуском лайнерів\"");

            Bold bold24 = new Bold(new Run("10. Перегляд записів, що містяться базі данних з додатковими данними"));

            Run run17 = new Run("Натисніть на пункт \"Інструменти\" навігаційної панелі та виберіть пункт \"Показати додаткові значення\"\nВ результаті Ви побачите таблицю схожу на п.3 з двома новими стовпцями: \"Відсоток виконаних замовлень\" та \"Середній прибуток за літак\"");

            Bold bold25 = new Bold(new Run("11. Вихід з програми"));

            Bold bold26 = new Bold(new Run("1) "));
            Run run18 = new Run("натисніть на пункт \"Вихід\" навігаційної панелі\n");
            Bold bold27 = new Bold(new Run("2) "));
            Run run19 = new Run("у спливаючому вікні, що з'явиться, натисніть кнопку \"Так\"\n\n");

            // Create paragraphs

            Paragraph p1 = new Paragraph();
            p1.FontSize = 18;
            p1.Inlines.Add(bold1);

            Paragraph p2 = new Paragraph();
            p2.Inlines.Add(bold2);
            p2.Inlines.Add(run1);
            p2.Inlines.Add(bold3);
            p2.Inlines.Add(run2);

            Paragraph p3 = new Paragraph();
            p3.FontSize = 18;
            p3.Inlines.Add(bold4);

            Paragraph p4 = new Paragraph();
            p4.Inlines.Add(bold5);
            p4.Inlines.Add(run3);
            p4.Inlines.Add(bold6);
            p4.Inlines.Add(run4);

            Paragraph p5 = new Paragraph();
            p5.FontSize = 18;
            p5.Inlines.Add(bold7);

            Paragraph p6 = new Paragraph();
            p6.Inlines.Add(bold8);
            p6.Inlines.Add(run5);
            p6.Inlines.Add(bold9);
            p6.Inlines.Add(bold10);
            p6.Inlines.Add(run6);
            p6.Inlines.Add(bold11);
            p6.Inlines.Add(run7);

            Paragraph p7 = new Paragraph();
            p7.FontSize = 18;
            p7.Inlines.Add(bold12);

            Paragraph p8 = new Paragraph();
            p8.Inlines.Add(bold13);
            p8.Inlines.Add(run8);
            p8.Inlines.Add(bold14);
            p8.Inlines.Add(run9);
            p8.Inlines.Add(bold16);
            p8.Inlines.Add(run10);

            Paragraph p9 = new Paragraph();
            p9.FontSize = 18;
            p9.Inlines.Add(bold17);

            Paragraph p10 = new Paragraph();
            p10.Inlines.Add(run11);

            Paragraph p11 = new Paragraph();
            p11.FontSize = 18;
            p11.Inlines.Add(bold18);

            Paragraph p12 = new Paragraph();
            p12.Inlines.Add(run12);

            Paragraph p13 = new Paragraph();
            p13.FontSize = 18;
            p13.Inlines.Add(bold19);

            Paragraph p14 = new Paragraph();
            p14.Inlines.Add(bold20);
            p14.Inlines.Add(run13);
            p14.Inlines.Add(bold21);
            p14.Inlines.Add(run14);

            Paragraph p15 = new Paragraph();
            p15.FontSize = 18;
            p15.Inlines.Add(bold22);

            Paragraph p16 = new Paragraph();
            p16.Inlines.Add(run15);

            Paragraph p17 = new Paragraph();
            p17.FontSize = 18;
            p17.Inlines.Add(bold23);

            Paragraph p18 = new Paragraph();
            p18.Inlines.Add(run16);

            Paragraph p19 = new Paragraph();
            p19.FontSize = 18;
            p19.Inlines.Add(bold24);

            Paragraph p20 = new Paragraph();
            p20.Inlines.Add(run17);

            Paragraph p21 = new Paragraph();
            p21.FontSize = 18;
            p21.Inlines.Add(bold25);

            Paragraph p22 = new Paragraph();
            p22.Inlines.Add(bold26);
            p22.Inlines.Add(run18);
            p22.Inlines.Add(bold27);
            p22.Inlines.Add(run19);

            // Add paragraphs to the FlowDocument
            myFlowDoc.Blocks.Add(p1);
            myFlowDoc.Blocks.Add(p2);
            myFlowDoc.Blocks.Add(p3);
            myFlowDoc.Blocks.Add(p4);
            myFlowDoc.Blocks.Add(p5);
            myFlowDoc.Blocks.Add(p6);
            myFlowDoc.Blocks.Add(p7);
            myFlowDoc.Blocks.Add(p8);
            myFlowDoc.Blocks.Add(p9);
            myFlowDoc.Blocks.Add(p10);
            myFlowDoc.Blocks.Add(p11);
            myFlowDoc.Blocks.Add(p12);
            myFlowDoc.Blocks.Add(p13);
            myFlowDoc.Blocks.Add(p14);
            myFlowDoc.Blocks.Add(p15);
            myFlowDoc.Blocks.Add(p16);
            myFlowDoc.Blocks.Add(p17);
            myFlowDoc.Blocks.Add(p18);
            myFlowDoc.Blocks.Add(p19);
            myFlowDoc.Blocks.Add(p20);
            myFlowDoc.Blocks.Add(p21);
            myFlowDoc.Blocks.Add(p22);

            // Add initial content to the RichTextBox
            HelpBox.Document = myFlowDoc;

            // Function to add images to RichTextBox

            /*void AddImage(string filename, int width, int height)
            {
                Uri uri = new Uri("..\\..\\..\\src\\img\\" + filename, UriKind.Relative);
                BitmapImage bitmapImg = new BitmapImage(uri);
                Image image = new Image();
                image.Stretch = Stretch.Fill;
                image.Width = width;
                image.Height = height;
                image.Source = bitmapImg;

                BlockUIContainer container = new BlockUIContainer(image);
                myFlowDoc.Blocks.Add(container);
            }*/

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

        private void MenuItem26_Click(object sender, RoutedEventArgs e)    //Calculate profit per plane for each company
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
