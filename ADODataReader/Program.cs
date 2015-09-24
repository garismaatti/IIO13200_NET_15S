using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADODataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData_DataTable();
        }

        static void GetData_DataTable()
        {
            //UI kerros esitys
            try
            {
                //haetaan data
                DataTable dt = GetDataReal();
                //DataTable dt = GetDataSimple();
                string rivi = "";
                //loopitetaan datatable rivit
                foreach (DataRow dr in dt.Rows)
                {
                    rivi = "";
                    foreach(DataColumn dc in dt.Columns)
                    {
                        rivi += dr[dc].ToString() + "\t";
                    }
                    Console.WriteLine(rivi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        static DataTable GetDataSimple()
        {
            //taulu
            DataTable dt = new DataTable();
            //sartakkeet
            dt.Columns.Add("Firstname", typeof(string));
            dt.Columns.Add("Lastname", typeof(string));

            dt.Rows.Add("Kalle", "Isotalo");
            dt.Rows.Add("Ville", "Kallio");

            return dt;
        }

        static DataTable GetDataReal()
        {
            //DBkerros haetaan DemoxOy -titokannasta taulun läsnäolot tietueet
            //string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
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
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");
                        return ds.Tables["lasnaolot"];
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
