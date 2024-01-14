using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IPokemonRespository
    {
        ICollection<Pokemon> GetPokemons();

    }
}
