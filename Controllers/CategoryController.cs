using Microsoft.AspNetCore.Components;
using PokemonReviewApp.Interaces;
using PokemonReviewApp.Models;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using AutoMapper;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories( )
        {
            var categoeis = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories( ));
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(categoeis);
        }
        
        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if(!_categoryRepository.CategoryExits(categoryId))
            {
                return NotFound( );
            }
            var category = _mapper.Map<CategoryDto>(_categoryRepository.GetCategory(categoryId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
        
            return Ok(category);
        }
    
        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId(int categoryId)
        {

            var pokemons = _mapper.Map<List<PokemonDto>>(
                _categoryRepository.GetPokemonByCategory(categoryId));
        
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
        
            return Ok(pokemons);
        }    

    }


}