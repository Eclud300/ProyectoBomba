using ProyectoBomba.View;

namespace ProyectoBomba
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Iniciar con la pantalla de Login
            MainPage = new NavigationPage(new Login());
        }

        // Método para cerrar sesión
        public static void CerrarSesion()
        {
            Current.MainPage = new NavigationPage(new Login());
        }
    }
}

