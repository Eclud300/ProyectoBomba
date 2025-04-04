using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProyectoBomba.View;

namespace ProyectoBomba.ViewModel
{
    public class Agregar_AlarmaViewModel
    {
        public ICommand RegresarCommand { get; }

        public Agregar_AlarmaViewModel()
        {
            RegresarCommand = new Command(async () => await RegresarAListaAlarma());
        }

        private async Task RegresarAListaAlarma()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}