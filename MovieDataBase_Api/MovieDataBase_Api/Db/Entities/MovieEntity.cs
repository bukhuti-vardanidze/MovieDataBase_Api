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
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public DateTime Year { get; set; }
        public string Director { get; set; }
        public MovieEntityStatus Status { get; set; }
        public DateTime CreateYear { get; set; }

    }
}
