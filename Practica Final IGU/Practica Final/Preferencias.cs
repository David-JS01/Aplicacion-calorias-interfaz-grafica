using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Practica_Final
{
    public class Preferencias
    {
        public SolidColorBrush colorDesayuno { get; set; }
        public SolidColorBrush colorAperitivo { get; set; }
        public SolidColorBrush colorComida { get; set; }
        public SolidColorBrush colorMerienda { get; set; }
        public SolidColorBrush colorCena { get; set; }
        public SolidColorBrush colorOtros { get; set; }
        public SolidColorBrush colorLinea { get; set; }
        public int grosorLinea { get; set; }
        public int bordeRedondeado { get; set; }
        
        public Preferencias()
        {
            colorDesayuno = Brushes.Red;
            colorAperitivo = Brushes.Blue;
            colorComida = Brushes.Green;
            colorMerienda = Brushes.Yellow;
            colorCena = Brushes.Purple;
            colorOtros = Brushes.Gray;
            colorLinea = Brushes.Red;
            grosorLinea = 5;
            bordeRedondeado = 0;
        }

    }
}
