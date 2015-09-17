using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;


namespace Test4XML
{
    /// <summary>
    /// Interaction logic for ViinikellariDataSet.xaml
    /// </summary>
    public partial class ViinikellariDataSet : Window
    {
        public ViinikellariDataSet()
        {
            InitializeComponent();
        }


        private void btnHaeViinit_Click_1(object sender, RoutedEventArgs e)
        {
            //luetaan koko XML Datasettiin

            try {
                string filu = @"D:/K2362/IIO13200_NET_15S/Test4XML/Viinit1.xml";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataView dv = new DataView();
                ds.ReadXml(filu);
                dt = ds.Tables[0];
                dv = dt.DefaultView;
                dgViinit.ItemsSource = dv;

            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
