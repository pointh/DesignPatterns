using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Diagnostics;

// Tohle je třeba nainstalovat přes NuGet, jinak Command dá moc práce
// The MVVM Light Toolkit helps you to separate your View from your Model
// which creates applications that are cleaner and easier to maintain and extend. 
// It also creates testable applications and allows you to have a much thinner user interface
// layer (which is more difficult to test automatically).
// http://www.mvvmlight.net/
using GalaSoft.MvvmLight.Command;

using ModelViewViewModel.Models;

namespace ModelViewViewModel.ViewModels
{
/// <summary>
/// ViewModel pro aplikaci
/// </summary>

    public class ZpravaViewModel:INotifyPropertyChanged  
    {
        // pro navázání komunikace mezi GUI a ViewModel
        public event PropertyChangedEventHandler PropertyChanged;

        public ZpravaViewModel()
        {
            // Inicializace z modelu
            if (ZpravaModel.ZpravaDatabase.VsechnyZpravy.Count == 0)
            {
                Zprava = "";
            }
            else
            {
                Zprava = ZpravaModel.ZpravaDatabase.VsechnyZpravy[ZpravaModel.ZpravaDatabase.VsechnyZpravy.Count - 1];
            }
        }

        private string zprava;

        // Zprava je bindovaná z GUI
        public string Zprava
        {
            get { return zprava; }
            set 
            { 
                zprava = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Zprava)));
            }
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
                            Debug.WriteLine(Zprava);

                            // Uložení do modelu
                            ZpravaModel.ZpravaDatabase.VsechnyZpravy.Add(Zprava);
                        });
                }
                return _sendCommand;
            }
        }
    }
}
