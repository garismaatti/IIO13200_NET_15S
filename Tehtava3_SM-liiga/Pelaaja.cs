using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava3_SM_liiga
{
    /*Tee ensimmäiseksi luokka Pelaaja, jolla on ominaisuudet 
    Etunimi, 
    Sukunimi, 
    KokoNimi, 
    Seura, 
    Siirtohinta. 
    
    KokoNimi on read-only tyyppinen ominaisuus, joka muodostetaan etunimi+sukunimi+,seura  siis esim: "Raimo Helminen, Ilves". 
    Suunnittele ja toteuta luokalle tarvittavat konstruktorit ja metodit. 
    */
    class Pelaaja
    {
        private string firstName_my = "";
        private string lastName_my = "";
        private string team_my = "";
        private float transferPrice_my = 0;


        public string Etunimi
        {
            get
            {
                return this.firstName_my;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.firstName_my = value;
                }

            }
        }

        public string Sukunimi
        {
            get
            {
                return this.lastName_my;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.lastName_my = value;
                }

            }
        }


        public string KokoNimi
        {
            get
            {
                return this.firstName_my + " " + this.lastName_my + ", " + this.team_my;
            }
        }

        public string Seura
        {
            get
            {
                return this.team_my;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.team_my = value;
                }

            }
        }

        public float Siirtohinta
        {
            get
            {
                return this.transferPrice_my;
            }
            set
            {
                if (value >= 0)
                {
                    this.transferPrice_my = value;
                }

            }
        }
    }


    class Seura
    {
        private List<Pelaaja> team = new List<Pelaaja>();
        private string teamName_my = "";
        public string SeuraNimi
        {
            get
            {
                return this.teamName_my;
            }
            set
            {
                if (value.Length > 0)
                {
                    this.teamName_my = value;
                }

            }
        }


        public bool AddPlayer(string n_firstName, string n_lastName, string n_team, float n_price)
        {
            Pelaaja n_player = new Pelaaja();
            n_player.Etunimi = n_firstName;
            n_player.Sukunimi = n_lastName;
            n_player.Seura = n_team;
            n_player.Siirtohinta = n_price;

            Pelaaja old_player = new Pelaaja();
            for (int x = 0; x < team.Count; x++)
            {
                old_player = team.ElementAt(x);
                if (old_player.KokoNimi == n_player.KokoNimi)
                {
                    //Same name player found! exit
                    return true;
                }
            }
            //no same name player found, add player to database
            team.Add(n_player);
            return false;
        }

        public void RemovePlayer(int index)
        {
            team.RemoveAt(index);
        }

        public void UpdatePlayer(int index, string n_firstName, string n_lastName, string n_team, float n_price)
        {
            team.ElementAt(index).Etunimi = n_firstName;
            team.ElementAt(index).Sukunimi = n_lastName;
            team.ElementAt(index).Seura = n_team;
            team.ElementAt(index).Siirtohinta = n_price;
        }

        public List<Pelaaja> GetPlayers()
        {
            return team;
        }

    }
}
