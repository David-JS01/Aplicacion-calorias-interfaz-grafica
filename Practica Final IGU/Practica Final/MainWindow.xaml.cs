using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace Practica_Final
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VentanaSecundaria venSec;
        int MaximoValor = 1;
        ObservableCollection <DiaCalorico> dias;

        int espaciosDeBarras = 10;
        int altura = 0;
        Storyboard st = new Storyboard();
        bool representadoDiaCompleto = false;
        bool representadoGraficoLineas = false;
        Label etiqTop, etiqMedio, etiqBajo, etiq34Top, etiq14Top;
        Preferencias preferen;
        bool guardado = true;
        String rutaGuardado;
        public MainWindow()
        {
            InitializeComponent();
            dias = new ObservableCollection<DiaCalorico>();
            dias.CollectionChanged += Dias_CollectionChanged;
            preferen = new Preferencias();
            etiqTop = new Label();
            etiq34Top = new Label();
            etiq14Top = new Label();
            etiqMedio = new Label();
            etiqBajo = new Label();
            etiqBajo.Content = 0;
            etiqTop.FontSize = 10;
            lienzo.Children.Add(etiqTop);
            lienzo.Children.Add(etiq34Top);
            lienzo.Children.Add(etiqMedio);
            lienzo.Children.Add(etiq14Top);
            lienzo.Children.Add(etiqBajo);
            Canvas.SetTop(etiqTop, 0);
            Canvas.SetTop(etiq34Top, 1*lienzo.Height/4);
            Canvas.SetTop(etiqMedio, lienzo.Height / 2);
            Canvas.SetTop(etiq14Top, 3 * lienzo.Height / 4);
            Canvas.SetBottom(etiqBajo, 0);
        }

        private void Dias_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            guardado = false;
            if (dias.Count == espaciosDeBarras)
                espaciosDeBarras += 10;
            if (e.NewItems != null) { 
                foreach(DiaCalorico d in e.NewItems)
                {
                    if (d.caloriasTotales > MaximoValor)
                    {
                        MaximoValor = d.caloriasTotales;
                    }
                }
                if (representadoDiaCompleto)
                {
                    botonVolver.IsEnabled = false;
                    representadoDiaCompleto = false;
                }
                redibujarBarras();
            }
            if (e.OldItems != null)
            {
                if (representadoDiaCompleto)
                {
                    botonVolver.IsEnabled = false;
                    representadoDiaCompleto = false;
                }
                MaximoValor = 1;
                foreach (DiaCalorico d in dias)
                {
                    if (d.caloriasTotales > MaximoValor)
                    {
                        MaximoValor = d.caloriasTotales;
                    }
                }
                redibujarBarras();
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            venSec = new VentanaSecundaria(dias);
            venSec.Owner = this;
            venSec.Closed += VenSec_Closed;
            venSec.CambioElDiaSeleccionado += VenSec_CambioElDiaSeleccionado;
            venSec.Show();
        }

        private void VenSec_CambioElDiaSeleccionado(object sender, DiaSeleccionadoEventArgs e)
        {
            dibujarBarrasDia(e.d);
        }

        private void botonVentSecund_Click(object sender, RoutedEventArgs e)
        {
            if (venSec != null)
            {
                venSec.Show();
                return;
            }
            
            venSec = new VentanaSecundaria(dias);
            venSec.Owner = this;
            venSec.Show();
            venSec.Closing += VenSec_Closing;
            venSec.Closed += VenSec_Closed;
            venSec.CambioElDiaSeleccionado += VenSec_CambioElDiaSeleccionado;

        }

        private void VenSec_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //venSec.Hide();
           // e.Cancel = true;
        }

        private void VenSec_Closed(object sender, EventArgs e)
        {
           // venSec.Hide();
            
            //venSec.Close();
            //venSec = null;
        }

        private void botonAñadir_Click(object sender, RoutedEventArgs e)
        {
            VentanaAñadir venAn = new VentanaAñadir();
            venAn.ShowDialog();
            if (venAn.DialogResult == true)
            {
                DateTime fech= venAn.fecha;
                int des = venAn.calDesayuno;
                int ape = venAn.calAperitivo;
                int com = venAn.calComida;
                int mer = venAn.calMerienda;
                int cen = venAn.calCena;
                int otro = venAn.calOtros;
                DiaCalorico d = new DiaCalorico(fech,des,ape,com,mer,cen,otro);
                dias.Add(d);
               
            }
        }

        private void botonModificar_Click(object sender, RoutedEventArgs e)
        {
            VentanaModificar venMod = new VentanaModificar(dias);
            venMod.ShowDialog();
            if (venMod.DialogResult == true)
            {
                guardado = false;
                DiaCalorico d = venMod.diaSelec;
                d.caloriasTotales=0;
                foreach (Calorias c in d.cal)
                {
                    if (c.comida.Equals("Desayuno"))
                        c.calorias = venMod.calDesayun;
                    else if (c.comida.Equals("Aperitivo"))
                        c.calorias = venMod.calAperitiv;
                    else if (c.comida.Equals("Comida"))
                        c.calorias = venMod.calComid;
                    else if (c.comida.Equals("Merienda"))
                        c.calorias = venMod.calMeriend;
                    else if (c.comida.Equals("Cena"))
                        c.calorias = venMod.calCen;
                    else if (c.comida.Equals("Otros"))
                        c.calorias = venMod.calOtro;
                    d.caloriasTotales += c.calorias;
                }
                if (d.caloriasTotales > MaximoValor)
                {
                    MaximoValor = d.caloriasTotales;
                }
                if (representadoDiaCompleto)
                {
                    dibujarBarrasDia(d);
                    return;
                }    
                redibujarBarras();
            }
            venMod.Close();

        }

        private void botonAnaAleat_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            DiaCalorico dc = new DiaCalorico(DateTime.Today, r.Next(700), r.Next(700), r.Next(700), r.Next(700), r.Next(700), r.Next(700));
            dias.Add(dc);

        }

        

        private void RefStack_MouseLeave(object sender, MouseEventArgs e)
        {
            StackPanel s = (StackPanel)sender;
            s.Height = s.ActualHeight - 5;
            s.Opacity = 1;
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void CerrarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void RefStack_MouseEnter(object sender, MouseEventArgs e)
        {
            StackPanel s = (StackPanel)sender;
            s.Height =s.ActualHeight+ 5;
            s.Opacity = 0.7;
            Mouse.OverrideCursor = Cursors.Hand;
            
        }

        private void botonVolver_Click(object sender, RoutedEventArgs e)
        {
            etiqTop.Content = MaximoValor;
            etiq34Top.Content = MaximoValor * 3 / 4;
            etiqMedio.Content = MaximoValor / 2;
            etiq14Top.Content = MaximoValor * 1 / 4;
            redibujarBarras();
            botonVolver.IsEnabled = false;
            representadoDiaCompleto = false;
            venSec.selectedDia = null;
            
            
        }

        private void RefStack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            foreach (DiaCalorico d in dias)
            {
                if (d.refStack == (StackPanel)sender)
                {
                   
                    venSec.selectedDia = d;
                }
            }
        }

        private void botonBorrar_Click(object sender, RoutedEventArgs e)
        {
            VentanaBorrar vb = new VentanaBorrar(dias);
            vb.ShowDialog();
            if (vb.DialogResult == true)
            {
               
                List<DiaCalorico> d = vb.diasSeleccionados;
                foreach (DiaCalorico dc in d)
                {
                    dias.Remove(dc);
                }
                
            }
        }

        private void grafLinea_Checked(object sender, RoutedEventArgs e)
        {
            lienzo.Children.Clear();
            lienzo.Children.Add(etiqTop);
            lienzo.Children.Add(etiq34Top);
            lienzo.Children.Add(etiqMedio);
            lienzo.Children.Add(etiq14Top);
            lienzo.Children.Add(etiqBajo);
            Canvas.SetTop(etiqTop, 0);
            Canvas.SetTop(etiq34Top, 1 * lienzo.Height / 4);
            Canvas.SetTop(etiqMedio, lienzo.Height / 2);
            Canvas.SetTop(etiq14Top, 3 * lienzo.Height / 4);
            Canvas.SetBottom(etiqBajo, 0);
            Point p;
            Polyline polilinea = new Polyline();
            polilinea.Stroke = preferen.colorLinea;
            polilinea.StrokeThickness = preferen.grosorLinea;
            double espacio = (lienzo.ActualWidth) / espaciosDeBarras;

            st = new Storyboard();
            DoubleAnimation ani = new DoubleAnimation();
            ani.From = 0;
            ani.To = 1;
            ani.Duration = new Duration(TimeSpan.FromSeconds(1.2));
            ani.FillBehavior = FillBehavior.Stop;

            if (FindName("polilinea") != null)
                UnregisterName("polilinea");
            RegisterName("polilinea", polilinea);
            st.Children.Add(ani);
            Storyboard.SetTargetName(ani, "polilinea");
            Storyboard.SetTargetProperty(ani, new PropertyPath(Polyline.OpacityProperty));
            polilinea.Loaded += Polilinea_Loaded;
            
            foreach (DiaCalorico d in dias)
            {
                p = new Point();
                p.X = espacio * (dias.IndexOf(d)+1);
                p.Y =lienzo.ActualHeight-( d.caloriasTotales * ((lienzo.ActualHeight-10) / MaximoValor));
                
                                
                polilinea.Points.Add(p);
            }
            
            DoubleAnimation ani2 = new DoubleAnimation();
            ani2.From = 0;
            ani2.To = espacio * (dias.Count);
            ani2.Duration = new Duration(TimeSpan.FromSeconds(1.2));
            ani2.FillBehavior = FillBehavior.Stop;
            st.Children.Add(ani2);
            Storyboard.SetTargetName(ani2, "polilinea");
            Storyboard.SetTargetProperty(ani2, new PropertyPath(Polyline.WidthProperty));

            lienzo.Children.Add(polilinea);
            representadoGraficoLineas = true;
        }

        private void Polilinea_Loaded(object sender, RoutedEventArgs e)
        {
            st.Begin((Polyline)sender);
        }

        private void grafLinea_Unchecked(object sender, RoutedEventArgs e)
        {
            redibujarBarras();
            representadoGraficoLineas = false;
        }

        private void R_Loaded(object sender, RoutedEventArgs e)
        {
            st.Begin((Rectangle)sender);
        }

        private void NuevoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            foreach (DiaCalorico a in dias)
            {
                UnregisterName(a.refStack.Name);
            }
            dias.Clear();
            redibujarBarras();
            rutaGuardado = null;
            guardado = true;
        }

        private void botonPreferencias_Click(object sender, RoutedEventArgs e)
        {
            VentanaPreferencias vp = new VentanaPreferencias(preferen);
            vp.ShowDialog();
            if (vp.DialogResult == true)
            {
                preferen.colorDesayuno = vp.colorDes;
                preferen.colorAperitivo = vp.colorApe;
                preferen.colorComida = vp.colorCom;
                preferen.colorMerienda = vp.colorMer;
                preferen.colorCena = vp.colorCen;
                preferen.colorOtros = vp.colorOtr;
                preferen.bordeRedondeado = vp.borde;
                preferen.colorLinea = vp.colorLinea;
                preferen.grosorLinea = vp.grosorLinea;
                if (grafLinea.IsChecked)
                {
                    grafLinea.IsChecked = false;
                    grafLinea.IsChecked = true;
                }else
                    redibujarBarras();
            }
        }

        private void GuardarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            guardar();
        }

        private void GuardarComoMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Guardar archivo de calorias";
            sfd.Filter = "Archivos de texto (*.cal)|*.cal|Todos los archivos (*.*)|*.*";

            if (sfd.ShowDialog() == true)
            {
                StreamWriter w = new StreamWriter(sfd.FileName);
                rutaGuardado = sfd.FileName.ToString();
                guardado = true;
                String s = String.Format("{0 , -30} {1, -25} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15} {7, -15}", "FECHA", "CALORIAS TOTALES",
                    "DESAYUNO", "APERITIVO", "COMIDA", "MERIENDA", "CENA", "OTROS");
                w.WriteLine(s);
                foreach (DiaCalorico d in dias)
                {
                    s = String.Format("{0 , -30} {1, -25}", d.fecha.ToString(), d.caloriasTotales.ToString());
                    foreach (Calorias c in d.cal)
                    {
                        s += String.Format("{0, -15}", c.calorias.ToString());
                    }
                    w.WriteLine(s);
                }
                

                w.Close();
            }
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!guardado)
            {
                MessageBoxResult resultado=MessageBox.Show("No se guardaron los ultimos cambios. ¿Desea guardar?", "Aviso", MessageBoxButton.YesNoCancel);
                switch (resultado)
                {
                    case MessageBoxResult.Yes:
                        guardar();
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }

        }

        private void AbrirMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.cal)|*.cal|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                int a = 0;
                
                foreach (string line in System.IO.File.ReadLines(openFileDialog.FileName))
                {
                    List<String> dia = new List<String>();
                    if (a == 0)
                    {
                        a = 1;
                        continue;
                    }
                    String[] s = line.Split(' ');
                    for (int i =0; i<s.Length; i++)
                    {
                        if (s[i].Equals(""))
                        {
                            continue;
                        }
                        else
                        {
                            dia.Add(s[i]);
                            
                            
                        }
                     
                    }
                    s = dia.ToArray();
                    int[] datos = new int[7];
                    DateTime t;
                    if (DateTime.TryParse(s[0]+" "+s[1], out t) == false) {
                        MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (int.TryParse(s[2], out datos[0]) == false)
                    {
                        MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButton.OK);
                        return;
                    }
                       
                    if (int.TryParse(s[3], out datos[1]) == false)
                    {
                        MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButton.OK);
                        return;
                    }
                        
                    if (int.TryParse(s[4], out datos[2]) == false)
                    {
                        MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButton.OK);
                        return;
                    }
                        
                    if (int.TryParse(s[5], out datos[3]) == false)
                    {
                        MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButton.OK);
                        return;
                    }
                        
                    if (int.TryParse(s[6], out datos[4]) == false)
                    {
                        MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButton.OK);
                        return;
                    }
                        
                    if (int.TryParse(s[7], out datos[5]) == false)
                    {
                        MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButton.OK);
                        return;
                    }
                        
                    if (int.TryParse(s[8], out datos[6]) == false)
                    {
                        MessageBox.Show("No se pudo abrir el archivo.", "Error", MessageBoxButton.OK);
                        return;
                    }
                        

                    DiaCalorico d = new DiaCalorico(t, datos[1], datos[2], datos[3], datos[4], datos[5], datos[6]);
                    dias.Add(d);
                }
            }

        }

        private void RefStack_Loaded(object sender, RoutedEventArgs e)
        {
            
            st.Begin((StackPanel)sender);
            
        }

        private void ayuda_Click(object sender, RoutedEventArgs e)
        {
            VentanaAyuda va = new VentanaAyuda();
            va.ShowDialog();
        }

        private void redibujarBarras()
        {
            if (representadoGraficoLineas)
            {
                grafLinea.IsChecked = false;
                representadoGraficoLineas = false;
            }
            lienzo.Children.Clear();
            lienzo.Children.Add(etiqTop);
            lienzo.Children.Add(etiq34Top);
            lienzo.Children.Add(etiqMedio);
            lienzo.Children.Add(etiq14Top);
            lienzo.Children.Add(etiqBajo);
            Canvas.SetTop(etiqTop, 0);
            Canvas.SetTop(etiq34Top, 1 * lienzo.Height / 4 - 35);
            Canvas.SetTop(etiqMedio, lienzo.Height / 2 - 35);
            Canvas.SetTop(etiq14Top, 3 * lienzo.Height / 4 - 35);
            Canvas.SetBottom(etiqBajo, 35);
            etiqTop.Content = MaximoValor;
            etiq34Top.Content = MaximoValor * 3 / 4;
            etiqMedio.Content = MaximoValor / 2;
            etiq14Top.Content = MaximoValor * 1 / 4;
            foreach (DiaCalorico d in dias)
            {
                anadirBarras(d);
            }
        }

        private void dibujarBarrasDia(DiaCalorico d)
        {
            if (representadoGraficoLineas)
            {
                grafLinea.IsChecked = false;
                representadoGraficoLineas = false;
            }
            if (d == null)
                return;
            DoubleAnimation ani;
            st = new Storyboard();
            lienzo.Children.Clear();
            lienzo.Children.Add(etiqTop);
            lienzo.Children.Add(etiq34Top);
            lienzo.Children.Add(etiqMedio);
            lienzo.Children.Add(etiq14Top);
            lienzo.Children.Add(etiqBajo);
            Canvas.SetTop(etiqTop, 0);
            Canvas.SetTop(etiq34Top, 1 * lienzo.Height / 4 -25);
            Canvas.SetTop(etiqMedio, lienzo.Height / 2 -25);
            Canvas.SetTop(etiq14Top, 3 * lienzo.Height / 4 -25);
            Canvas.SetBottom(etiqBajo, 25);
            double espacio = lienzo.ActualWidth / 7;
            int a = 0;
            int maximasCalorias = 1;
            foreach (Calorias c in d.cal)
            {
                if (c.calorias > maximasCalorias)
                    maximasCalorias = c.calorias;
            }
            etiqTop.Content = maximasCalorias;
            etiq34Top.Content = maximasCalorias / 4 * 3;
            etiqMedio.Content = maximasCalorias / 2;
            etiq14Top.Content = maximasCalorias / 4;
            etiqBajo.Content = 0;
            foreach (Calorias c in d.cal)
            {

                ani = new DoubleAnimation();
                Rectangle r = new Rectangle();
                r.Height = c.calorias * (lienzo.ActualHeight - 25) / maximasCalorias;
                r.Width = 0.6 * espacio;
                ani.From = 0;
                ani.To = r.Height;
                ani.Duration = new Duration(TimeSpan.FromSeconds(1));
                ani.FillBehavior = FillBehavior.Stop;
                r.Name = "rectangulo" + a;
                if (FindName(r.Name) != null)
                {
                    UnregisterName(r.Name);
                }
                RegisterName(r.Name, r);
                st.Children.Add(ani);
                Storyboard.SetTargetName(ani, r.Name);
                Storyboard.SetTargetProperty(ani, new PropertyPath(Rectangle.HeightProperty));
                r.Loaded += R_Loaded;
                switch (a)
                {
                    case 0:
                        r.Fill = preferen.colorDesayuno;
                        break;
                    case 1:
                        r.Fill = preferen.colorAperitivo;
                        break;
                    case 2:
                        r.Fill = preferen.colorComida;
                        break;
                    case 3:
                        r.Fill = preferen.colorMerienda;
                        break;
                    case 4:
                        r.Fill = preferen.colorCena;
                        break;
                    case 5:
                        r.Fill = preferen.colorOtros;
                        break;
                }
                a++;

                ToolTip tt = new ToolTip();
                tt.Content = "COMIDA: " + c.comida + '\n' + "CALORIAS: " + c.calorias;
                r.ToolTip = tt;

                lienzo.Children.Add(r);
                Label l = new Label();
                l.Content = c.comida;
                lienzo.Children.Add(l);

                Canvas.SetLeft(r, espacio * (a));
                Canvas.SetBottom(r, 25);

                Canvas.SetLeft(l, espacio * a);
                Canvas.SetBottom(l, 0);
            }
            botonVolver.IsEnabled = true;
            representadoDiaCompleto = true;

        }

        private void anadirBarras(DiaCalorico dc)
        {
            int i = dias.IndexOf(dc) + 1;
            double espacio = lienzo.ActualWidth / espaciosDeBarras;

            dc.refStack.Width = espacio * 0.5; // obtenemos el ancho de la barra teniendo en cuenta que ocupara el 60%
            //el otro 40% sera para seraparar las barras
            dc.refStack.Height = dc.caloriasTotales * ((lienzo.ActualHeight - 35) / MaximoValor); //obtenemos la altura respecto del lienzo regla de tres

            dc.refStack.Children.Clear();


            DoubleAnimation ani = new DoubleAnimation();
            st = new Storyboard();
            dc.refStack.Name = "stack" + dias.IndexOf(dc);
            if (FindName(dc.refStack.Name) != null)
                UnregisterName(dc.refStack.Name);
            RegisterName(dc.refStack.Name, dc.refStack);
            ani.From = 0;
            ani.To = dc.refStack.Height;
            ani.Duration = new Duration(TimeSpan.FromSeconds(1));
            ani.FillBehavior = FillBehavior.Stop;
            st.Children.Add(ani);
            
            Storyboard.SetTargetName(ani, dc.refStack.Name);
            Storyboard.SetTargetProperty(ani, new PropertyPath(StackPanel.HeightProperty));
            
            dc.refStack.Loaded += RefStack_Loaded;
            dc.refStack.MouseLeftButtonDown += RefStack_MouseLeftButtonDown;
            dc.refStack.MouseEnter -= RefStack_MouseEnter;
            dc.refStack.MouseEnter += RefStack_MouseEnter;
            dc.refStack.MouseLeave -= RefStack_MouseLeave;
            dc.refStack.MouseLeave += RefStack_MouseLeave;
            bool redondear = false;
            if (preferen.bordeRedondeado == 1)
                redondear = true;

            int a = 0;
            foreach (Calorias c in dc.cal)
            {
                
                Border b = new Border();
                Rectangle r = new Rectangle();
                if (redondear == true) { 
                    b.Height = c.calorias * ((lienzo.ActualHeight - 35) / MaximoValor);
                    b.CornerRadius = new CornerRadius(5, 5, 0, 0);
                }
                else
                    r.Height = c.calorias * ((lienzo.ActualHeight - 35) / MaximoValor);

                switch (a)
                {
                    case 0:
                        if (redondear)
                            b.Background = preferen.colorDesayuno;
                        else
                            r.Fill = preferen.colorDesayuno;
                        break;
                    case 1:
                        r.Fill = preferen.colorAperitivo;
                        break;
                    case 2:
                        r.Fill = preferen.colorComida;
                        break;
                    case 3:
                        r.Fill = preferen.colorMerienda;
                        break;
                    case 4:
                        r.Fill = preferen.colorCena;
                        break;
                    case 5:
                        r.Fill = preferen.colorOtros;
                        break;
                }
                a++;
                if (redondear)
                    dc.refStack.Children.Add(b);
                else
                    dc.refStack.Children.Add(r);

                if (redondear && b.Height > 0)
                    redondear = false;

            }

            Label z = new Label();
            z.FontSize = 8;
            z.HorizontalContentAlignment = HorizontalAlignment.Left;
            z.Content = dc.fecha.Date;
            lienzo.Children.Add(z);
            Canvas.SetLeft(z, i * espacio - espacio * 0.2);
            Canvas.SetBottom(z, altura * 8);
            altura++;

            ToolTip tt = new ToolTip();
            tt.Content = "FECHA: " + dc.fecha.Date +'\n'+ "CALORIAS TOTALES: " + dc.caloriasTotales;
            dc.refStack.ToolTip = tt;

            lienzo.Children.Add(dc.refStack);
            Canvas.SetLeft(dc.refStack, i * espacio);
            Canvas.SetBottom(dc.refStack, 35);

            if (altura == 3) altura = 0;

        }

        private void guardar()
        {
            if (rutaGuardado == null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Guardar archivo de calorias";
                sfd.Filter = "Archivos de calorias (*.cal)|*.cal|Todos los archivos (*.*)|*.*";
                if (sfd.ShowDialog() == true)
                {
                    rutaGuardado = sfd.FileName.ToString();

                }

            }

            if (rutaGuardado != null)
            {
                StreamWriter w = new StreamWriter(rutaGuardado);
                guardado = true;
                String s = String.Format("{0 , -30} {1, -25} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15} {7, -15}", "FECHA", "CALORIAS TOTALES",
                "DESAYUNO", "APERITIVO", "COMIDA", "MERIENDA", "CENA", "OTROS");
                w.WriteLine(s);
                foreach (DiaCalorico d in dias)
                {
                    s = String.Format("{0 , -30} {1, -25}", d.fecha.ToString(), d.caloriasTotales.ToString());
                    foreach (Calorias c in d.cal)
                    {
                        s += String.Format("{0, -15}", c.calorias.ToString());
                    }
                    w.WriteLine(s);
                }


                w.Close();
            }
        }
    }
}
