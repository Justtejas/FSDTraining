namespace DTODemo.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Genre { get; set; }

        public record BookDTO(int BookId,string Title, string Author,decimal Price);
    }
}
