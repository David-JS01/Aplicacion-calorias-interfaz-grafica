using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practica_Final
{
    public class DiaCalorico : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        DateTime fecha_;
        StackPanel refStack_;
        int caloriasTotales_;
       public DateTime fecha {
            get { return fecha_; } 
            set { fecha_ = value; OnPropertyChanged("fecha"); } }
        public ObservableCollection<Calorias> cal { get; set; }
        public StackPanel refStack { 
            get { return refStack_; }
            set { refStack_ = value; OnPropertyChanged("refStack"); } }
        public int caloriasTotales { 
            get { return caloriasTotales_; }
            set { caloriasTotales_ = value; OnPropertyChanged("caloriasTotales"); } }

        void OnPropertyChanged(string n)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(n));
        }

        public DiaCalorico(DateTime fecha, int calDesayuno, int calAperitivo, int calComida, int calMerienda, int calCena, int calOtros)
        {
            this.cal = new ObservableCollection<Calorias>();
            this.fecha = fecha;
            Calorias c = new Calorias("Desayuno", calDesayuno);
            cal.Add(c);
            c = new Calorias("Aperitivo", calAperitivo);
            cal.Add(c);
            c = new Calorias("Comida", calComida);
            cal.Add(c);
            c = new Calorias("Merienda", calMerienda);
            cal.Add(c);
            c = new Calorias("Cena", calCena);
            cal.Add(c);
            c = new Calorias("Otros", calOtros);
            cal.Add(c);
            this.refStack = new StackPanel();
            this.caloriasTotales = calDesayuno + calAperitivo + calComida + calMerienda + calCena + calOtros;
            
        }

        public DiaCalorico()
        {

        }
        public override string ToString()
        {
            return fecha.ToShortDateString();
        }
    }
}
