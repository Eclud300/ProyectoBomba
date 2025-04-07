using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using ProyectoBomba.View;

namespace ProyectoBomba.ViewModel
{
    public class LoginViewModel
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }

        public ICommand LoginCommand { get; }
        public ICommand CrearCuentaCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await IniciarSesion());
            CrearCuentaCommand = new Command(async () => await IrACrearCuenta());
        }

        private async Task IniciarSesion()
        {
            // Mostrar mensaje de éxito
            await Application.Current.MainPage.DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");

            // Ir a la pantalla de inicio
            Application.Current.MainPage = new AppShell();
        }

        private async Task IrACrearCuenta()
        {
            // Navegar a la página de crear cuenta usando la ruta registrada
            await Application.Current.MainPage.Navigation.PushAsync(new CrearCuenta());
        }
    }
}