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
using System.Windows.Shapes;

namespace Practica_Final
{
    /// <summary>
    /// Lógica de interacción para VentanaAñadir.xaml
    /// </summary>
    public partial class VentanaAñadir : Window
    {
        public DateTime fecha { get { return (DateTime)calendario.SelectedDate; } }
        public int calDesayuno { get {
                int result;
                bool x = int.TryParse(textCalDesayuno.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            } }
        public int calAperitivo { get {
                int result;
                bool x = int.TryParse(textCalAperitivo.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            } }
        public int calComida { get {
                int result;
                bool x = int.TryParse(textCalComida.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            } }
        public int calMerienda { get {
                int result;
                bool x = int.TryParse(textCalMerienda.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            } }
        public int calCena { get {
                int result;
                bool x = int.TryParse(textCalCena.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            } }
        public int calOtros { get {
                int result;
                bool x = int.TryParse(textCalOtros.Text, out result);
                if (x)
                    return result;
                else
                    return 0;
            } }
        public VentanaAñadir()
        {
            InitializeComponent();
            textFecha.Text = DateTime.Today.ToString().Split(' ')[0];
            calendario.SelectedDate = DateTime.Today;
        }

        private void botonOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void botonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void numericTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void calendario_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            String[] s = calendario.SelectedDate.ToString().Split(' ');
            textFecha.Text = s[0];
        }
    }
}
