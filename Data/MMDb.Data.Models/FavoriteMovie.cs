namespace MMDb.Data.Models
{
    public class FavoriteMovie
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
    }
}