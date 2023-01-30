using MovieDataBase_Api.Db.Entities;
using System.ComponentModel.DataAnnotations;

namespace MovieDataBase_Api.Models.Request
{
    public class SearchMovieRequest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string ShortDescription { get; set; }


        [Required]
        public DateTime ReleaseYear { get; set; }

        [Required]

        public string Director { get; set; }
        public MovieEntityStatus Status { get; set; }
        public DateTime CreateYear { get; set; }
    }
}
