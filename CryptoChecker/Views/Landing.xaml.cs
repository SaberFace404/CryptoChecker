using CryptoChecker.Models;
using CryptoChecker.Themes;
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
    
    public partial class Landing : Page
    {
        public Landing()
        {
            InitializeComponent();
        }

        public override async void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var vm = new ApplicationViewModel();
            await vm.FillCurrencies();
            DataContext = vm;
        }

        private void DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var page = new CurrencyDetails(currenciesView.SelectedItem as Currency ?? new Currency());
                this.NavigationService.Navigate(page);
            }
        }

        private void ConverterButtonClick(object sender, RoutedEventArgs e)
        {
            var page = new Converter(currenciesView.ItemsSource.Cast<Currency>().ToList());
            this.NavigationService.Navigate(page);
        }

        private void ThemeChandeClick (object sender, RoutedEventArgs e)
        {
            if (ThemeChangeButton.IsChecked == true)
                ThemesController.SetTheme(ThemesController.ThemesType.Dark);
            else 
                ThemesController.SetTheme(ThemesController.ThemesType.Light);
        }


    }
}
