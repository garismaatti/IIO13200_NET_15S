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
            txtRows.Focus();
            txtRows.SelectAll();
        }

        Tehtävä2___lotto.Lotto newGame = new Tehtävä2___lotto.Lotto();
        int lastGame = -1;

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            int rws = 0;
            if (int.TryParse(txtRows.Text, out rws))
            {
                if (rws < 0)
                {
                    //check validity
                    txtRows.Background = Brushes.Red;
                    MessageBox.Show("Rivien lukumäärä ei voi olla negatiivinen!");
                    txtRows.Background = Brushes.White;
                }
                else
                {
                    if (rws > 99)
                    {
                        MessageBoxResult result = MessageBox.Show("Hupsista! Yrität luoda yli 100 riviä kerralla!\nEmme suosittele luomaan yli 100 riviä kerralla vaan generoi esimerkiksi 10 riviä useampaan kertaan.\n\nToiminnon suorittaminen saattaa kestää pitkään ja aiheuttaa häiriöitä tietokoneen muuhun toimintoihin. Haluatko silti jatkaa?", "Vahvista rivien generointi!", MessageBoxButton.YesNo ,MessageBoxImage.Warning);

                        if (result == MessageBoxResult.No)
                        {
                            rws = 0;
                        }
                    }
                }
            }
            else
            {
                //Failed to parse int
                txtRows.Background = Brushes.Red;
                MessageBox.Show("Anna kelvollinen rivien lukumäärä!");
                txtRows.Background = Brushes.White;
            }
            if (lastGame != cbxGameSelector.SelectedIndex)
            {
                lbxResult.Items.Add("");//spacer
                lbxResult.Items.Add(cbxGameSelector.Text); //add game name
            }
            
            List<string> lista = newGame.drawLottery(cbxGameSelector.SelectedIndex, rws);
            for (int j=lista.Count-1; j >= 0; j--)
            {
                lbxResult.Items.Add( lista.ElementAt(j) );
                lbxResult.SelectedIndex = lbxResult.Items.Count - 1;
                lbxResult.ScrollIntoView(lbxResult.SelectedItem);
            }
            //more comfort
            txtRows.Focus();
            txtRows.SelectAll();
            //update last game
            lastGame = cbxGameSelector.SelectedIndex;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lbxResult.Items.Clear();
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Oletko varma että haluat sulkea ohjelman?\nKaikki tallentamattomat tiedot menetetään!", "Vahvista sulkeminen", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Close();
            }
            
        }


        //just making it more comfortable to use
        private void cbxGameSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtRows.Focus();
            txtRows.SelectAll();
        }
    }
}
