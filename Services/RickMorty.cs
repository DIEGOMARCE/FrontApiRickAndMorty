using System.Text.Json;
using WebRickAndMorty.Interfaz;
using WebRickAndMorty.Models;

namespace WebRickAndMorty.Service
{
    public class RickMorty : IRickMorty
    {
      
        public async Task<Root> GetAllCharacter()
        {
            string url = "https://rickandmortyapi.com/api/character/?page=1";
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var characters = JsonSerializer.Deserialize<Root>(result);
            return characters;
        }

        public async Task<Episodios> GetAllEpisodio()
        {
            string url = "https://rickandmortyapi.com/api/episode";
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();
            var episodio = JsonSerializer.Deserialize<Episodios>(resp);
            return episodio;

        }





   

    }
}
