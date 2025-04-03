using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoBomba.ViewModel
{
    public class AlarmaViewModel
    {
        public ObservableCollection<Alarma> Alarma { get; set; }

        public AlarmaViewModel()
        {
            Alarma = new ObservableCollection<Alarma>
            {
                new Alarma { Hora = "05:00 AM", Dia = "Do." },
                new Alarma { Hora = "08:00 AM", Dia = "Lu." },
                new Alarma { Hora = "11:00 AM", Dia = "Ma." },
                new Alarma { Hora = "01:00 PM", Dia = "Mi." },
                new Alarma { Hora = "03:00 PM", Dia = "Ju." },
                new Alarma { Hora = "05:00 PM", Dia = "Vi." },
                new Alarma { Hora = "07:00 PM", Dia = "Sa." },

            };
        }
    }

    public class Alarma
    {
        public string Hora { get; set; }
        public string Dia { get; set; }
    }
}