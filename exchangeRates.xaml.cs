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

namespace ATMSimulation
{
    /// <summary>
    /// exchangeRates.xaml etkileşim mantığı
    /// </summary>
    public partial class exchangeRates : Window
    {
        public exchangeRates()
        {
            InitializeComponent();
            DovizKur();
            textBox1.Text = Dolar.ToString();
            textBox2.Text = Euro.ToString();
            textBox3.Text = GBP.ToString();
            textBox4.Text = SEK.ToString();
        }

        private double Euro = 0.0;
        private double Dolar = 0.0;
        private double GBP = 0.0;
        private double SEK = 0.0;
        private DataSet dsDovizKur;

        private void DovizKur()
        {
            dsDovizKur = new DataSet();
            dsDovizKur.ReadXml(@"http://www.tcmb.gov.tr/kurlar/today.xml");
            DataRow dr = dsDovizKur.Tables[1].Rows[0];
            Dolar = Convert.ToDouble(dr[4].ToString().Replace('.', ','));
            dr = dsDovizKur.Tables[1].Rows[3];
            Euro = Convert.ToDouble(dr[4].ToString().Replace('.', ','));
            dr = dsDovizKur.Tables[1].Rows[4];
            GBP = Convert.ToDouble(dr[4].ToString().Replace('.', ','));
            dr = dsDovizKur.Tables[1].Rows[6];
            SEK = Convert.ToDouble(dr[4].ToString().Replace('.', ','));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
