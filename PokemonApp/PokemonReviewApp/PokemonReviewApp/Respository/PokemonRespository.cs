using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Respository
{
    public class PokemonRespository : IPokemonRespository
    {
        private readonly DataContext _context;

        public PokemonRespository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();

        }
    }
}
