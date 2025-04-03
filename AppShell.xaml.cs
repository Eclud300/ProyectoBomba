using ProyectoBomba.View;

namespace ProyectoBomba
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registrar rutas de navegación (corrigiendo nombres)
            Routing.RegisterRoute(nameof(Login), typeof(Login));
            Routing.RegisterRoute(nameof(CrearCuenta), typeof(CrearCuenta));
            Routing.RegisterRoute(nameof(Inicio), typeof(Inicio));
            Routing.RegisterRoute(nameof(Historial), typeof(Historial));
        }

        private async void OnCerrarSesion(object sender, EventArgs e)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Cerrar Sesión",
                "¿Estás seguro de que quieres cerrar sesión?",
                "Sí",
                "No");

            if (confirm)
            {
                // Volver al login asegurando que la navegación funciona correctamente
                Application.Current.MainPage = new NavigationPage(new Login());

                Routing.RegisterRoute(nameof(CrearCuenta), typeof(CrearCuenta));


            }
        }
    }
}