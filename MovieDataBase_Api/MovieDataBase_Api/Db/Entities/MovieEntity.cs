using System.ComponentModel.DataAnnotations;


namespace MovieDataBase_Api.Db.Entities
{
    public enum MovieEntityStatus
    {
        Active,
        Deleted
    }
    public class MovieEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200,MinimumLength =1)]
        public string Name { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public string ShortDescription { get; set; }
        
        
        [Required]
        public DateTime ReleaseYear { get; set; }

        [Required]
        public string Director { get; set; }
        [Required]
        public MovieEntityStatus Status { get; set; }
        [Required]
        public DateTime CreateYear { get; set; }

    }
}
