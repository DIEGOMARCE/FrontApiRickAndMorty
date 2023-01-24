using WebRickAndMorty.Models;

namespace WebRickAndMorty.Interfaz
{
    public interface IRickMorty
    {
        Task<Root> GetAllCharacter();
        Task<Episodios> GetAllEpisodio();
    }
    
}

