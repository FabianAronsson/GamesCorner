using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCorner.Shared.DTOs
{
    public class TempEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public TempEvent( string name, string description, string location, DateTime date, string imageUrl, double price)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Location = location;
            Date = date;
            ImageUrl = imageUrl;
            Price = price;
        }
    }
}
