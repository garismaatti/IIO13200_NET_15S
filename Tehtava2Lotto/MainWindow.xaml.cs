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

namespace Tehtava2Lotto
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

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lbxResult.Items.Clear();
        }

        private void cbxGameSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Oletko varma että haluat sulkea ohjelman?\nKaikki tallentamattomat tiedot menetetään!", "Vahvista sulkeminen", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
            
        }
    }
}
