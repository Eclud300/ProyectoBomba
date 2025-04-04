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
            _httpClient.BaseAddress = new Uri("https://localhost:7213/api/Usuario"); // Cambia esto a la URL de tu API
        }

     
    }
}