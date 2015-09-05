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
        private int PieninNro = 1;
        private int NumeroLkm = 7;
        /*  Tyyppi on
            0 = Lotto
            1 = Viikinlotto
            2 = Eurojackpot
        */
        private int Tyyppi = 0;
        private int Riveja = 0;
        private Random rnd1 = new Random();


        public List<string> drawLottery(int game, int rws)
        {
            setGameType(game);
            if (rws > -1) //check validity
            {
                Riveja = rws;
            }
            List<string> lista = new List<string>();
            for (int k = 0; k < Riveja; k++)
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
                if (Tyyppi == 2 && i >= 4)//Eurojackpot extra numbers
                {
                    newNum = randomNumber(PieninNro, 8);
                }
                else
                {
                    newNum = randomNumber(PieninNro, SuurinNro);
                }
                if (newNum < 10)
                {
                    str1 += " ";
                }
                str1 += newNum.ToString();

                //separators
                if (Tyyppi == 2 && i == 4)
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
        public int setGameType(int type)
        {
            if (type == 1)
            {
                Tyyppi = type;
                SuurinNro = 48;
                NumeroLkm = 6;
            }
            else if (type == 2)
            {
                Tyyppi = type;
                SuurinNro = 50;
                NumeroLkm = 7;
            }
            else if (type == 0)
            {
                Tyyppi = type;
                SuurinNro = 39;
                NumeroLkm = 7;
            }
            else
            {
                //There were error, use default values
                Tyyppi = 0;
                SuurinNro = 39;
                NumeroLkm = 7;
                return 1;
            }
            return 0;
        }


    }
}
