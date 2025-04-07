using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoBomba.ViewModel
{
    internal class InicioViewModel
    {
        private readonly HttpClient _httpClient; 
        private const string BombaApiEncenderUrl = "http://172.16.28.150/encenderbomba";
        private const string BombaApiApagarUrl = "http://172.16.28.150/apagarbomba";

        public ICommand ToggleBombaCommand { get; }

        public bool IsBombaEncendida { get; set; }

        public InicioViewModel()
        {
            _httpClient = new HttpClient();
            ToggleBombaCommand = new Command<bool>(async (isOn) => await CambiarEstadoBomba(isOn));
        }
        

        private async Task CambiarEstadoBomba(bool encender)
        {
            try
            {
                var url = encender ? BombaApiEncenderUrl : BombaApiApagarUrl;
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var mensaje = encender ? "🚿 Bomba encendida" : "💧 Bomba apagada";
                    await Application.Current.MainPage.DisplayAlert("Bomba", mensaje, "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "No se pudo cambiar el estado de la bomba", "OK");
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
    }
}
