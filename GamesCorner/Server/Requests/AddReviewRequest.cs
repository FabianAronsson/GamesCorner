using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class AddReviewRequest : IHttpRequest
    {
        public ReviewModel Review { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
