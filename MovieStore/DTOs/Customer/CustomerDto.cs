namespace MovieStore.DTOs.Customer
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> FavoriteGenreIds { get; set; }
    }
}
