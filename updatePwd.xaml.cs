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
    /// updatePwd.xaml etkileşim mantığı
    /// </summary>
    public partial class updatePwd : Window
    {
        public string MyProperty { get; set; }
        public string my_password { get; set; }
        public updatePwd()
        {

            InitializeComponent();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string oldPassword = oldPwd.Password;
            string newPassword = newPwd.Password;

            if (newPassword.Length == 4)
            {
                OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=data.accdb");
                OleDbCommand cmd;

                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                if (my_password == oldPassword)
                {
                    cmd.CommandText = "update kullanici set k_sifre='" + newPassword + "' where k_ad='" + MyProperty + "'";

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    con.Close();


                    MessageBox.Show("Şifre başarıyla güncellendi");
                }
                else
                {
                    MessageBox.Show("Eski şifreniz yanlış, lütfen tekrar deneyiniz");
                }
            }
            else
            {
                MessageBox.Show("Yeni şifreniz 4 haneli olmalıdır");
                oldPwd.Clear();
                newPwd.Clear();
            }

           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                       
            this.Close();
                
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
