namespace MovieDataBase_Api.Models.Request
{
    public class SearchMovieRequest
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public DateTime ReleaseYear { get; set; }
        public string Director { get; set; }
    }
}
