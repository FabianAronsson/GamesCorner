using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCorner.Shared.Dtos
{
    public class ReviewsDto : IEnumerable
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string UserEmail { get; set; }
        public string ProductId { get; set; }
        public double Rating { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
