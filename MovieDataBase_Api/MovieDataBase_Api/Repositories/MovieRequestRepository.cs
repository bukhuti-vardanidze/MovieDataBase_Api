using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using MovieDataBase_Api.Db;
using MovieDataBase_Api.Db.Entities;
using MovieDataBase_Api.Models.Request;
using System.IO;

namespace MovieDataBase_Api.Repositories
{
    public interface IMovieRequestRepository
    {
        Task<List<MovieEntity>> GetAllMovieAsync();
        Task<MovieEntity?> GetSingleMovie(int id);
        Task<int> AddMovieAsync([FromBody] AddMovieRequest addMovie);
        Task<MovieEntity> UpdateMovieAsync([FromBody] UpdateMovieRequest updateMovie,int id);
        Task UpdateMovie(int id, MovieEntity updateMovie);
        Task<MovieEntity> DeleteMoviesAsync([FromBody] DeleteMovieRequest deleteMovie);
        Task<List<MovieEntity>> SearchMovieAsync([FromBody] SearchMovieRequest search);
        //   Task<List<MovieEntity>> SearchMoviesAsync([FromBody] SearchMovieRequest searchMovie);
    }


    public class MovieRequestRepository : IMovieRequestRepository
    {
        

        private readonly AppDbContext _db;

        public MovieRequestRepository(AppDbContext db)
        {
            _db = db;
        }


        public async Task<List<MovieEntity>> GetAllMovieAsync()
        {
            var getMovie = await _db.MovieDb.ToListAsync();
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

      

        public async Task<int> AddMovieAsync([FromBody] AddMovieRequest addMovie)
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

            _db.MovieDb.Add(newMovie);
            await _db.SaveChangesAsync();

            //
            return newMovie.Id;


        }

        public async Task<MovieEntity> UpdateMovieAsync([FromBody] UpdateMovieRequest updateMovie, int id)
        {
          var result = await _db.MovieDb.FindAsync(id);

           if(result is  null)
            {
                return null;
            }

            result.Id = id;
            result.Name = updateMovie.Name;
            result.ShortDescription = updateMovie.ShortDescription;
            result.ReleaseYear = updateMovie.ReleaseYear;
            result.Director = updateMovie.Director;
            

            //var findMovieforUpdate = new MovieEntity()
            //{
            //    Id = updateMovie.Id,
            //    Name = updateMovie.Name,
            //    ShortDescription = updateMovie.ShortDescription,
            //    ReleaseYear = updateMovie.ReleaseYear,
            //    Director = updateMovie.Director,
            //    Status = updateMovie.Status,
            //    CreateYear = DateTime.UtcNow

            //};


            _db.MovieDb.Update(result);
            await _db.SaveChangesAsync();
            return result;


        }


        public async Task UpdateMovie(int id,MovieEntity updateMovie)
        {
            var result = await _db.MovieDb.FindAsync(id);

            if (result is null)
            {
                return;
            }
            
            result.Name = updateMovie.Name;
            result.ShortDescription = updateMovie.ShortDescription;
            result.ReleaseYear = updateMovie.ReleaseYear;
            result.Director = updateMovie.Director;

            _db.MovieDb.Update(result);
            await _db.SaveChangesAsync();
            

        }



        public async Task<MovieEntity> DeleteMoviesAsync([FromBody] DeleteMovieRequest deleteMovie)
        {
            var result = await _db.MovieDb.FindAsync(deleteMovie.Id);

            if (result.Status == MovieEntityStatus.Active)
            {
                result.Status = MovieEntityStatus.Deleted;
            } else
            {
                result.Status = MovieEntityStatus.Active;
            }

            _db.MovieDb.Update(result);
            await _db.SaveChangesAsync();
            return result;
        }




        public async  Task<List<MovieEntity>> SearchMovieAsync([FromBody] SearchMovieRequest search)
        {
            //.Where(t => t.Id == id)
            var serachResult = _db.MovieDb 
                .Where(t => t.Name.Contains(search.Name))
                .OrderBy(t => t.CreateYear)
                .ToList();
            
            return serachResult;
        }





        //public async Task<List<MovieEntity>> SearchMoviesAsync([FromBody] SearchMovieRequest searchMovie)
        //{

        //    var result = await _db.MovieDb.Where(s => s.Name.Contains(searchMovie.Name) || 
        //    s.ShortDescription.Contains(searchMovie.ShortDescription) ||
        //    s.Director.Contains(searchMovie.Director)).ToListAsync();

        //    return result;
        //}
    }
}