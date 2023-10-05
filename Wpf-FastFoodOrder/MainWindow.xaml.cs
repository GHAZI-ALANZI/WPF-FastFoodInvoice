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
            time.Content = DateTime.Now.ToString("dd'-'MM'-'yy'  'HH:mm:ss");
        }

        //######## ADD TO  BILL##################################//



        private void add_Click(object sender, RoutedEventArgs e)
        {
            bill.Document.Blocks.Clear();
            bill.AppendText("GH RESTURANT  VIENNA 1100\n *****Your Order****\n InvoicNr##" + DateTime.Now.ToString("dd''MM''yy''HH''mm''ss##") +"\n Date " + DateTime.Now.ToString("dd'-'MM'-'yy' 'HH':'mm':'ss")+"\n####################" );


            double sum=0;
            double sumtax=0;


            if (friescb.IsChecked==true && friestb.Text !="0" ) {


                var total = Convert.ToDouble(friestb.Text) * 12;
                sum=total;
                sumtax = total + (total * 0.2);

                bill.AppendText( $"\n{friestb.Text}x Friet :{ total}€\n****************");

                totalitems.Text=sum.ToString()+ "€";
                totalitemstax.Text=sumtax.ToString() + "€";

            }
            if (burgercb.IsChecked == true && burgertb.Text != "0")
            {
                var total1 = Convert.ToDouble(burgertb.Text) * 50;
                sum += total1;
                sumtax += total1 + (total1 * 0.2);
               

                bill.AppendText( $"\n{burgertb.Text}x Burger :{total1}€\n****************");
                totalitems.Text = sum.ToString() + "€";
                totalitemstax.Text = sumtax.ToString() + "€";
            }
            if (nuggetcb.IsChecked == true && nuggettb.Text != "0")
            {
                var total2 = Convert.ToDouble(nuggettb.Text) * 50;
                sum += total2;
                sumtax += total2 + (total2 * 0.2);

                bill.AppendText($"\n {nuggettb.Text}x Nuggets :{total2}€\n****************");
                totalitems.Text = sum.ToString() + "€";
                totalitemstax.Text = sumtax.ToString() + "€";
            }
            if (pizzacb.IsChecked == true && pizzatb.Text != "0")
            {
                var total3 = Convert.ToDouble(pizzatb.Text) * 20;
                sum += total3;
                sumtax += total3 + (total3 * 0.2);

                bill.AppendText($"\n {burgertb.Text}x Pitzza:{total3}€\n****************");
                totalitems.Text = sum.ToString() + "€";
                totalitemstax.Text = sumtax.ToString() + "€";
            }

            if (colacb.IsChecked == true && colatb.Text != "0")
            {
                var total4 = Convert.ToDouble(colatb.Text) * 2;
                sum += total4;
                sumtax += total4 + (total4 * 0.2);

                bill.AppendText($"\n {colatb.Text}x Cola:{total4}€\n****************");
                totalitems.Text = sum.ToString() + "€";
                totalitemstax.Text = sumtax.ToString() + "€";
            }

            if (fantacb.IsChecked == true && fantatb.Text != "0")
            {
                var total5 = Convert.ToDouble(fantatb.Text) * 2;
                sum += total5;
                sumtax += total5 + (total5 * 0.2);

                bill.AppendText($"\n {fantatb.Text}x Fanta:{total5}€\n****************");
                totalitems.Text = sum.ToString() + "€";
                totalitemstax.Text = sumtax.ToString() + "€";
            }
            if (_7upcb.IsChecked == true && _7uptb.Text != "0")
            {
                var total6 = Convert.ToDouble(_7uptb.Text) * 2;
                sum += total6;
                sumtax += total6 + (total6 * 0.2);

                bill.AppendText($"\n {_7uptb.Text}x 7up:{total6}€\n****************");
                totalitems.Text = sum.ToString() + "€";
                totalitemstax.Text = sumtax.ToString() + "€";
            }

            if (coctilcb.IsChecked == true && coctiltb.Text != "0")
            {
                var total7 = Convert.ToDouble(coctiltb.Text) * 7;
                sum += total7;
                sumtax += total7 + (total7 * 0.2);

                bill.AppendText($"\n {coctiltb.Text}x Coctil:{total7}€\n****************");
                totalitems.Text = sum.ToString() + "€";
                totalitemstax.Text = sumtax.ToString() + "€";
            }


            bill.AppendText($"\n Total:{sum}€");
            bill.AppendText($"\n TotalwithTax:{sumtax}€");




        }

        //########END ADD TO  BILL##################################//




        //######## REST BILL##################################//


        private void reset_Click(object sender, RoutedEventArgs e)
        {
            //unchecked and return value to 0

            friescb.IsChecked= false;friestb.Text ="0";
            burgercb.IsChecked= false; burgertb.Text = "0";
            nuggetcb.IsChecked= false; nuggettb.Text = "0";
            pizzacb.IsChecked= false; pizzatb.Text = "0";
            colacb.IsChecked= false; colatb.Text = "0";
            fantacb.IsChecked= false; fantatb.Text = "0";
            _7upcb.IsChecked= false; _7uptb.Text = "0";
            coctilcb.IsChecked= false; coctiltb.Text = "0";

            //clear contect of reciept

            bill.Document.Blocks.Clear();
        }
        //######## END REST BILL##################################//*********************************




        //########PRINT BILL##################################//

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



        //######## END  PRINT BILL##################################//***********************************





        //######## INCREASE BUTTON ##################################//
        private void frietplus_Click(object sender, RoutedEventArgs e)
        {     // Get the current value from the TextBox
            if (int.TryParse(friestb.Text, out int currentValue))
            {
                // Increment the value
                int newValue = currentValue + 1;

                // Update the TextBox with the new value
                friestb.Text = newValue.ToString();

             
            }
         }

        private void burgerplus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(burgertb.Text, out int currentValue))
            {
                // Increment the value
                int newValue = currentValue + 1;

                // Update the TextBox with the new value
                burgertb.Text = newValue.ToString();


            }
        }

        private void nuggetplus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(nuggettb.Text, out int currentValue))
            {
                // Increment the value
                int newValue = currentValue + 1;

                // Update the TextBox with the new value
                nuggettb.Text = newValue.ToString();


            }
        }

        private void pitzzaplus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(pizzatb.Text, out int currentValue))
            {
                // Increment the value
                int newValue = currentValue + 1;

                // Update the TextBox with the new value
                pizzatb.Text = newValue.ToString();


            }
        }

        private void colaplus_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(colatb.Text, out int currentValue))
            {
                // Increment the value
                int newValue = currentValue + 1;

                // Update the TextBox with the new value
                colatb.Text = newValue.ToString();


            }
        }

        private void fantaplus_Click(object sender, RoutedEventArgs e)
        {


            if (int.TryParse(fantatb.Text, out int currentValue))
            {
                // Increment the value
                int newValue = currentValue + 1;

                // Update the TextBox with the new value
                fantatb.Text = newValue.ToString();


            }

        }

        private void upplus_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(_7uptb.Text, out int currentValue))
            {
                // Increment the value
                int newValue = currentValue + 1;

                // Update the TextBox with the new value
                _7uptb.Text = newValue.ToString();


            }


        }
        private void coctilplus_Click(object sender, RoutedEventArgs e)
        {


            if (int.TryParse(coctiltb.Text, out int currentValue))
            {
                // Increment the value
                int newValue = currentValue + 1;

                // Update the TextBox with the new value
                coctiltb.Text = newValue.ToString();


            }



        }

        //########END INCREASE BUTTON ##################################//********************




        //######## DECCREASE BUTTON ##################################//

        private void frietmin_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(friestb.Text, out int currentValue) && friestb.Text != "0")
            {
                // deccrement the value
                int newValue = currentValue - 1;

                // Update the TextBox with the new value
                friestb.Text = newValue.ToString();


            }
        }

        private void burgermin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(burgertb.Text, out int currentValue)&& burgertb.Text!="0")
            {
                // deccrement the value
                int newValue = currentValue - 1;

                // Update the TextBox with the new value
                burgertb.Text = newValue.ToString();


            }
        }

        private void nuggetmin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(nuggettb.Text, out int currentValue) && nuggettb.Text != "0")
            {
                // deccrement the value
                int newValue = currentValue - 1;

                // Update the TextBox with the new value
                nuggettb.Text = newValue.ToString();


            }
        }

        private void pitzzamin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(pizzatb.Text, out int currentValue) && pizzatb.Text != "0")
            {
                // deccrement the value
                int newValue = currentValue - 1;

                // Update the TextBox with the new value
                pizzatb.Text = newValue.ToString();


            }
        }

        private void colamin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(colatb.Text, out int currentValue) && colatb.Text != "0")
            {
                // deccrement the value
                int newValue = currentValue - 1;

                // Update the TextBox with the new value
                colatb.Text = newValue.ToString();


            }
        }

        private void fantamin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(fantatb.Text, out int currentValue) && fantatb.Text != "0")
            {
                // deccrement the value
                int newValue = currentValue - 1;

                // Update the TextBox with the new value
                fantatb.Text = newValue.ToString();


            }
        }

        private void upmin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(_7uptb.Text, out int currentValue) && _7uptb.Text != "0")
            {
                // deccrement the value
                int newValue = currentValue - 1;

                // Update the TextBox with the new value
                _7uptb.Text = newValue.ToString();


            }
        }

        private void coctilmin_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(coctiltb.Text, out int currentValue) && coctiltb.Text != "0")
            {
                // deccrement the value
                int newValue = currentValue - 1;

                // Update the TextBox with the new value
                coctiltb.Text = newValue.ToString();


            }
        }
        //########END DECCREASE BUTTON ##################################//*****************
    }


}
