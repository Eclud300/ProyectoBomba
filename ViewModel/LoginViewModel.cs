using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using ProyectoBomba.View;
using System;

namespace ProyectoBomba.ViewModel
{
    public class LoginViewModel
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrlBase = "https://7b4763sm-5098.usw3.devtunnels.ms/api/Usuario";

        public string Usuario { get; set; }      // Correo
        public string Contrasena { get; set; }   // Contraseña

        public ICommand LoginCommand { get; }
        public ICommand CrearCuentaCommand { get; }

        public LoginViewModel()
        {
            _httpClient = new HttpClient();
            LoginCommand = new Command(async () => await IniciarSesion());
            CrearCuentaCommand = new Command(async () => await IrACrearCuenta());
        }

        private async Task IniciarSesion()
        {
            if (string.IsNullOrWhiteSpace(Usuario) || string.IsNullOrWhiteSpace(Contrasena))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor ingrese su correo y contraseña", "OK");
                return;
            }

            var apiUrl = $"{ApiUrlBase}/by-email-and-password/{Usuario}/{Contrasena}";

            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResult = await response.Content.ReadAsStringAsync();
                    var usuario = JsonConvert.DeserializeObject<dynamic>(jsonResult);

                    await Application.Current.MainPage.DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
                }
            }
            catch (HttpRequestException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Error de conexión: {ex.Message}", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }

        private async Task IrACrearCuenta()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CrearCuenta());
        }
    }
}
