using CryptoChecker.Models;
using CryptoChecker.WebRequests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CryptoChecker.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {

        private string filterText;
        private CollectionViewSource currenciesCollection;
        //private bool top10Currencies = true;
        private List<Currency> currencies { get; set; }
        public ApplicationViewModel()
        {
            currenciesCollection = new CollectionViewSource();
        }


        public async Task FillCurrencies()
        {
            currencies = await CurencyRequests.GetCurrencies();
            currenciesCollection.Source = currencies;
            currenciesCollection.Filter += CurrenciesCollectionFilter;
        }
        public ICollectionView SourceCollection
        {
            get
            {
                return this.currenciesCollection.View;
            }
        }

        public string FilterText
        {
            get
            {
                return filterText;
            }
            set
            {
                filterText = value;
                this.currenciesCollection.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }

      

        private void CurrenciesCollectionFilter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
            {
                e.Accepted = true;
                return;
            }

            var cur = e.Item as Currency;
            if (cur.Symbol.Contains(FilterText, StringComparison.OrdinalIgnoreCase))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}