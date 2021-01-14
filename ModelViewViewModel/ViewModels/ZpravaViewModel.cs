using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
// Tohle je třeba nainstalovat přes NuGet, jinak Command dá moc práce
using GalaSoft.MvvmLight.Command;
using ModelViewViewModel.Models;

namespace ModelViewViewModel.ViewModels
{


    class ZpravaViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string zprava;
        public string Zprava
        {
            get { return zprava; }
            set 
            { 
                zprava = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Zprava"));
            }
        }

        public void ShowDialogZprava()
        {
            MessageBox.Show(Zprava);
        }

        public ZpravaViewModel()
        {
            Zprava = ZpravaModel.TextZpravy;
        }

        private static ICommand _sendCommand;

        // SendCommand je bindovaný z GUI
        public ICommand SendCommand
        {
            get
            {
                if (_sendCommand == null)
                {
                    // RelayCommand je definovaný v MVVMLight
                    _sendCommand = new RelayCommand(
                        () => { 
                            // Tady je práce, která se má odmakat, když se spustí command
                            ShowDialogZprava();
                            ZpravaModel.TextZpravy = Zprava;
                        });
                }
                return _sendCommand;
            }
        }

    }
}
