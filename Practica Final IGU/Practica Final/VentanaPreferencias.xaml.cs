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
    /// Lógica de interacción para VentanaPreferencias.xaml
    /// </summary>
    public partial class VentanaPreferencias : Window
    {
        Rectangle rectSeleccionado;
        
        public SolidColorBrush colorDes
        {
            get { return (SolidColorBrush) rectDesayuno.Fill; }
        }
        public SolidColorBrush colorApe
        {
            get { return (SolidColorBrush)rectAperitivo.Fill; }
        }
        public SolidColorBrush colorCom
        {
            get { return (SolidColorBrush)rectComida.Fill; }
        }
        public SolidColorBrush colorMer
        {
            get { return (SolidColorBrush)rectMerienda.Fill; }
        }
        public SolidColorBrush colorCen
        {
            get { return (SolidColorBrush)rectCena.Fill; }
        }
        public SolidColorBrush colorOtr
        {
            get { return (SolidColorBrush)rectOtros.Fill; }
        }
        public int borde
        {
            get { if (botRedondeado.IsChecked == true)
                    return 1;
                else
                    return 0;
            }
        }
        public int grosorLinea
        {
            get { return (int)polilineaPrefe.StrokeThickness; }
        }
        public SolidColorBrush colorLinea
        {
            get { return (SolidColorBrush)polilineaPrefe.Stroke; }
        }
        public VentanaPreferencias(Preferencias p)
        {
            InitializeComponent();
            rectDesayuno.Fill = p.colorDesayuno;
            rectAperitivo.Fill = p.colorAperitivo;
            rectComida.Fill = p.colorComida;
            rectMerienda.Fill = p.colorMerienda;
            rectCena.Fill = p.colorCena;
            rectOtros.Fill = p.colorOtros;
            rectSeleccionado = rectDesayuno;
            rectSeleccionado.Stroke = Brushes.Black;
            rectSeleccionado.StrokeThickness = 2;
            rectSeleccionado.Width = rectSeleccionado.Width + 10;
            rectSeleccionado.Height = rectSeleccionado.Height + 10;
            if (p.bordeRedondeado == 0)
                botCuadrado.IsChecked = true;
            else
                botRedondeado.IsChecked = true;
            sliderGrosor.Value = p.grosorLinea;
            etiqGrosor.DataContext = sliderGrosor;
            polilineaPrefe.DataContext = sliderGrosor;
            polilineaPrefe.Stroke = p.colorLinea;
            
        }

        private void rectDesayuno_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            if (r != rectSeleccionado) { 
                r.Width += 10;
                r.Height += 10;
                Mouse.OverrideCursor = Cursors.Hand;
            }
        }

        private void rectDesayuno_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            if (r != rectSeleccionado) {
                r.Width -= 10;
                r.Height -= 10;
            }
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void rectDesayuno_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((Rectangle)sender != rectSeleccionado) { 
                rectSeleccionado.StrokeThickness = 0;
                rectSeleccionado.Width -= 10;
                rectSeleccionado.Height -= 10;
                rectSeleccionado = (Rectangle)sender;
                rectSeleccionado.StrokeThickness = 2;
                rectSeleccionado.Stroke = Brushes.Black;
                SolidColorBrush s= (SolidColorBrush) rectSeleccionado.Fill;
               
                sliderR.DataContext = s.Color;
                sliderG.DataContext = s.Color;
                sliderB.DataContext = s.Color;

            }

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush color;
            Color c = new Color();
            c.A = 255;
            c.R = (Byte)sliderR.Value;
            c.G= (Byte)sliderG.Value;
            c.B = (Byte)sliderB.Value;
            color = new SolidColorBrush(c);
            rectSeleccionado.Fill = color;
            
        }

        private void botonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void botonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void sLR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SolidColorBrush color;
            Color c = new Color();
            c.A = 255;
            c.R = (Byte)sLR.Value;
            c.G = (Byte)sLG.Value;
            c.B = (Byte)sLB.Value;
            color = new SolidColorBrush(c);
            polilineaPrefe.Stroke = color;
        }
    }
}
