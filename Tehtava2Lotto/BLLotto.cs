using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtävä2___lotto
{

    class Lotto
    {
        private int SuurinNro = 39;
        private int NumeroLkm = 7;
        /*  Tyyppi on
            0 = Suomi
            1 = VikingLotto
            2 = Eurojackpot
        */
        private string Tyyppi = "Suomi";
        private Random rnd1 = new Random();


        public List<string> drawLottery(string game, int rws)
        {
            setGameType(game);
            if (rws < 0) //check validity
            {
                rws = 0;
            }
            List<string> lista = new List<string>();
            for (int k = 0; k < rws; k++)
            {
                lista.Add(drawRow());
            }
            return lista;
        }

        private string drawRow()
        {
            string str1 = "";
            for (int i=0; i < NumeroLkm; i++)
            {
                int newNum = 0;
                if (Tyyppi == "Eurojackpot" && i >= 4)//Eurojackpot extra numbers
                {
                    newNum = randomNumber(1, 8);
                }
                else
                {
                    newNum = randomNumber(1, SuurinNro);
                }
                if (newNum < 10)
                {
                    str1 += " ";
                }
                str1 += newNum.ToString();

                //separators
                if (Tyyppi == "Eurojackpot" && i == 4)
                {
                    str1 += " -- ";
                }
                else
                {
                    if (i != NumeroLkm - 1)
                    {
                        str1 += ", ";
                    }
                }
                
                
            }
            return str1;
        }

        //Function to generate random number
        private int randomNumber(int min, int max)
        {
            return rnd1.Next(min,max);
        }

        //Set game type
        //Return 1 if there were error, otherwise return 0
        public int setGameType(string type)
        {
            if (type == "VikingLotto")
            {
                Tyyppi = type;
                SuurinNro = 48;
                NumeroLkm = 6;
            }
            else if (type == "Eurojackpot")
            {
                Tyyppi = type;
                SuurinNro = 50;
                NumeroLkm = 7;
            }
            else if (type == "Suomi")
            {
                Tyyppi = type;
                SuurinNro = 39;
                NumeroLkm = 7;
            }
            else
            {
                //There were error, use default values
                Tyyppi = "Suomi";
                SuurinNro = 39;
                NumeroLkm = 7;
                return 1;
            }
            return 0;
        }


    }
}
