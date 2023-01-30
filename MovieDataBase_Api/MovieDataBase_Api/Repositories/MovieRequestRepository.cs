using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using MovieDataBase_Api.Db;
using MovieDataBase_Api.Db.Entities;
using MovieDataBase_Api.Models.Request;

namespace MovieDataBase_Api.Repositories
{

    public interface IMovieRequestRepository
    {
       
        Task<List<MovieEntity>> GetAllMovieAsync();
        Task<MovieEntity?> GetSingleMovie(int id);
        Task<MovieEntity> AddMovieAsync([FromBody] AddMovieRequest addMovie);
        Task<List<MovieEntity>> UpdateMovieAsync([FromBody] UpdateMovieRequest updateMovie);


    }


    public class MovieRequestRepository : IMovieRequestRepository
    {
        private static List<MovieEntity> moviesEntity = new List<MovieEntity>
        {
                  new MovieEntity
                  {
                      Id= 1,
                      Name = "AVATAR-1",
                      ShortDescription = "blue people...",
                      ReleaseYear = DateTime.Now,
                      Director=" James Cameron",
                      Status = MovieEntityStatus.Active,
                      CreateYear = DateTime.Now

                  },
                   new MovieEntity
                  {
                      Id= 2,
                      Name = "AVATAR-2",
                      ShortDescription = "blue people...2",
                      ReleaseYear = DateTime.Now,
                      Director=" James Cameron",
                      Status = MovieEntityStatus.Active,
                      CreateYear = DateTime.Now

                  }
         };



        private readonly AppDbContext _db;

        public MovieRequestRepository(AppDbContext db)
        {
            _db = db;
        }


        public async Task<List<MovieEntity>> GetAllMovieAsync()
        {
            var getMovie = await _db.MovieDb.Where(g => g.Status == MovieEntityStatus.Active).ToListAsync();
            return getMovie;


        }


        public async Task<MovieEntity?> GetSingleMovie(int id)
        {
            var result = await _db.MovieDb.FindAsync(id);
            if (result is null)
            {
                return null;
            }
            return result;
        }

        public async Task<MovieEntity> AddMovieAsync([FromBody] AddMovieRequest addMovie)
        {
            var newMovie = new MovieEntity()
            {
                Id = addMovie.Id,
                Name = addMovie.Name,
                ShortDescription = addMovie.ShortDescription,
                ReleaseYear = addMovie.ReleaseYear,
                Director = addMovie.Director,
                Status = addMovie.Status,
                CreateYear = DateTime.UtcNow
            };

            var add =   await _db.MovieDb.AddAsync(newMovie);
            await _db.SaveChangesAsync();
            return add.Entity;
        }

        public async Task<List<MovieEntity>> UpdateMovieAsync([FromBody] UpdateMovieRequest updateMovie)
        {
            var findMovieforUpdate = await _db.MovieDb.FindAsync(updateMovie.Id);
            if(findMovieforUpdate is null)
            {
                return null;
            }
            findMovieforUpdate.Name = updateMovie.Name;
            findMovieforUpdate.ShortDescription = updateMovie.ShortDescription;
            findMovieforUpdate.ReleaseYear = updateMovie.ReleaseYear;
            findMovieforUpdate.Director = updateMovie.Director;
            findMovieforUpdate.Status = updateMovie.Status;
            findMovieforUpdate.CreateYear  = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return moviesEntity;
        
        }

        public async Task<List<MovieEntity>> DeleteMovie(int id)
        {
            //var statusChange = _db.MovieDb.Where(x => x.Status.Active);
            //var result = await _db.MovieDb.FindAsync(statusChange);

            var statusChange = _db.MovieDb.Where(x => x.Id == id && x.Status != 0);



            
            //if (hero is null)
            //{
            //    return null;
            //}

            //_db.Moviedb.Remove(hero);
            //await _db.SaveChangesAsync();
            //return superHeroes;
        }

    }
}
