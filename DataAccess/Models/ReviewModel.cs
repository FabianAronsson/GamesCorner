namespace DataAccess.Models
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string UserEmail { get; set; }
        public Guid ProductId { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
