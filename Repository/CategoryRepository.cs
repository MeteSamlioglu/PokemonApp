using AutoMapper;
using PokemonReviewapp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExits(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }
        public ICollection<Category> GetCategories( )
        {
            return _context.Categories.ToList( );
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where( e => e.Id == id).FirstOrDefault( );
        }
        /*
            Nested Entity: Its called navigation property as you can see below
            public ICollection<Review> Reviews { get; set; }
            public ICollection<PokemonOwner> PokemonOwners { get; set; }
            public ICollection<PokemonCategory> PokemonCategories { get; set; }
            If you have navigation property its not gonna be loaded automatically for you
            You have to explicitly tell to the EntityFramework to load it for you by using
            Include or Select

            In EntityFramework if you have a nested entity
        */
        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategory.Where(e => e.CategoryId == categoryId).Select(categoryId => categoryId.Pokemon).ToList( );

        }
    }



}