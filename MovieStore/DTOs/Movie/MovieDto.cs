namespace MovieStore.DTOs.Movie
{
    public class MovieDto
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int DirectorId { get; set; }
        public List<int> ActorIds { get; set; }
        public int GenreId { get; set; }
    }
}
