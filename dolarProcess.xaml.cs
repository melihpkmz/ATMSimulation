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

namespace ATMSimulation
{
    /// <summary>
    /// dolarProcess.xaml etkileşim mantığı
    /// </summary>
    public partial class dolarProcess : Window
    {
        public string m_cardNumber;
        public dolarProcess()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dolarBuy dBuy = new dolarBuy();
            dBuy.Show();
            dBuy.m_cardNumber = m_cardNumber;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dolarSell dSell = new dolarSell();
            dSell.Show();
            dSell.my_cardNumber = m_cardNumber;
            this.Close();
        }
    }
}
