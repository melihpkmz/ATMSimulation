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
using System.Xml;
using System.Data;
using System.Data.OleDb;

namespace ATMSimulation
{
    /// <summary>
    /// euroBuy.xaml etkileşim mantığı
    /// </summary>
    public partial class euroBuy : Window
    {
        public string m_cardNumber;
        private double kMoney;
        public euroBuy()
        {
            InitializeComponent();
            DovizKur();
            textBox2.Text = Euro.ToString();
            
        }

        private double Euro = 0.0;
        private double upMoney = 0.0;
        private double eMoney = 0.0;
        private double sMoney;

        private void DovizKur()
        {
            string today = "http://www.tcmb.gov.tr/kurlar/today.xml";

            var xmlDoc = new XmlDocument();
            xmlDoc.Load(today);

            Euro = Convert.ToDouble(xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml.Replace('.',','));
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb");
            OleDbCommand cmd;
            OleDbDataReader dr;

            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select k_para from kullanici where k_ad ='" + m_cardNumber + "'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                kMoney = Convert.ToDouble(dr["k_para"]);
            }

            if (Convert.ToDouble(textBox1.Text) <= kMoney)
            {

                kMoney = kMoney - Convert.ToDouble(textBox1.Text);
                dr.Close();
                cmd.CommandText = "update kullanici set k_para='" + kMoney.ToString() + "' where k_ad='" + m_cardNumber + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                eMoney = Convert.ToDouble(textBox1.Text) / Euro;

                cmd.Connection = con;
                cmd.CommandText = "select k_paraEuro from kullanici where k_ad ='" + m_cardNumber + "'";
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    eMoney = Convert.ToDouble(dr["k_paraEuro"]) + eMoney;
                }
                dr.Close();

                cmd.Connection = con;
                cmd.CommandText = "update kullanici set k_paraEuro='" + eMoney.ToString() + "' where k_ad='" + m_cardNumber + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                dr.Close();
                con.Close();

                MessageBox.Show("Döviz alım-satım işlemi başarıyla gerçekleştirildi");
            }

            else
            {
                MessageBox.Show("Hesabınızdaki paradan daha fazla tutar girdiniz, lütfen kontrol ediniz.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            portal newPage = new portal();

            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb");
            OleDbCommand cmd;
            OleDbDataReader dr;

            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select k_para from kullanici where k_ad ='" + m_cardNumber + "'";
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                sMoney = Convert.ToDouble(dr["k_para"]);
            }


            dr.Close();
            con.Close();
            this.Close();
            newPage.textBox1.Text = sMoney.ToString();
            newPage.m_cardNumber = m_cardNumber;
            newPage.Show();

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.NumPad0 || e.Key == Key.NumPad1 || e.Key == Key.NumPad2 || e.Key == Key.NumPad3 || e.Key == Key.NumPad4 || e.Key == Key.NumPad5 || e.Key == Key.NumPad6 || e.Key == Key.NumPad7 || e.Key == Key.NumPad8 || e.Key == Key.NumPad9 || e.Key == Key.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
