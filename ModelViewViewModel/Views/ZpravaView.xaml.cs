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

using ModelViewViewModel.ViewModels;

namespace ModelViewViewModel.Views
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            
            // V tomto rozsahu se budou hledat bindovaná data
            DataContext = new ZpravaViewModel();

            // "Code behind" - kód, který je součástí definice GUI společně s XAML
            // zpracovává pouze vizualizaci Page, ale celá logika zpracování
            // a všechny přístupy k datům má na starosti ZpravaViewModel
        }
    }
}
