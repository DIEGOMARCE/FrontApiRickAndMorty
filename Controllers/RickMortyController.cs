using Microsoft.AspNetCore.Mvc;
using WebRickAndMorty.Interfaz;
using WebRickAndMorty.Models;


namespace WebRickAndMorty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RickMortyController : ControllerBase
    {
        private readonly IRickMorty _rickMorty;

        public RickMortyController(IRickMorty rickMorty)
        {
            _rickMorty = rickMorty;
        }

       
        [HttpGet("/apiPersonajes")]
        public async Task<Root> Get()
        {
            var result = await _rickMorty.GetAllCharacter();
            return result;
        }


       
        [HttpGet("/apiEpisodios")]
        public async Task<Episodios> GetEpisodio()
        {
            var resp = await _rickMorty.GetAllEpisodio();
            return resp;
        }

       
    }
}
