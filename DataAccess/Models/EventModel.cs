namespace DataAccess.Models
{
    public  class EventModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
    }
}
