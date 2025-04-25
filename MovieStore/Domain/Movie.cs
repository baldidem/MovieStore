using System.IO;

namespace MovieStore.Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public List<MovieActor> MovieActors { get; set; }
        public Genre Genre { get; set; }
    }
}
