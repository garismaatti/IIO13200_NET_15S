﻿using System;
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
using System.IO;

namespace Tehtava3_SM_liiga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //AddMockupData();    //add mockup data
            ReadFromFile();
            UpdateTeamList();   // update team list
            UpdateListView();   // update Player list
            cbTeam.SelectedIndex = 0; //select first item
        }



        private List<Seura> NHL = new List<Seura>();
        private string fileName = "database.csv";

        private void AddMockupData()
        {
            string[] seuroja = { "Blues", "HIFK", "HPK", "Ilves", "JYP", "KalPa", "KooKoo", "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät" };

            for (int u = 0; u < seuroja.Length; u++)
            {
                Seura seura = new Seura();
                seura.SeuraNimi = seuroja[u];
                if (u == 0)
                {
                    seura.AddPlayer("Eero", "Somervuori", seura.SeuraNimi, 22000);
                    seura.AddPlayer("Ilkka", "Kangasniemi", seura.SeuraNimi, 27800);
                    seura.AddPlayer("Robert", "Rooba", seura.SeuraNimi, 72893);
                }
                else if (u == 1)
                {
                    seura.AddPlayer("Yohann", "Auvitu", seura.SeuraNimi, 22000);
                    seura.AddPlayer("Corey", "Elkins", seura.SeuraNimi, 27800);
                    seura.AddPlayer("Eemeli", "Heikkinen", seura.SeuraNimi, 72893);
                }

                NHL.Add(seura);
            }
            lbStatusBar.Content = "Testi data kirjoitettu tietokantaan!";
        }

        public int GetSelectedTeam()
        {
            int i = cbTeam.SelectedIndex;
            if (i < 0)
            {
                return 0;
            }
            else
            {
                return i;
            }
        }

        public int GetSelectedPlayer()
        {
            int i = lstPelaajat.SelectedIndex;
            if (i < 0)
            {
                return 0;
            }
            else
            {
                return i;
            }
        }

        public void UpdateListView()    //Update list object in GUI
        {
            List<Pelaaja> players = new List<Pelaaja>();
            Pelaaja player = new Pelaaja();
            Seura seura = new Seura();
            //cbTeam.Items.Clear();   //clear list
            lstPelaajat.Items.Clear();

            int i = GetSelectedTeam();
            if (NHL.Count > 0) { 
                seura = NHL.ElementAt(i);
                //cbTeam.Items.Add(seura.SeuraNimi);  //Add Seura

                players = seura.GetPlayers();
                for (int j = 0; j < players.Count(); j++) //For every player in players list in Seura
                {
                    player = players.ElementAt(j);
                    lstPelaajat.Items.Add(player.KokoNimi); //Add player to list
                }
            }

        }


        public void UpdateTeamList()    //Update team list in GUI
        {
            Seura seura = new Seura();
            cbTeam.Items.Clear();   //clear list

            //int i = GetSelectedTeam();
            for (int i = 0; i < NHL.Count(); i++) //For every Seura
            {
                seura = NHL.ElementAt(i);
                cbTeam.Items.Add(seura.SeuraNimi);  //Add Seura
            }





        }

        public void UpdatePlayerInfo()
        {
            int i = GetSelectedPlayer();
            //check if within limits
            if (i >= 0 && i < NHL.ElementAt(GetSelectedTeam()).GetPlayers().Count)
            {
                Pelaaja a = NHL.ElementAt(GetSelectedTeam()).GetPlayers().ElementAt(i);
                txtFirstName.Text = a.Etunimi;
                txtLastName.Text = a.Sukunimi;
                txtTransferPrice.Text = a.Siirtohinta.ToString();
            }
            else
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtTransferPrice.Text = "";
            }
            
        }





        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbStatusBar.Content = "Seura vaihtui '" + NHL.ElementAt(GetSelectedTeam()).SeuraNimi + "' ";
            UpdateListView();
            UpdatePlayerInfo();
        }

        private void lstPelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePlayerInfo();
        }

        private void btnAddPlayer_Click(object sender, RoutedEventArgs e)
        {

            Seura seura = new Seura();
            if (NHL.Count > GetSelectedTeam())
            {
                seura = NHL.ElementAt(GetSelectedTeam());
                string f = txtFirstName.Text;
                string l = txtLastName.Text;
                float p = 0;
                if (float.TryParse(txtTransferPrice.Text, out p))
                {
                    // is value
                    txtTransferPrice.Background = Brushes.White;

                    if (seura.AddPlayer(f, l, seura.SeuraNimi, p))
                    {
                        lbStatusBar.Content = "Pelaajaa ei lisätty! Pelaaja '" + f + " " + l + ", " + seura.SeuraNimi + "' on jo tietokannassa!";
                    }
                    else
                    {
                        lbStatusBar.Content = "Pelaaja '" + f + " " + l + ", " + seura.SeuraNimi + "' lisätty!";
                    }
                    UpdateListView();
                    lstPelaajat.SelectedIndex = lstPelaajat.Items.Count - 1;
                }
                else
                {
                    p = 0;
                    txtTransferPrice.Background = Brushes.Red;
                    lbStatusBar.Content = "Pelaajan Siirtohinta ei saa sisältää muuta kuin numeroita ja pilkun!";
                }
            }


            
        }

        private void btnRemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            Seura seura = new Seura();
            if (NHL.Count > GetSelectedTeam())
            {
                seura = NHL.ElementAt(GetSelectedTeam());
                string name = seura.GetPlayers().ElementAt(GetSelectedPlayer()).KokoNimi;
                lbStatusBar.Content = "Pelaaja '" + name + "' poistettu!";
                seura.RemovePlayer(GetSelectedPlayer());
            }
            UpdateListView();
        }

        private void btnSavePlayer_Click(object sender, RoutedEventArgs e)
        {

            Seura seura = new Seura();
            if (NHL.Count > GetSelectedTeam())
            {
                seura = NHL.ElementAt(GetSelectedTeam());

                string f = txtFirstName.Text;
                string l = txtLastName.Text;
                float p = 0;
                if (float.TryParse(txtTransferPrice.Text, out p))
                {
                    // is value
                    txtTransferPrice.Background = Brushes.White;

                    seura.UpdatePlayer(GetSelectedPlayer(), f, l, seura.SeuraNimi, p);

                    lbStatusBar.Content = "Pelaaja '" + f + " " + l + ", " + seura.SeuraNimi + "' päivitetty!";
                    UpdateListView();
                }
                else
                {
                    p = 0;
                    txtTransferPrice.Background = Brushes.Red;
                    lbStatusBar.Content = "Pelaajan Siirtohinta ei saa sisältää muuta kuin numeroita ja pilkun!";
                }
            }
            
        }

        private void btnWritePlayers_Click(object sender, RoutedEventArgs e)
        {
            WriteToFile();
            //MessageBox.Show("Tiedosto tallennettu!");
            lbStatusBar.Content = "Pelaajat tallennettu tiedostoon '" +fileName +"'!";
            //ReadFromFile();
        }


        private void ReadFromFile()
        {
            Seura seura = new Seura();
            List<string> seuroja = new List<string>();
            bool foundSeura = false;

            // Read in every line in specified file.
            // ... This will store all lines in an array in memory.
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                // Do something with the line.
                string[] row = line.Split(';');
                //MessageBox.Show(row[0].ToString());


                foundSeura = false; //reset value
                for (int i = 0; i < NHL.Count(); i++) //For every Seura
                {
                    seura = NHL.ElementAt(i);
                    if (seura.SeuraNimi == row[2])  //seura exits
                    {
                        float p = 0; //value
                        if (float.TryParse(row[3], out p))  //try parse value
                        {

                        }
                        seura.AddPlayer(row[0], row[1], row[2], p);
                        foundSeura = true;
                    }
                }

                if (!foundSeura && row[2]!="Seura")
                {
                    //Seura does not yet exist
                    //MessageBox.Show("Not found " +row[2]);
                    seura = new Seura();
                    seura.SeuraNimi = row[2];

                    float p = 0; //value
                    if (float.TryParse(row[3], out p))  //try parse value
                    {

                    }
                    seura.AddPlayer(row[0], row[1], row[2], p);
                    NHL.Add(seura); //Add seura
                }
            }
            UpdateTeamList();
        }


        private void WriteToFile()
        {
            
            string strRow = "";

            File.WriteAllText(fileName, "Etunimi;Sukunimi;Seura;Siirtohinta\n");
           

            List<Pelaaja> players = new List<Pelaaja>();
            Pelaaja player = new Pelaaja();
            Seura seura = new Seura();

            //int i = GetSelectedTeam();
            for (int i = 0; i < NHL.Count(); i++) //For every Seura
            {


                seura = NHL.ElementAt(i);
                players = seura.GetPlayers();

                for (int j = 0; j < players.Count(); j++) //For every player in players list in Seura
                {
                    player = players.ElementAt(j);
                    strRow = player.Etunimi;
                    strRow += ";"; 
                    strRow += player.Sukunimi;
                    strRow += ";";
                    strRow += player.Seura;
                    strRow += ";";
                    strRow += player.Siirtohinta;
                    strRow += "\n";
                    File.AppendAllText(fileName, strRow);
                }

            }
            
        }
    }
}
