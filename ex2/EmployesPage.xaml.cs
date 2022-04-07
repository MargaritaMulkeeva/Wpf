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
    /// Логика взаимодействия для EmployesPage.xaml
    /// </summary>
    public partial class EmployesPage : Page
    {
        public EmployesPage()
        {
            InitializeComponent();

            dtGrid.ItemsSource = DB_ExamEntities.GetContext().Employees.ToList();

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CrudEmp((sender as Button).DataContext as Employees));
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CrudEmp(null));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = dtGrid.SelectedItems.Cast<Employees>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    DB_ExamEntities.GetContext().Employees.RemoveRange(hotelsForRemoving);
                    DB_ExamEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    dtGrid.ItemsSource = DB_ExamEntities.GetContext().Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DB_ExamEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(items => items.Reload());
                dtGrid.ItemsSource = DB_ExamEntities.GetContext().Employees.ToList();
            }
        }
    }
}
