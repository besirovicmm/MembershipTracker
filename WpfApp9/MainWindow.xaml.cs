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
        Dictionary<Clan, DateTime> vazececlanarine = new Dictionary<Clan, DateTime>();
        public MainWindow()
        {

            InitializeComponent();
            //ObservableCollection<Clan> ClanoviTeretane = new ObservableCollection<Clan>();
           // Dictionary<Clan, DateTime> vazececlanarine = new Dictionary<Clan, DateTime>();

           
            ClanoviTeretane.Add(new Clan("Muhammed", "Besirovic"));



            DateTime vreme = DateTime.Now;
            dgClanarine.ItemsSource = vazececlanarine;
            dgClanovi.ItemsSource = ClanoviTeretane;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime danas = DateTime.Now;
            TimeSpan mesec = new TimeSpan(30, 0, 0, 0, 0);
            if (!vazececlanarine.ContainsKey(dgClanovi.SelectedItem as Clan))
            {

                vazececlanarine.Add(dgClanovi.SelectedItem as Clan, danas.Add(mesec));
            }
            else
            {
                DateTime produzi;
                vazececlanarine.TryGetValue(dgClanovi.SelectedItem as Clan, out produzi);
                vazececlanarine.Remove(dgClanovi.SelectedItem as Clan);
                produzi = produzi.Add(mesec);
                MessageBox.Show($"{produzi}");
                vazececlanarine.Add(dgClanovi.SelectedItem as Clan, produzi);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Unos noviclan = new Unos();
            noviclan.ShowDialog();
            noviclan.Owner = this;
            ClanoviTeretane.Add(noviclan.DataContext as Clan);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (dgClanovi.SelectedItem != null )
            { 
                ClanoviTeretane.Remove(dgClanovi.SelectedItem as Clan);
            } else
                MessageBox.Show("Odaberite clana");
        }
    }
}
