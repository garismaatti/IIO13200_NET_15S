using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace Teht5_Lasnaolot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData_DataTable();
        }

        private void GetData_DataTable()
        {
            //UI kerros esitys
            try
            {
                //haetaan data
                DataTable dt = GetDataReal();
                //DataTable dt = GetDataSimple();

                //DataTable dt = new DataTable();
                DataView dv = new DataView();

                dv = dt.DefaultView;
                dgData.ItemsSource = dv;
                
                //DataTable dt = GetDataSimple();
                /* string rivi = "";
                 //loopitetaan datatable rivit
                 foreach (DataRow dr in dt.Rows)
                 {
                     rivi = "";
                     foreach (DataColumn dc in dt.Columns)
                     {
                         rivi += dr[dc].ToString() + "\t";
                     }
                     Console.WriteLine(rivi);
                 }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private DataTable GetDataSimple()
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

        private DataTable GetDataReal()
        {
            //DBkerros haetaan DemoxOy -titokannasta taulun läsnäolot tietueet
            //string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
            try
            {
                string sql = "";
                //sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                //sql = "SELECT asioid, lastname, firstname, date  FROM lasnaolot WHERE asioid='K2362'";
                if (txt_asioid.Text.Length > 0)
                {
                    sql = "SELECT asioid, lastname, firstname, date  FROM lasnaolot WHERE asioid='"+txt_asioid.Text.ToString()+"'";
                }
                else
                {
                    sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                }
                
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

        private void btn_DataTable_Click(object sender, RoutedEventArgs e)
        {
            GetData_DataTable();
        }

        private void btn_DataView_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_DataSet_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
