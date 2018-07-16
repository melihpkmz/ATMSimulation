using System;
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
using System.Windows.Shapes;
using System.Data.OleDb;

namespace ATMSimulation
{
    /// <summary>
    /// exchangeProcess.xaml etkileşim mantığı
    /// </summary>
    public partial class exchangeProcess : Window
    {
        public string myCardNumber;
        private double sMoney;

        public exchangeProcess()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            portal newPage = new portal();

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb");
            OleDbCommand cmd;
            OleDbDataReader dr;

            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select k_para from kullanici where k_ad ='" + myCardNumber + "'";
            dr = cmd.ExecuteReader();
           
            while (dr.Read())
            {
                sMoney = Convert.ToDouble(dr["k_para"]);
            }


            dr.Close();
            con.Close();
            this.Close();
            newPage.textBox1.Text = sMoney.ToString();
            newPage.m_cardNumber = myCardNumber;
            newPage.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            euroProcess eProcess = new euroProcess();
            eProcess.Show();
            eProcess.m_cardNumber = myCardNumber;
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dolarProcess eProcess = new dolarProcess();
            eProcess.Show();
            eProcess.m_cardNumber = myCardNumber;
            this.Close();
        }
    }
}
