using LinqToDB;
using MovieDataBase_Api.Db;
using MovieDataBase_Api.Db.Entities;
using MovieDataBase_Api.Models.Request;

namespace MovieDataBase_Api.Repositories
{

    public interface IMovieRequestRepository
    {
        Task AddMovieAsync(int id, string name, string shortDescription, DateTime year, string director, string status, DateTime createYear);
        Task<List<AddMovieRequest>> GetAllMovieAsync();
    }


    public class MovieRequestRepository : IMovieRequestRepository
    {
        private readonly AppDbContext _db;

        public MovieRequestRepository(AppDbContext db)
        {
            _db = db;
        }


        //public async Task<List<AddMovieRequest>> GetAllMovieAsync()
        //{
        //    var records =await _db.MovieDb.Select(x => new AddMovieRequest()
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        ShortDescription = x.ShortDescription,
        //        Year = x.Year,
        //        Director = x.Director
        //    }).ToListAsync();

        //    return records;
        //}


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

            await _db.MovieDb.AddAsync(entity);
            

        }
    }
}
