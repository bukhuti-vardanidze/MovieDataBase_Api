using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MovieDataBase_Api.Db.Entities;
using MovieDataBase_Api.Models.Request;
using MovieDataBase_Api.Repositories;

namespace MovieDataBase_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRequestRepository _movieRequestRepository;

        public MovieController(IMovieRequestRepository movieRequestRepository)
        {
            _movieRequestRepository = movieRequestRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieEntity>>> GetAllMovies()
        {
            var result = await _movieRequestRepository.GetAllMovieAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MovieEntity>>> GetAllMovies(int id)
        {
            var result = await _movieRequestRepository.GetSingleMovie(id);
            if (result is null)
            {
                return NotFound("movie not found");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<MovieEntity> AddMovie([FromBody] AddMovieRequest addMovie)
        {
           var result =await _movieRequestRepository.AddMovieAsync(addMovie);

            //if (result is null)
            //{
            //    return NotFound("movie not found");
            //}
            //return Ok(result);

            return result;
           

        }



    }
 }
