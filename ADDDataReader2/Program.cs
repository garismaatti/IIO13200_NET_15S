using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADDDataReader2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sql = "";
                //sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                sql = "SELECT asioid, lastname, firstname, date  FROM lasnaolot WHERE asioid='K2362'";
                string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    //avaa yhteys
                    conn.Open();
                    //luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        //luodaan Reader
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            //käydään rdr läpi
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Console.WriteLine("{0}\t{1} {2}\t{3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3));
                                }
                                rdr.Close();
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //while (true) ;
        }
    }
}
