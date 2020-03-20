using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp9
{
    /// <summary>
    /// Interaction logic for Unos.xaml
    /// </summary>
    public partial class Unos : Window
    {
        public Unos()
        {
            InitializeComponent();
            this.BindingGroup = new BindingGroup();
            this.DataContext = new Clan();
        }
        private void Otkazi(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Unoss(object sender, RoutedEventArgs e)
        {

            if (this.BindingGroup.CommitEdit())
            {
                this.DialogResult = true;
                this.Close();
            }

        }
    }
}
