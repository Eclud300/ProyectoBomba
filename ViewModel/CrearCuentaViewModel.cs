using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ProyectoBomba.View;

namespace ProyectoBomba.ViewModel
{

    // Intentan conectar la api a la aplicacion web
    public class CrearCuentaViewModel
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        // Comandos
        public ICommand CrearCuentaCommand { get; }
        public ICommand VolverAlLoginCommand { get; }

        public CrearCuentaViewModel()
        {
            CrearCuentaCommand = new Command(async () => await CrearCuenta());
            VolverAlLoginCommand = new Command(async () => await VolverAlLogin());
        }

        private async Task CrearCuenta()
        {
            // Simulación de creación de cuenta
            await Application.Current.MainPage.DisplayAlert("Éxito", "Cuenta creada correctamente", "OK");

            // Navegar al Login después de crear la cuenta
            await Application.Current.MainPage.Navigation.PushAsync(new Login());
        }

        private async Task VolverAlLogin()
        {
            // Navegar de vuelta al Login
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}