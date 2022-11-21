namespace MoviesAndActors
{
    internal class Rating
    {
        public User User { get; }
        public Movie Movie { get; }
        public int RatingValue { get; }

        public Rating(User user, Movie movie, int rating)
        {
            User = user;
            Movie = movie;
            RatingValue = rating;
        }
    }
}
