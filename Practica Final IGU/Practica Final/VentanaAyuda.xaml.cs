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
using System.Windows.Xps.Packaging;
using System.IO;

namespace Practica_Final
{
    /// <summary>
    /// Lógica de interacción para VentanaAyuda.xaml
    /// </summary>
    public partial class VentanaAyuda : Window
    {
        public VentanaAyuda()
        {
            InitializeComponent();
            XpsDocument doc = new XpsDocument("ayuda.xps", FileAccess.Read);
            ayuda.Document = doc.GetFixedDocumentSequence();
            doc.Close();
        }
    }
}
