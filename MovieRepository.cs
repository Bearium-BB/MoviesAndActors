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
            var starWars4 = new Movie("Star Wars: A New Hope", 1977, "Science Fiction");
            var starWars5 = new Movie("Star Wars: The Empire Strikes Back", 1980, "Science Fiction");
            var starWars6 = new Movie("Star Wars: Return of the Jedi", 1983, "Science Fiction");

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

        public IEnumerable<Movie> GetMovieInfo(string search)
        {
            return Movies.Where(m => m.Title.Contains(search));
        }
    }
}
