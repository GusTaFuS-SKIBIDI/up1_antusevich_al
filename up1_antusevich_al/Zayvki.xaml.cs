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

namespace up1_antusevich_al
{
    /// <summary>
    /// Логика взаимодействия для Zayvki.xaml
    /// </summary>
    public partial class Zayvki : Page
    {
        public Zayvki()
        {
            InitializeComponent();
            DataGridUser.ItemsSource = up1_akshakovaEntities.GetContext().Заявки.ToList();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZayvkiEdit(null));
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            var ДолжностьForRemoving = DataGridUser.SelectedItems.Cast<Заявки>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {ДолжностьForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    up1_akshakovaEntities.GetContext().Заявки.RemoveRange(ДолжностьForRemoving);
                    up1_akshakovaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    DataGridUser.ItemsSource = up1_akshakovaEntities.GetContext().Заявки.ToList();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }
        private void BntEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ZayvkiEdit((sender as Button).DataContext as Заявки));
        }
        private void ButtonBeck_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();


        }
    }
}
