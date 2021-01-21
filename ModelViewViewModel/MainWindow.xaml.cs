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
using ModelViewViewModel.Views;
using ModelViewViewModel.Models;

namespace ModelViewViewModel
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

        // Ve WPF se nepoužívá Open, ale přiřazuje se např. obsah do Content
        // Dokud se tu neřeší obchodní logika (práce s daty, pravidly, atd.), je to OK
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 p = new Page1();
            this.Content = p;
        }

        // Prověření, že ve finále se změnila data v modelu...
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // ukaž poslední zprávu
            StringBuilder sb = new StringBuilder();

            foreach(var z in ZpravaModel.ZpravaDatabase.VsechnyZpravy)
            {
                sb.Append(z + "\n");
            }
            MessageBox.Show(sb.ToString());
        }
    }
}
