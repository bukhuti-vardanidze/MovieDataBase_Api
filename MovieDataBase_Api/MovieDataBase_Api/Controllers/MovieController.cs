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

        [HttpGet("getAllmovie")]
        public async Task<IActionResult> GetAllMovies()
        {
           var result =  await _movieRequestRepository.GetAllMovieAsync();
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("getSinglemovie")]
        public async Task<IActionResult> GetAllMovies(int id)
        {
            var result = await _movieRequestRepository.GetSingleMovie(id);
            if (result is null)
            {
                return NotFound("movie not found");
            }
            return Ok(result);
        }



        [HttpPost("addMovie")]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieRequest addMovie)
        {
            var result = await _movieRequestRepository.AddMovieAsync(addMovie);

            
            return Ok(result);

        }

        [HttpPost("Update")]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieRequest updateMovies,int id)
        {
            var result = _movieRequestRepository.UpdateMovieAsync(updateMovies,id);

            return Ok(result);
        }

        [HttpPost("Update-V2")]
        public async Task<IActionResult> UpdateMovieV2( int id, MovieEntity entity)
        {
            var result = _movieRequestRepository.UpdateMovie(id, entity);

            return Ok(result);
        }





        [HttpDelete]
        public async Task<IActionResult> DeleteMovie([FromBody] DeleteMovieRequest deleteMovie)
        {
            var result = await _movieRequestRepository.DeleteMoviesAsync(deleteMovie);

            if (result is null)
            {
                return NotFound("movie not found");
            }

            return Ok(result);
        }

        [HttpGet("searchBy")]

        public async Task<IActionResult> SearchMovieByName([FromBody] SearchMovieRequest request)
        {
            var result = await _movieRequestRepository.SearchMovieAsync(request);
            return Ok(result);
        }


        


        //public async Task<List<MovieEntity>> SearchMovie([FromBody] SearchMovieRequest searchMovie)
        //{
        //    var result = await _movieRequestRepository.SearchMoviesAsync(searchMovie);
        //    return result;

        //}

    }

}