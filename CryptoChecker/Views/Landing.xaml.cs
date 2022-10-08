using CryptoChecker.Models;
using CryptoChecker.ViewModels;
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


namespace CryptoChecker.Views
{
    /// <summary>
    /// Логика взаимодействия для Landing.xaml
    /// </summary>
    public partial class Landing : Page
    {
        public Landing()
        {
            InitializeComponent();
            DataContext = new ApplicationViewModel();
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var page = new CurrencyDetails(currenciesView.SelectedItem as Currency ?? new Currency());
                this.NavigationService.Navigate(page);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var page = new Converter(currenciesView.ItemsSource.Cast<Currency>().ToList());
            this.NavigationService.Navigate(page);
        }
    }
}
