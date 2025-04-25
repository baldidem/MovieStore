namespace MovieStore.DTOs.Movie
{
    public class MovieResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; }
        public string Genre { get; set; }
    }
}
