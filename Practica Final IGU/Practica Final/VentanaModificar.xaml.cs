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
    /// Lógica de interacción para VentanaModificar.xaml
    /// </summary>
    public partial class VentanaModificar : Window
    {
        public DiaCalorico diaSelec { get { return (DiaCalorico)combo.SelectedItem; } }
        public int calDesayun
        {
            get
            {
                int result;
                bool x = int.TryParse(calDesayuno.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            }
        }
        public int calAperitiv
        {
            get
            {
                int result;
                bool x = int.TryParse(calAperitivo.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            }
        }
        public int calComid
        {
            get
            {
                int result;
                bool x = int.TryParse(calComida.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            }
        }
        public int calMeriend
        {
            get
            {
                int result;
                bool x = int.TryParse(calMerienda.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            }
        }
        public int calCen
        {
            get
            {
                int result;
                bool x = int.TryParse(calCena.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            }
        }
        public int calOtro
        {
            get
            {
                int result;
                bool x = int.TryParse(calOtros.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            }
        }
        public VentanaModificar(ObservableCollection<DiaCalorico> lista)
        {
            InitializeComponent();
            combo.ItemsSource = lista;
        }

        private void botonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void botonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DiaCalorico d =(DiaCalorico) combo.SelectedItem;
            if (d != null) { 
                foreach (Calorias c in d.cal)
                {
                    if (c.comida.Equals("Desayuno"))
                        calDesayuno.Text = c.calorias.ToString();
                    else if (c.comida.Equals("Aperitivo"))
                        calAperitivo.Text = c.calorias.ToString();
                    else if (c.comida.Equals("Comida"))
                        calComida.Text = c.calorias.ToString();
                    else if (c.comida.Equals("Merienda"))
                        calMerienda.Text = c.calorias.ToString();
                    else if (c.comida.Equals("Cena"))
                        calCena.Text = c.calorias.ToString();
                    else if (c.comida.Equals("Otros"))
                        calOtros.Text = c.calorias.ToString();
            }
            botonOk.IsEnabled = true;
            }
        }

        private void numericText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
