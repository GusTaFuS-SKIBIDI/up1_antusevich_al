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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace up1_antusevich_al
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RABOTNIKI_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Works();
        }

        private void OBORUDOVANIE_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Oborud();
        }

        private void ZAEVKI_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Klient();
        }

        private void KLIENTI_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Zayvki();
        }
    }
}
