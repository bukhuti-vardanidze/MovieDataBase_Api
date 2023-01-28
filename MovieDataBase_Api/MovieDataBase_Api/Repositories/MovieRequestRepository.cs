using LinqToDB;
using MovieDataBase_Api.Db.Entities;

namespace MovieDataBase_Api.Repositories
{

    public interface IMovieRequestRepository
    {
    }


    public class MovieRequestRepository : IMovieRequestRepository
    {
        private readonly DataContext _db;

        public MovieRequestRepository(DataContext db)
        {
            _db = db;
        }

        public async Task AddMovieAsync(int id, string name, string shortDescription, DateTime year, string director, string status, DateTime createYear)
        {
            var entity = new MovieEntity();
            entity.Id = id;
            entity.Name = name;
            entity.ShortDescription = shortDescription;
            entity.Year = year;
            entity.Director = director;
            entity.Status = MovieEntityStatus.Active;
            entity.CreateYear = createYear;

            _db.MovieDb.AddAssync(entity);


        }
    }
}
