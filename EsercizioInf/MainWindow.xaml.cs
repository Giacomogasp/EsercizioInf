using System;
using System.Collections.Generic;
using System.IO;
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

namespace GestionePrestito
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmb_Residenza.Items.Add("Montepulciano");
            cmb_Residenza.Items.Add("Napoli");
            cmb_Residenza.Items.Add("Castiglione del Lag");
            cmb_Residenza.Items.Add("Venezia");
            cmb_Residenza.Items.Add("Baltimora");
            cmb_Residenza.Items.Add("Palm Beach");
            cmb_Residenza.Items.Add("Milano");
            cmb_Residenza.Items.Add("Forlì");
            cmb_Residenza.Items.Add("Perugia");
            cmb_Residenza.Items.Add("Bari");
            cmb_Residenza.Items.Add("Teramo"); 
            cmb_Residenza.Items.Add("Maiami");
            cmb_Residenza.Items.Add("Palermo");
            cmb_Residenza.Items.Add("Los Angeles");
            cmb_Residenza.Items.Add("Petrignano del lago");
            cmb_Residenza.Items.Add("Spoleto");
            cmb_Residenza.Items.Add("New York");
          
        }
        const string file = ("stat.csv");
        int importo;
        int perc;
        int rate;
        int importores;
        int imprata;
        string cognome;
        string nome;
        int calcoloperc;
        string citta;
        string rep1;
        string rep2;
        List<string> riepiloghi = new List<string>();
        string nat;
        
        private void txtcalcola_Click(object sender, RoutedEventArgs e)

        {
            
            importo = int.Parse(txtimporto.Text);
            rate = int.Parse(txtrate.Text);
            perc = int.Parse(txtpercentuale.Text);
            calcoloperc = (perc * importo) / 100;
            imprata = importores / rate;
            lblimprata.Content = imprata;
            importores = importo + calcoloperc;
            lblrestituire.Content = importores;

        }

        private void txtstampa_Click(object sender, RoutedEventArgs e)
        {
            nome = txtnome.Text;
            cognome = txtcognome.Text;

            if (rdbf.IsChecked == true)
            {
                nat = "nata";
            }
            else
                nat = "nato";

            calcoloperc = (perc * importo) / 100;
            riepiloghi.Add(rep2);
            imprata = importores / rate;
            rate = int.Parse(txtrate.Text);
            citta = cmb_Residenza.Text;
            perc = int.Parse(txtpercentuale.Text);
            importo = int.Parse(txtimporto.Text);         
            importores = importo + calcoloperc;
            rep2 = $"{cognome};{nome};{citta};{nat};{datapicker.SelectedDate};{importo};{perc};{rate};{imprata};{importores}";
            lblresult.Content = (rep1);        
            rep1 = ($"{cognome} {nome}, residente in {citta} {nat} il {datapicker.SelectedDate}; prestito di {importo} ad un tasso del {perc}% da rstituire in {rate} rate da {imprata}€ ciascuna, per un totale di {importores}€.");
        }

        private void txtnuovo_Click(object sender, RoutedEventArgs e)
        {
        
            StreamWriter w = new StreamWriter(file);
            w.WriteLine("cognome;nome;città;sesso;data;importo richiesto;percentuale interessi;numero rate;importo singola rata;importo da restituire");


            for (int i = 0; i < riepiloghi.Count; i++)
            {
                {
                    w.WriteLine(riepiloghi[i]);
                }

            }       
            w.Close();
            w.Flush();
        }
    }
}