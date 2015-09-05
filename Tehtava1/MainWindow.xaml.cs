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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IIO13200_15S
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double isOkay(string syote, TextBox sender)
        {
            double luku = 0;
            if (syote.Length > 0 && double.TryParse(syote, out luku))
            {
                // It was assigned.
                return luku;
            }
            else
            {
                MessageBox.Show("Tarkista syöte!");
                return 1;
            }
        }

        private void btnCalculate_TextChanged(object sender, TextChangedEventArgs e)
        {
            //sender.Focus();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            
            double WindowsHeight = 1;
            double WindowsWidth = 1;
            double FrameWidth = 1;

            txtWindowsWidth.Background = Brushes.White;
            txtWindowsHeight.Background = Brushes.White;
            txtWindowsFrameWidth.Background = Brushes.White;

            if (Double.TryParse(txtWindowsHeight.Text, out WindowsHeight))
            {
                // It was assigned.
            }
            else
            {
                txtWindowsHeight.Background = Brushes.Red;
            }
            if (Double.TryParse(txtWindowsWidth.Text, out WindowsWidth))
            {
                // It was assigned.
            }
            else
            {
                txtWindowsWidth.Background = Brushes.Red;
            }
            if (Double.TryParse(txtWindowsFrameWidth.Text, out FrameWidth))
            {
                // It was assigned.
            }
            else
            {
                txtWindowsFrameWidth.Background = Brushes.Red;
            }





            double WindowsArea = WindowsHeight * WindowsWidth;
            double FrameLength = WindowsHeight + WindowsHeight + WindowsWidth + WindowsWidth;
            double FrameArea = WindowsWidth * FrameWidth + WindowsHeight * FrameWidth;


            txtWindowsArea.Text = WindowsArea.ToString();
            txtFrameLength.Text = FrameLength.ToString();
            txtFrameArea.Text = FrameArea.ToString();
        }
    }
}
