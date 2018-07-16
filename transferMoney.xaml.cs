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
    /// transferMoney.xaml etkileşim mantığı
    /// </summary>
    public partial class transferMoney : Window
    {
        public string MyProperty { get; set; }
        public double upMoney;
        private double sMoney;
        public double kMoney;
        public int i = 0;

        public transferMoney()
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
            cmd.CommandText = "select k_para from kullanici where k_ad ='" + MyProperty + "'";
            dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                sMoney = Convert.ToDouble(dr["k_para"]);
            }


            dr.Close();
            con.Close();
            newPage.textBox1.Text = sMoney.ToString();
            newPage.m_cardNumber = MyProperty;
            newPage.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb");
            OleDbCommand cmd;
            OleDbDataReader dr;

            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select k_para from kullanici where k_ad ='" + MyProperty + "'";
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                kMoney = Convert.ToDouble(dr["k_para"]);
            }
            


            if (Convert.ToDouble(textBox2.Text) <= kMoney)
            {

                kMoney = kMoney -Convert.ToDouble(textBox2.Text);
                dr.Close();
                cmd.CommandText = "update kullanici set k_para='" + kMoney.ToString() + "' where k_ad='" + MyProperty + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                kMoney = 0;

                cmd.Connection = con;
                cmd.CommandText = "select k_para from kullanici where k_hesapno ='" + textBox1.Text + "'";
                dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    kMoney = Convert.ToDouble(dr["k_para"]);
                }
                kMoney = kMoney +Convert.ToDouble(textBox2.Text);
                dr.Close();
                cmd.CommandText = "update kullanici set k_para='" + kMoney.ToString() + "' where k_hesapno='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();

                cmd.Dispose();
                con.Close();

                MessageBox.Show("Para başarıyla transfer edildi.");
            }
            else
            {
                MessageBox.Show("Hesabınızdaki paradan daha fazla tutar girdiniz ya da olmayan bir hesap numarası girdiniz, lütfen kontrol ediniz.");
 

            }





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

        private void keyDown2(object sender, KeyEventArgs e)
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
