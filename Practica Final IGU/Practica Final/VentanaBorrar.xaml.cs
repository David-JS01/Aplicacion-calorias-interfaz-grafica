using System;
using System.Collections.Generic;
using System.Collections;
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
    /// Lógica de interacción para VentanaBorrar.xaml
    /// </summary>
    public partial class VentanaBorrar : Window
    {
        public List<DiaCalorico> diasSeleccionados { get {
                List<DiaCalorico> d = new List<DiaCalorico>();
                foreach (DiaCalorico di in listaFechas.SelectedItems)
                {
                    d.Add(di);
                }
                return d;
            } }
        public VentanaBorrar(ObservableCollection<DiaCalorico> l)
        {
            InitializeComponent();
            
            listaFechas.ItemsSource = l;
        }

        private void botonBorrar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

        }

        private void botonCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
