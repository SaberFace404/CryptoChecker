﻿using CryptoChecker.Models;
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

        private void Calculate()
        {
            var leftCurrency = _currencies.FirstOrDefault(el => el.Symbol == sourceCurrency.Text);
            var rightCurrency = _currencies.FirstOrDefault(el => el.Symbol == targetCurrency.Text);
            if (Double.TryParse(sourceValue.Text, out var leftNumber))
            {
                targetValue.Text = (leftNumber * leftCurrency?.PriceUsd / rightCurrency?.PriceUsd).ToString();
            }
            else if(sourceValue.Text == "")
            {
                targetValue.Text = "";
            }
            else
            {
                targetValue.Text = "NaN";
            }
        }
        private void sourceValueTextChanged(object sender, TextChangedEventArgs e)
        {
            Calculate();
        }

        private void sourceCurrencySelected(object sender, RoutedEventArgs e)
        {
            Calculate();
        }

        private void targetCurrencySelected(object sender, RoutedEventArgs e)
        {
            Calculate();
        }
    }
}
