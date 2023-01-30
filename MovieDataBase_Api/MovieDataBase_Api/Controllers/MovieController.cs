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
            return await _movieRequestRepository.GetAllMovieAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieEntity>> GetAllMovies(int id)
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
            var result = await _movieRequestRepository.AddMovieAsync(addMovie);

            //if (result is null)
            //{
            //    return NotFound("movie not found");
            //}
            //return Ok(result);

            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<MovieEntity>>> UpdateHero([FromBody] UpdateMovieRequest updateMovies)
        {
            var result = await _movieRequestRepository.UpdateMovieAsync(updateMovies);
            if (result is null)
            {
                return NotFound("movie not found");
            }

            return Ok(result);
        }


        [HttpDelete]
        public async Task<ActionResult<List<MovieEntity>>> DeleteMovie([FromBody] DeleteMovieRequest deleteMovie)
        {
            var result = await _movieRequestRepository.DeleteMoviesAsync(deleteMovie);
            
            if (result is null)
            {
                return NotFound("movie not found");
            }

            return Ok(result);
        }

        //[HttpPost]
        //public async Task<List<MovieEntity>> SearchMovie([FromBody] SearchMovieRequest searchMovie)
        //{
        //    var result = await _movieRequestRepository.SearchMoviesAsync(searchMovie);
        //    return result;

        //}

    }

 }
