namespace MovieStore.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<Purchase> Purchases { get; set; }
        public List<CustomerGenre> FavoriteGenres { get; set; }
    }
}
