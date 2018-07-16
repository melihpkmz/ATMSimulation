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
    /// euroProcess.xaml etkileşim mantığı
    /// </summary>
    public partial class euroProcess : Window
    {
        public string m_cardNumber;
        public euroProcess()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            euroBuy eBuy = new euroBuy();
            eBuy.Show();
            eBuy.m_cardNumber = m_cardNumber;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            euroSell eSell = new euroSell();
            eSell.Show();
            eSell.my_cardNumber = m_cardNumber;
            this.Close();
        }
    }
}
