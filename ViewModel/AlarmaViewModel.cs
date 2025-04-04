using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProyectoBomba.View;

namespace ProyectoBomba.ViewModel
{
    public class Alarma
    {
        public string Hora { get; set; }
        public string Dia { get; set; }
    }


    public class AlarmaViewModel
    {
        public ObservableCollection<Alarma> Alarma { get; set; }
        public ICommand AgregarAlarmaCommand { get; }


        public AlarmaViewModel()
        {

            AgregarAlarmaCommand = new Command(async () => await IrAgregarAlarma());

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


        private async Task IrAgregarAlarma()
        {
            // Navegar a la página de crear cuenta usando la ruta registrada
            await Application.Current.MainPage.Navigation.PushAsync(new Agregar_Alarma());
        }
    }
}