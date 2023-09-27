using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons( );
        
        /* Detail Endpoints */
        Pokemon  GetPokemon(int id); 

        Pokemon GetPokemon(string name);

        decimal GetPokemonRating(int pokeId);

        bool PokemonExist(int pokeId);

    }


}