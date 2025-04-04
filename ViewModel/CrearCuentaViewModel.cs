using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using ProyectoBomba.View;

namespace ProyectoBomba.ViewModel
{
    public class CrearCuentaViewModel
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:7213/api/Usuario"; // Reemplaza con tu URL

        public string Usuario { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }

        public ICommand CrearCuentaCommand { get; }
        public ICommand VolverAlLoginCommand { get; }

        public CrearCuentaViewModel()
        {
            _httpClient = new HttpClient();
            CrearCuentaCommand = new Command(async () => await CrearCuenta());
            VolverAlLoginCommand = new Command(async () => await VolverAlLogin());
        }

        private async Task CrearCuenta()
        {
            if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Correo) || string.IsNullOrWhiteSpace(Contraseña))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            var usuarioModel = new
            {
                Nombre = Usuario,
                Correo = Correo,
                Contrasena = Contraseña
            };

            var json = JsonConvert.SerializeObject(usuarioModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(ApiUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    await Application.Current.MainPage.DisplayAlert("Éxito", "Cuenta creada correctamente", "OK");
                    await Application.Current.MainPage.Navigation.PushAsync(new Login());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo crear la cuenta", "OK");
                }
            }
            catch (HttpRequestException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error de conexión: {ex.Message}", "OK");
            }
        }



        private async Task VolverAlLogin()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
