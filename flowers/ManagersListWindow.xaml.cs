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
using System.Windows.Shapes;

namespace flowers
{
    /// <summary>
    /// Логика взаимодействия для ManagersListWindow.xaml
    /// </summary>
    public partial class ManagersListWindow : Window
    {
        FlowerShopdbContext db = new FlowerShopdbContext();
        private Manager currentManager = new Manager();
        private User currentUser = new User();
        public ManagersListWindow()
        {
            InitializeComponent();
            InitDataGrid();
        }
        private void create_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateUserWindow("manager");
            window.Show();
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            db.Managers.Remove(currentManager);
            db.Users.Remove(currentUser);
            db.SaveChanges();
            MessageBox.Show("Менеджер удален");
            InitDataGrid();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            var window = new AdminWindow();
            window.Show();
            this.Close();
        }

        private void DataGridManagers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                currentUser = DataGridManagers.SelectedItem as User;
                currentManager = db.Managers.Where(x => x.UserId == currentUser.IdUser).First();
            }
            catch
            {
                return;
            }
        }

        private void InitDataGrid()
        {
            DataGridManagers.ItemsSource = db.Users.Where(x => x.Role != "client").ToList();
        }
    }
}
