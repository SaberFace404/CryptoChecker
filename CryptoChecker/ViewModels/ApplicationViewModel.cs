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

namespace CryptoChecker.ViewModels
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Currency> Currencies { get; set; }

        public ApplicationViewModel()
        {
            var requestResults = CurencyRequests.GetCurrencies();
            Currencies = new ObservableCollection<Currency>(requestResults);
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