using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ReviewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string UserEmail { get; set; }
        public Guid ProductId { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
