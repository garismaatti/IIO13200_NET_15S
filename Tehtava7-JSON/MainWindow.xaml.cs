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
using Newtonsoft.Json; //for json parser
using System.Net;   //For webclient-class
using System.Threading; //for async

namespace Tehtava7_JSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string json = "";

        public MainWindow()
        {
            InitializeComponent();
        }

       // #region Methods

        private void Demo1()
        {
            //haetaan json
            json = GetSimpleJson();
            // muunnetaan olioksi
            List<Person> persoonat = JsonConvert.DeserializeObject<List<Person>>(json);
            //Näytetään UI:ssa
            txtJson.Text = json;
            dgData.DataContext = persoonat;
        }

        private void Demo2()
        {
            //haetaan json
            json = GetSimpleJsonFromWeb();
            // muunnetaan olioksi
            List<Politic> persoonat = JsonConvert.DeserializeObject<List<Politic>>(json);
            //Näytetään UI:ssa
            txtJson.Text = json;
            dgData.DataContext = persoonat;
        }

      /*  private string getUrl()
        {
            return txtJson.Text.ToString();
            //return "http://student.labranet.jamk.fi/~salesa/mat/JsonTest";
        }*/

        private void Demo3Async()
        {
            //haetaan json oikeesti webistä omassa threadisas
            lbError.Content = "Haetaan dataa...";
            new Thread(() =>
            {
                string result = GetSimpleJsonFromWeb();
            Dispatcher.BeginInvoke((Action)(() =>
                 {
                     try {
                         List<Politic> persoonat = JsonConvert.DeserializeObject<List<Politic>>(result);
                         //Näytetään UI:ssa
                         //txtJson.Text = json;
                         dgData.DataContext = persoonat;
                         lbError.Content = "Complete!";
                     }
                     catch (Exception ex)
                     {
                         lbError.Content = "Error! = " + ex.Source.ToString();
                     }
                     
                     
                 }));
            }).Start();
            //txtJson.Text = "Haetaan...";
            
        }


        private string GetSimpleJson()
        {
            return @"[{'Name':'Olli Opiskelija','Gender':'Male','Birthday':'1995-12-24'},{'Name':'Matti Mainio','Gender':'Male','Birthday':'1985-12-25'}]";
        }

        private string GetSimpleJsonFromWeb()
        {
           try
            {
                string url = string.Format("http://student.labranet.jamk.fi/~salesa/mat/JsonTest");
                //string url = string.Format(txtJson.Text);
                //when using "using" we do not leave webclient in memory
                using (WebClient wc = new WebClient())
                {
                    var json = wc.DownloadString(url);
                    //lbError.Content = "Complete!";

                    return json;
                }

            }
            catch (Exception ex)
            {
                //throw ex;
                return "{ERROR}";
            }
        }

        private void btnGetJson_Click(object sender, RoutedEventArgs e)
        {
            Demo3Async();
            
        }
    }
}
