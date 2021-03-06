﻿using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace ViiniKellari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitFields();
        }

        // CHANGE TO SELECT XML FILE
        //private string fileUrl = "http://student.labranet.jamk.fi/~salesa/iio11300/mat/Viinit1.xml";
        //private string fileUrl = "D://K2362/IIO13200_NET_15S/Test4XML/Viinit1.xml";
        //private string fileUrl = ConfigurationSettings.AppSettings["ViinitTiedosto"];
        private string fileUrl = ConfigurationManager.AppSettings["ViinitTiedosto"] ?? "Not Found";


        private void InitFields()
        {
            cbFiltter.Items.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load(fileUrl);
            XmlNodeList nodeList = doc.SelectNodes("viinikellari/wine");

            cbFiltter.Items.Add("All"); //To list all
            foreach (XmlNode node in nodeList)
                if (!cbFiltter.Items.Contains(node.SelectSingleNode("maa").InnerText))
                {
                    cbFiltter.Items.Add(node.SelectSingleNode("maa").InnerText);
                }

        }


        private void UpdateFiltter()
        {

            try
            {
                string filu = @fileUrl;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataView dv = new DataView();
                ds.ReadXml(filu);
                dt = ds.Tables[0];

                dv = dt.DefaultView;
                if (cbFiltter.SelectedIndex != -1 && cbFiltter.SelectedIndex != 0)
                {
                    dt.DefaultView.RowFilter = "maa = '" + cbFiltter.SelectedItem.ToString() + "'";
                }

                dgWines.ItemsSource = dv;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        //Changed filtter
        private void cbFiltter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        //Button GetWine clicked
        private void btnGetWine_Click(object sender, RoutedEventArgs e)
        {
            UpdateFiltter();
        }
    }
}
