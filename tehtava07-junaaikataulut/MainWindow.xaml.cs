using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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



namespace tehtava07_junaaikataulut
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

        private string json = "";

        private string GetSimpleJsonFromWeb()
        {
            try
            {
                //string url = string.Format("http://rata.digitraffic.fi/api/v1/live-trains?station=JY");
                string url = string.Format("http://student.labranet.jamk.fi/~K2362/dotNET/live-trains.json");

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
                throw ex;
                return "{ERROR}";
            }
        }


        private void Demo2()
        {
            //haetaan json
            json = GetSimpleJsonFromWeb();
            // muunnetaan olioksi
            List<JunaClass> junat = JsonConvert.DeserializeObject<List<JunaClass>>(json);
            //Näytetään UI:ssa
            //txtJson.Text = json;
            dgData.DataContext = junat;
        }

        private void btnGetTimes_Click(object sender, RoutedEventArgs e)
        {
            Demo2();
        }
    }
}
