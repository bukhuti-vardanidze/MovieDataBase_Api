using MovieDataBase_Api.Db.Entities;

namespace MovieDataBase_Api.Models.Request
{
    public class DeleteMovieRequest
    {
        public int Id { get; set; }
        public MovieEntityStatus Status { get; set; }

    }
}
