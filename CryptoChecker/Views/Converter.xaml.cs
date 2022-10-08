using CryptoChecker.Models;
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
    /// Логика взаимодействия для Converter.xaml
    /// </summary>
    public partial class Converter : Page
    {
        List<Currency> _currencies;
        public Converter(List<Currency> currencies)
        {
            InitializeComponent();
            _currencies = currencies;
            var symbols = _currencies.Select(c => c.Symbol).ToList();
            sourceCurrency.ItemsSource = symbols;
            sourceCurrency.SelectedIndex = 0;
            targetCurrency.ItemsSource = symbols;
            targetCurrency.SelectedIndex = 1;
        }

        private void sourceValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            var leftCurrency = _currencies.First(el => el.Symbol == sourceCurrency.Text);
            var rightCurrency = _currencies.First(el => el.Symbol == targetCurrency.Text);
            if (Double.TryParse(sourceValue.Text, out var leftNumber))
            {
                targetValue.Text = (leftNumber * leftCurrency.PriceUsd / rightCurrency.PriceUsd).ToString();
            }
            else
            {
                targetValue.Text = "NaN";
            }
        }
    }
}
