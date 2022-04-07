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

namespace ex2
{
    /// <summary>
    /// Логика взаимодействия для CrudEmp.xaml
    /// </summary>
    public partial class CrudEmp : Page
    {
        private Employees _currentEmployes = new Employees();

        public CrudEmp(Employees emp)
        {
            InitializeComponent();
            if (emp != null)
                _currentEmployes = emp;
            DataContext = _currentEmployes;

            cmbPosition.ItemsSource = DB_ExamEntities.GetContext().Positions.ToList();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentEmployes.ID_Employee == 0)
                DB_ExamEntities.GetContext().Employees.Add(_currentEmployes);

            try
            {
                DB_ExamEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация успешно сохранена", "СОХРАНЕНИЕ", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ОШИБКА", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
