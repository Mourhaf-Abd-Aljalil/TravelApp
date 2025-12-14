namespace ProjectTourism.ClassDTO
{
    public class ReviewsDTO
    {
        public int ReviewId { get; set; }

        public int TripId { get; set; }

        public int Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime ReviewDate { get; set; }

    }
}
