using ProyectoBomba.ViewModel;

namespace ProyectoBomba.View
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
            Shell.SetNavBarIsVisible(this, false);

        }
    }
}
