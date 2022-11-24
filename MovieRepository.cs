using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndActors
{
    internal class MovieRepository
    {
        public List<Movie> Movies { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Role> Roles { get; set; }
        public List<User> Users { get; set; }
        public List<Rating> Ratings { get; set; }

        public MovieRepository()
        {
            var starWars4 = new Movie("Star Wars: A New Hope", 1977, "Science Fiction", 4.5f);
            var starWars5 = new Movie("Star Wars: The Empire Strikes Back", 1980, "Science Fiction", 5.25f);
            var starWars6 = new Movie("Star Wars: Return of the Jedi", 1983, "Science Fiction", 6f);
            var newMovie = new Movie("Star Wars: The Empire Strikes not back", 1980, "Science Fiction", 5.25f);

            Movies = new List<Movie>() { starWars4, starWars5, starWars6 };

            var markHamil = new Actor("Mark Hamil");
            var carrieFisher = new Actor("Carrie Fisher");
            var harrisonFord = new Actor("Harrison Ford");

            Actors = new List<Actor>() { markHamil, carrieFisher, harrisonFord };

            Roles = new List<Role>()
            {
                new Role("Princess Leia", carrieFisher, starWars4, 50_000),
                new Role("Princess Leia", carrieFisher, starWars5, 60_000),
                new Role("Princess Leia", carrieFisher, starWars6, 70_000),

                new Role("Luke Skywalker", markHamil, starWars4, 60_000),
                new Role("Luke Skywalker", markHamil, starWars5, 70_000),
                new Role("Luke Skywalker", markHamil, starWars6, 80_000),

                new Role("Han Solo", harrisonFord, starWars4, 55_000),
                new Role("Han Solo", harrisonFord, starWars5, 60_000),
                new Role("Han Solo", harrisonFord, starWars6, 65_000)
            };

            var alex = new User("Alex");
            var bob = new User("Bob");
            var charlie = new User("Charlie");
            var daria = new User("Daria");

            Users = new() { alex, bob, charlie, daria };

            Random rng = new();
            Ratings = new();

            foreach (User u in Users)
            {
                foreach (Movie m in Movies)
                {
                    Rating r = new(u, m, rng.Next(0, 11));
                    u.Ratings.Add(r);
                    m.Ratings.Add(r);
                    Ratings.Add(r);
                }
            }
        }

        // get the top movie by overall rating
        Movie GetMovieWithBestRating()
        {
            return Movies.MaxBy(m => m.Ratings.Average(r => r.RatingValue));
        }

        // get the top 3 movies by overall rating

        IEnumerable<Movie> GetTopNMovies(int numOfMovies)
        {
            return Movies
                .OrderByDescending(m => m.CalculateOverallRating())
                .Take(numOfMovies);
        }

        // get the movie with the 3rd highest overall rating
        Movie GetThirdPlace()
        {
            return Movies
                .OrderByDescending(m => m.CalculateOverallRating())
                .Skip(2)
                .First();
        }

        // get all the names from all the moves (just the names)
        IEnumerable<string> GetMovieTitles()
        {
            return Movies.Select(m => m.Title);
        }

        // check if we have any movies from "comedy" => return boolean
        bool DoWeHaveCategory(string category)
        {
            return Movies.Any(m => m.Category == category);
        }

        public IEnumerable<Movie> GetMovieInfo(string search)
        {
            return Movies.Where(m => m.Title.Contains(search));
        }

        public string? HaveOneInCategory(string category)
        {
            return Movies.SingleOrDefault(m => m.Category == category)?.Title;
        }

        public IEnumerable<Movie> FindNMostExpensive(int count)
        {
            return Movies
                .OrderByDescending(m => m.CostToRent)
                .Take(count);
        }

        // find all of the movies that cost $5 or more
        public IEnumerable<Movie> FindMoviesOverPrice(float price)
        {
            return Movies.Where(m => m.CostToRent >= price);
        }

        public Movie? FindMovieOver10()
        {
            return Movies.SingleOrDefault(m => m.CostToRent >= 10);
        }
    }
}
