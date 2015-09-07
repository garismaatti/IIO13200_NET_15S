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



        //Start function
        public List<string> drawLottery(string game, int rws)
        {
            setGameType(game); //set game type
            if (rws < 0) //check validity
            {
                rws = 0;
            }
            List<List<int>> lista = new List<List<int>>(); //Numeric list of draw rows
            List<string> strRowList = new List<string>();    //String list of rows

            for (int k = 0; k < rws; k++) //fill all rows
            {
                //Draw numbers
                lista.Add(drawRow());
            }

            string tmpRowStr = "";   //Hold 1 row temporally
            List<int> tmpIntList = new List<int>(); //Hold 1 numeric row temporally

            for (int h = 0; h < lista.Count; h++)//for each (row)
            {
                tmpRowStr = ""; //clear tmpRowString
                tmpIntList = lista.ElementAt(h); //Set temporally numeric row

                for (int i = 0; i < tmpIntList.Count; i++) //For each number in row
                {
                    int newNum = tmpIntList.ElementAt(i); //get number
                    if (newNum < 10) //add spacing
                    {
                        tmpRowStr += " ";
                    }
                    tmpRowStr += newNum.ToString(); //add number

                    //separators
                    if (Tyyppi == "Eurojackpot" && i == 4)
                    {
                        tmpRowStr += " --";
                    }
                    else
                    {
                        if (i != NumeroLkm - 1)
                        {
                            tmpRowStr += ", ";
                        }
                    }
                                        
                }
                strRowList.Add(tmpRowStr); //add str to strRowList
            }

            return strRowList; //return complete list of strings
        }


        private List<int> drawRow()
        {
            List<int> rivi = new List<int>();
            for (int i = 0; i < NumeroLkm; i++)
            {
                int newNum = 0;
                if (Tyyppi == "Eurojackpot" && i > 4)//Eurojackpot extra numbers
                {
                    rivi.Sort(); //sort brevious numbers

                    newNum = randomNumber(1, 10);//first extra number
                    int secondNum = newNum;

                    while (newNum == secondNum) //prevent same number
                    {
                        secondNum = randomNumber(1, 10);//second extra number
                    }

                    if (newNum > secondNum) //put in numeric order
                    {
                        rivi.Add(secondNum);
                        rivi.Add(newNum);
                    }
                    else
                    {
                        rivi.Add(newNum);
                        rivi.Add(secondNum);
                    }
                    i = NumeroLkm; //end for loop

                }
                else
                {
                    newNum = randomNumber(1, SuurinNro);
                    if (rivi.Contains(newNum))
                    {
                        //already exist
                        i--;
                    }
                    else
                    {
                        rivi.Add(newNum);
                    }
                }
            }
            if (Tyyppi != "Eurojackpot"){ //dont sort in here if Euroojackpot
                rivi.Sort();
            }
            
            return rivi;
        }




        //Function to generate random number
        private int randomNumber(int min, int max)
        {
            return rnd1.Next(min,max+1);
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
