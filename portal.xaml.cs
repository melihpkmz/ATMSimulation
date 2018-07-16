using System.Data.OleDb;
using System.Windows;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace ATMSimulation
{
    /// <summary>
    /// portal.xaml etkileşim mantığı
    /// </summary>
    public partial class portal : Window
    {
        public string m_cardNumber;
        public string m_password;

        public portal()
        {
            InitializeComponent();
            textBox1.Background = Brushes.WhiteSmoke;
            button1.Background = Brushes.SeaShell;
            button2.Background = Brushes.SeaShell;
            button3.Background = Brushes.SeaShell;
            button4.Background = Brushes.SeaShell;
            button5.Background = Brushes.SeaShell;
            button6.Background = Brushes.SeaShell;
            button7.Background = Brushes.Red;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            updatePwd pwd = new updatePwd();
            pwd.MyProperty = m_cardNumber;
            pwd.my_password = m_password;
            pwd.ShowDialog();
            pwd = null;
            Show();            
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Hide();
            transferMoney tMoney = new transferMoney();
            tMoney.MyProperty = m_cardNumber;
            tMoney.Show();
            tMoney = null;
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Hide();
            cashDeposit iMoney = new cashDeposit();
            iMoney.MyProperty = m_cardNumber;
            iMoney.Show();
            iMoney = null;
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Hide();
            drawCash dMoney = new drawCash();
            dMoney.MyProperty = m_cardNumber;
            dMoney.Show();
            dMoney = null;
            this.Close();
        }
        public void doldur()
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.Oledb.12.0;Data Source=data.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select k_para from kullanici where k_ad = '" + m_cardNumber + "'", con);
            OleDbDataReader dr = null;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                textBox1.Text = (Convert.ToString(dr["k_para"]));
            }

            dr.Close();
            con.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Hide();
            exchangeRates eRates = new exchangeRates();
            eRates.ShowDialog();
            eRates = null;
            Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            exchangeProcess ePro = new exchangeProcess();
            ePro.myCardNumber = m_cardNumber;
            ePro.Show();
            ePro = null;
            this.Close();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MainWindow logOut = new MainWindow();
            logOut.Show();
            this.Close();
        }
    }
}
