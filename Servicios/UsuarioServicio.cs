using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ProyectoBomba.Modelo;

namespace ProyectoBomba.Servicios
{
    public class UsuarioServicio
    {
        private readonly HttpClient _httpClient;

        public UsuarioServicio()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://tuservidorapi.com/"); // Cambia esto a la URL de tu API
        }

        public async Task<bool> CrearCuenta(UsuarioModel usuario)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/usuarios/crear", usuario); // Ajusta la ruta de la API

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                // Si la respuesta no es exitosa, mostramos el mensaje de error
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error al crear cuenta: " + errorMessage);
                return false;
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción que ocurra
                Console.WriteLine("Excepción: " + ex.Message);
                return false;
            }
        }
    }
}