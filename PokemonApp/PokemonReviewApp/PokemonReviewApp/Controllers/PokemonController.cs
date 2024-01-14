
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;



namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRespository _pokemonRespository;
        private readonly DataContext context;

        public PokemonController(IPokemonRespository pokemonRespository, DataContext context)
        {
            _pokemonRespository = pokemonRespository;
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type  = typeof(IEnumerable<Pokemon>))]

        public IActionResult GetPokemons()
        {
            var pokemons = _pokemonRespository.GetPokemons();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);
        }
    }
}
