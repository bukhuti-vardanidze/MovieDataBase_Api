namespace MovieDataBase_Api.Models.Request
{
    public class SearchMovieRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public DateTime Year { get; set; }
        public string Director { get; set; }
    }
}
