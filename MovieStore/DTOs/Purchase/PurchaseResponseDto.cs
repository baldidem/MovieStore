namespace MovieStore.DTOs.Purchase
{
    public class PurchaseResponseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
