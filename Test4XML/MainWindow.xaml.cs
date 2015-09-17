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
using System.Xml;
using System.Xml.Linq;
using System.Data;

namespace Test4XML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitFields();
        }

        private void InitFields()
        {
            cbFiltter.Items.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load("D://K2362/IIO13200_NET_15S/Test4XML/Viinit1.xml");
            XmlNodeList nodeList = doc.SelectNodes("viinikellari/wine");

            foreach (XmlNode node in nodeList)
                if (!cbFiltter.Items.Contains(node.SelectSingleNode("maa").InnerText))
                {
                    cbFiltter.Items.Add(node.SelectSingleNode("maa").InnerText);
                }
                    
        }


        private void UpdateFiltter()
        {
            //D://K2362/IIO13200_NET_15S/Test4XML/Viinit1.xml
            //http://student.labranet.jamk.fi/~salesa/iio11300/mat/Viinit1.xml
            /*XDocument xmlDoc = XDocument.Load("D://K2362/IIO13200_NET_15S/Test4XML/Viinit1.xml");

            var persons = from wine in xmlDoc.Descendants("viinikellari")
                            where wine.Element("maa").Value == cbFiltter.SelectedItem.ToString()
                            select new
                            {
                                nimi = wine.Element("nimi").Value,
                                maa = wine.Element("maa").Value,
                                arvio = wine.Element("arvio").Value,
                            };

            //dgWines.DataContext = ""; //clear preloaded data
           // dgWines.ItemsSource = "";
            //ItemsControl a = dgWines.ItemsSource;
            // dgWines.Items.Add("nimi,maa,arvio");

            /*foreach (var wine in viinikellari)
             {
                 richTextBox1.Text = richTextBox1.Text + "nmi: " + wine.nimi + "\n";
                 richTextBox1.Text = richTextBox1.Text + "maa: " + wine.maa + "\n";
                 richTextBox1.Text = richTextBox1.Text + "arvio: " + wine.arvio + "\n\n";
             }

             if (richTextBox1.Text == "")
                 richTextBox1.Text = "No Results.";*/


            try
            {
                string filu = @"D:/K2362/IIO13200_NET_15S/Test4XML/Viinit1.xml";
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataView dv = new DataView();
                ds.ReadXml(filu);
                dt = ds.Tables[0];
                //for(int i=0; i < dt.Rows.Count(); i++)
                // {
                //MessageBox.Show(dt.Rows.Find(0).ToString());
                //MessageBox.Show(dt.Rows.Count.ToString());
                //}

                dv = dt.DefaultView;
                dv.RowFilter = ("maa = '" + cbFiltter.SelectedItem.ToString() +"'");
                dgWines.ItemsSource = dv;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //Changed filtter
        private void cbFiltter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }


        //Button GetWine clicked
        private void btnGetWine_Click(object sender, RoutedEventArgs e)
        {
           /* string a = "";
            for (int i=dgWines.Items.Count-1; i >= 0; i--)
            {
                dgWines.Items.IsLiveFiltering = true;
            }
            MessageBox.Show(a);*/
            UpdateFiltter();
        }
    }
}
