using ProyectoBomba.ViewModel;
using System.Windows.Input;

namespace ProyectoBomba.View
{
    public partial class Inicio : ContentPage
    {
        private readonly InicioViewModel viewModel;

        public Inicio()
        {
            InitializeComponent();
            viewModel = new InicioViewModel();
            BindingContext = viewModel;
        }

        private async void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            await viewModel.ToggleBombaCommand.ExecuteAsync(e.Value);
        }
    }

    // Extensión para ejecutar comandos asíncronos con parámetros
    public static class CommandExtensions
    {
        public static Task ExecuteAsync<T>(this ICommand command, T parameter)
        {
            var taskCompletionSource = new TaskCompletionSource<object>();
            if (command is Command<T> cmd && cmd.CanExecute(parameter))
            {
                cmd.Execute(parameter);
            }
            taskCompletionSource.SetResult(null);
            return taskCompletionSource.Task;
        }
    }
}
