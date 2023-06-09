﻿namespace GamesCorner.Shared.Dtos
{
    public class ReviewsDto
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public string UserEmail { get; set; }
        public string ProductId { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
