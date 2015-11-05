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
using System.Threading;
using System.Configuration;


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
            GetStations();
        }

        private string json = "";
        private List<StationsClass> asemat = new List<StationsClass>();
        private string fileUrl = ConfigurationManager.AppSettings["StationsJSON"] ?? "http://student.labranet.jamk.fi/~K2362/dotNET/stations.json"; //Get list address from config

        private string GetSimpleJsonFromWeb(string addressUrl)
        {
            try
            {
                string url = string.Format(addressUrl);

                //when "using" we do not leave webclient in memory
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    var json = wc.DownloadString(url);
                    return json;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load url=" + addressUrl + "\nCheck that url in config file is valid \nand you have working internet connection!");
                throw ex;
            }
        }


        private async void GetTrains()
        {
            string filtter = "";
            //check if filtter selected
            int sltFiltterInt = cbStations.SelectedIndex;
            if (sltFiltterInt >= 0) //We have filtter
            {
                string sltFiltterName = cbStations.SelectedItem.ToString();
                //find shortcode
                filtter = "?station=" + asemat.Find(x => x.name.Contains(sltFiltterName)).shortCode;
            }


            //haetaan json
            lbStatus.Content = "Downloading trains shedule... with filtter=" +filtter;
            //json = GetSimpleJsonFromWeb("http://rata.digitraffic.fi/api/v1/live-trains?station=JY");
            //json = GetSimpleJsonFromWeb("http://student.labranet.jamk.fi/~K2362/dotNET/live-trains.json");
            //json = await LongRunningMethodAsync("http://student.labranet.jamk.fi/~K2362/dotNET/live-trains.json"); //DEBUG
            json = await LongRunningMethodAsync("http://rata.digitraffic.fi/api/v1/live-trains" + filtter); //REAL - use with cautiously
            // muunnetaan olioksi
            lbStatus.Content = "Creating trains shedule...";
            List<JunaClass> junat = JsonConvert.DeserializeObject<List<JunaClass>>(json);
            //Näytetään UI:ssa
            dgData.DataContext = junat;
            lbStatus.Content = "Get trains shedule";
        }

        private async void GetStations()
        {
            //haetaan json
            lbStatus.Content = "Downloading list of stations...";
            //json = GetSimpleJsonFromWeb("http://student.labranet.jamk.fi/~K2362/dotNET/stations.json");
            //json = await LongRunningMethodAsync("http://student.labranet.jamk.fi/~K2362/dotNET/stations.json");
            
            json = await LongRunningMethodAsync(fileUrl);
            // muunnetaan olioksi & tallenna
            asemat = JsonConvert.DeserializeObject<List<StationsClass>>(json);
            //Näytetään UI:ssa
            lbStatus.Content = "Creating list of stations...";
            cbStations.Items.Clear();
            foreach (StationsClass asema in asemat)
                cbStations.Items.Add(asema.name);
            if (cbStations.Items.Count > 1)
            {
                lbStatus.Content = "List of stations created!";
            }
            else
            {
                lbStatus.Content = "Creating list of stations failed!";
            }
            
        }


        private void btnGetTimes_Click(object sender, RoutedEventArgs e)
        {
            GetTrains();
        }


        //Method requided to use async
        private Task<string> LongRunningMethodAsync(string message)
        {
            return Task.Run<string>(() => GetSimpleJsonFromWeb(message));
        }
    }
}
