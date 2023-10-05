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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Wpf_FastFoodOrder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
           
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            time.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            bill.AppendText("\n ##Your Order## Date"+DateTime.Now+"##############\t\n hgjhruzurz");
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            bill.Document.Blocks.Clear();
        }

        private void print_Click_1(object sender, RoutedEventArgs e)
        {

            // Create a new window to display the content
            Window viewWindow = new Window
            {
                Title = "Bill befor Print",
                Width = 400,
                Height = 700,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Owner = this
            };

            // Create a TextBlock to display the content
            TextBlock textBlock = new TextBlock
            {
                Text = new TextRange(bill.Document.ContentStart, bill.Document.ContentEnd).Text,
                Margin = new Thickness(10)
            };

            // Add the TextBlock to the window's content
            viewWindow.Content = textBlock;

            // Show the window
            viewWindow.ShowDialog();



            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                // Clone the FlowDocument to avoid modifying the original content
                FlowDocument cloneDocument = CloneFlowDocument(bill.Document);

                // Set up a DocumentPaginator for printing
                IDocumentPaginatorSource paginatorSource = cloneDocument;
                printDialog.PrintDocument(paginatorSource.DocumentPaginator, "Printing RichTextBox Content");
            }
        }

        private FlowDocument CloneFlowDocument(FlowDocument original)
            {
                // Serialize and then deserialize the FlowDocument to create a deep copy
                string xamlText = XamlWriter.Save(original);
                FlowDocument clone = XamlReader.Parse(xamlText) as FlowDocument;

                return clone;
            }
        }
    }
