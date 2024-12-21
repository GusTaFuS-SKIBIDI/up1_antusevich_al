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
    /// Логика взаимодействия для ZayvkiEdit.xaml
    /// </summary>
    public partial class ZayvkiEdit : Page
    {
        private Заявки _currentДолжность = new Заявки();
        public ZayvkiEdit(Заявки selectedДолжность)
        {
            InitializeComponent();
            if (selectedДолжность != null)
            {
                _currentДолжность = selectedДолжность;
            }
            DataContext = _currentДолжность;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Zayvki());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();



            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.КлиентID)))
            {
                errors.AppendLine("Введите наименование КлиентID");

            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.ОборудованиеID)))
            {
                errors.AppendLine("Введите ОборудованиеID");

            }


            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.ДатаСоздания)))
            {
                errors.AppendLine("Введите ДатаСоздания");

            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Описание)))
            {
                errors.AppendLine("Введите Описание");

            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Статус)))
            {
                errors.AppendLine("Введите Статус");

            }
            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.РаботникID)))
            {
                errors.AppendLine("Введите РаботникID");

            }



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentДолжность.ЗаявкаID == 0)
            {
                up1_akshakovaEntities.GetContext().Заявки.Add(_currentДолжность);
            }

            try
            {
                up1_akshakovaEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
