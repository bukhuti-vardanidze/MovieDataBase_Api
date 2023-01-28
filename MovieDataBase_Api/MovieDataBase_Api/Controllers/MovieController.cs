using Microsoft.AspNetCore.Mvc;
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

        //[HttpPost("Add-Movie")]
        //public async Task<IActionResult> AddMovie([FromBody] MovieRequestRepository request)
        //{
        //    var entity = new MovieEntity();
        //    return Ok(entity);

        //}

        //[HttpGet("")]
        //public async Task<IActionResult> GetAllMovie()
        //{
        //    var movie = await _movieRequestRepository.GetAllMovieAsync();
        //    return Ok(movie);

        //}
    }
}
