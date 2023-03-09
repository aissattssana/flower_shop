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

namespace flowers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            var log = new LoginWindow();
            log.Show();
            this.Close();
        }

        private void catalog_Click(object sender, RoutedEventArgs e)
        {

        }

        private void flowers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var log = new CatalogWindow();
            log.Show();
            this.Close();
        }

        private void accessories_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var log = new CatalogWindow();
            log.Show();
            this.Close();
        }

        private void bouget_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var log = new CatalogWindow();
            log.Show();
            this.Close();
        }
    }
}
