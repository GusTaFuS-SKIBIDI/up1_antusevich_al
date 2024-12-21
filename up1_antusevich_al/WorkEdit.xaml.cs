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
    /// Логика взаимодействия для WorkEdit.xaml
    /// </summary>
    public partial class WorkEdit : Page
    {
        private Работники _currentДолжность = new Работники();
        public WorkEdit(Работники selectedДолжность)
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
            NavigationService.Navigate(new Works());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();



            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Фамилия)))
            {
                errors.AppendLine("Введите наименование должности");

            }

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Имя)))
            {
                errors.AppendLine("Введите количество квалификации");

            }


            if (string.IsNullOrWhiteSpace(Convert.ToString(_currentДолжность.Должность)))
            {
                errors.AppendLine("Введите зарплата");

            }



            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }


            if (_currentДолжность.РаботникID == 0)
            {
                up1_akshakovaEntities.GetContext().Работники.Add(_currentДолжность);
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
