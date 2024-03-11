using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace RickAndMorty.Models
{
    public class ModeloServicioAPI
    {
        private readonly HttpClient _httpClient;

        public ModeloServicioAPI()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
        }

        public async Task<List<ModeloPersonaje>> GetCharacters()
        {
            var response = await _httpClient.GetAsync("character");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var characters = JsonConvert.DeserializeObject<ApiResponse<ModeloPersonaje>>(jsonString);
                return characters?.Results;
            }
            return null;
        }

        public async Task<ModeloPersonaje?> GetCharacterById(int characterId)
        {
            var response = await _httpClient.GetAsync($"character/{characterId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var character = JsonConvert.DeserializeObject<ModeloPersonaje>(jsonString);
                return character;
            }
            return null;
        }
    }

    public class ApiResponse<T>
    {
        public List<T>? Results { get; set; }
    }

    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Species { get; set; }
    }
}
