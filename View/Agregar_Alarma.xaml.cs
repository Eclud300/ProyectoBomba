using ProyectoBomba.ViewModel;

namespace ProyectoBomba.View;

public partial class Agregar_Alarma : ContentPage
{
	public Agregar_Alarma()
	{
        InitializeComponent();
        BindingContext = new Agregar_AlarmaViewModel();
    }
}