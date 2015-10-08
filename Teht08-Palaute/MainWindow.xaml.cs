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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Teht08_Palaute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// // http://www.codeproject.com/Articles/26875/WPF-XmlDataProvider-Two-Way-Data-Binding
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            string filu = @"http://student.labranet.jamk.fi/~salesa/iio13200/Palautteet.xml";
            doc.LoadXml(filu);
            lbBad.Content = doc.ChildNodes.ToString();
        }

        private void btnRead_Click(object sender, RoutedEventArgs e)
        {
            //luetaan koko XML Datasettiin

            try
            {
                string filu = @"http://student.labranet.jamk.fi/~salesa/iio13200/Palautteet.xml";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataView dv = new DataView();
                ds.ReadXml(filu);
                dt = ds.Tables[0];
                dv = dt.DefaultView;
                dgList.ItemsSource = dv;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
