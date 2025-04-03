namespace ProyectoBomba.View
{
    public partial class RecuperarContrasenaPage : ContentPage
    {
        public RecuperarContrasenaPage()
        {
            InitializeComponent();
        }

        private async void OnVolverLogin(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Login");
        }

        private async void OnIrRegistro(object sender, EventArgs e)
        {
           
        }
    }
}
