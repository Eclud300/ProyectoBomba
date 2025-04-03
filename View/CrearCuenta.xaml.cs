using ProyectoBomba.ViewModel;
namespace ProyectoBomba.View;

public partial class CrearCuenta : ContentPage
{
	public CrearCuenta()
	{
		InitializeComponent();
         BindingContext = new CrearCuentaViewModel();
    }
}