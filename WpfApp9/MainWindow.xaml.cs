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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp9
{       
 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Clan> ClanoviTeretane = new ObservableCollection<Clan>();

        public MainWindow()
        {

            InitializeComponent();
            DateTime defaultvreme = new DateTime(0001, 01, 01);

            dgClanarine.ItemsSource = ClanoviTeretane.Where(Clan=>Clan.pocetakClanarine != defaultvreme).ToList();
            dgClanovi.ItemsSource = ClanoviTeretane;


            ClanoviTeretane.Add(new Clan("Muhammed", "Besirovic"));
            ClanoviTeretane.Add(new Clan("Neko", "Nekic"));
            ClanoviTeretane.Add(new Clan("Pera", "Peric"));

            proveriPriPaljenju();
        }
        public void proveriPriPaljenju()//Proverava da li je nekome istekla clanarina i brise ih iz liste 
        {
            foreach(Clan a in dgClanarine.ItemsSource)
            {
                DateTime sada = DateTime.Now;
                DateTime defaultvreme = new DateTime(0001, 01, 01);
                if (a.pocetakClanarine < sada)
                {
                    a.pocetakClanarine= new DateTime(0001, 01, 01);
                    dgClanarine.ItemsSource = ClanoviTeretane.Where(Clan => Clan.pocetakClanarine != defaultvreme).ToList();//REFRESH
                }
            }
        }
        private void Dodaj_clanarinu(object sender, RoutedEventArgs e)
        {
            DateTime trenutnoVreme = DateTime.Now;
            Clan a = dgClanovi.SelectedItem as Clan;
            a.pocetakClanarine = trenutnoVreme.AddDays(30);
            DateTime defaultvreme = new DateTime(0001, 01, 01);
            dgClanarine.ItemsSource = ClanoviTeretane.Where(Clan => Clan.pocetakClanarine != defaultvreme).ToList();//REFRESH
        }

        private void Produzi_30(object sender, RoutedEventArgs e)
        {
            Clan x = dgClanarine.SelectedItem as Clan;
            DateTime trenutno = x.pocetakClanarine;
            trenutno = trenutno.AddDays(30);
            x.pocetakClanarine= trenutno;
            DateTime defaultvreme = new DateTime(0001, 01, 01);
            dgClanarine.ItemsSource = ClanoviTeretane.Where(Clan => Clan.pocetakClanarine != defaultvreme).ToList();//REFRESH
        }

        private void Prekini_clanarinu(object sender, RoutedEventArgs e)
        {
            DateTime defaultvreme = new DateTime(0001, 01, 01);
            Clan x = dgClanarine.SelectedItem as Clan;
            x.pocetakClanarine = defaultvreme;
            
            dgClanarine.ItemsSource = ClanoviTeretane.Where(Clan => Clan.pocetakClanarine != defaultvreme).ToList();//REFRESH
        }

        private void unosClana(object sender, RoutedEventArgs e)
        {
            Unos a = new Unos();
            a.Owner = this;

            if(a.ShowDialog() == true)
            {
                ClanoviTeretane.Add(a.DataContext as Clan);
            }
        }

        private void ukloniClana(object sender, RoutedEventArgs e)
        {
            ClanoviTeretane.Remove(dgClanovi.SelectedItem as Clan);
            DateTime defaultvreme = new DateTime(0001, 01, 01);
            dgClanarine.ItemsSource = ClanoviTeretane.Where(Clan => Clan.pocetakClanarine != defaultvreme).ToList();//REFRESH
        }
    }
}
