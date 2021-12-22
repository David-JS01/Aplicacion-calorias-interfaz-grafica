using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_Final
{
    public class Calorias : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        String comida_;
        int calorias_;
        public String comida { 
            get { return comida_; }
            set { comida_ = value; OnPropertyChanged("comida"); } }
        public int calorias { 
            get { return calorias_; }
            set { calorias_ = value; OnPropertyChanged("calorias"); } }

        void OnPropertyChanged(String n)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(n));
        }

        public Calorias(String comida, int calorias)
        {
            this.comida = comida;
            this.calorias = calorias;
        }
    }
}
