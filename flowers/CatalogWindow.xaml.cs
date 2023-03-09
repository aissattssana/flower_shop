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
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        FlowerShopdbContext db = new FlowerShopdbContext();
        public CatalogWindow()
        {
            InitializeComponent();
            CatalogView.ItemsSource = db.Catalogs.ToList();
        }

        private void buqet_Click(object sender, RoutedEventArgs e)
        {
            CatalogView.ItemsSource = db.Catalogs.Where(x => x.Type == "buqet").ToList();

        }

        private void flowers_Click(object sender, RoutedEventArgs e)
        {
            CatalogView.ItemsSource = db.Catalogs.Where(x => x.Type == "flower").ToList();
        }

        private void accessories_Click(object sender, RoutedEventArgs e)
        {
            CatalogView.ItemsSource = db.Catalogs.Where(x => x.Type == "accessories").ToList();
        }

        private void prof_Click(object sender, RoutedEventArgs e)
        {

            var window = new LoginWindow();
            window.Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {

            var window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
