using ProyectoBomba.ViewModel;
namespace ProyectoBomba.View;

public partial class Alarma : ContentPage
{
	public Alarma()
	{
		InitializeComponent();

        BindingContext = new AlarmaViewModel();
    }
}