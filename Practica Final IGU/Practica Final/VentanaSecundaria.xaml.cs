using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Practica_Final
{
    /// <summary>
    /// Lógica de interacción para VentanaSecundaria.xaml
    /// </summary>
    public class DiaSeleccionadoEventArgs : EventArgs
    {
        public DiaCalorico d { get; set; }
        public DiaSeleccionadoEventArgs(DiaCalorico dia)
        {
            d = dia;
        }
    }
    public partial class VentanaSecundaria : Window
    {
        
        public DiaCalorico selectedDia { get { return (DiaCalorico)listaFechas.SelectedItem; } 
            set {
                if (value != null)
                    listaFechas.SelectedItem = value;
                else
                    listaFechas.SelectedItem = null;
            } }

        public event EventHandler<DiaSeleccionadoEventArgs> CambioElDiaSeleccionado;
        public VentanaSecundaria(ObservableCollection<DiaCalorico> l)
        {
            InitializeComponent();
            
            listaFechas.ItemsSource = l;
            
        }

        void OnCambioElDiaSeleccionado(DiaCalorico d)
        {
            if (CambioElDiaSeleccionado != null)
                CambioElDiaSeleccionado(this, new DiaSeleccionadoEventArgs(d));
        }

        private void listaFechas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DiaCalorico c = (DiaCalorico)listaFechas.SelectedItem;
            if (c != null && c.cal != null)
                listaCalorias.ItemsSource = c.cal;
            else
                listaCalorias.ItemsSource = null;

            OnCambioElDiaSeleccionado(c);

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility=Visibility.Hidden;
        }
    }
}
