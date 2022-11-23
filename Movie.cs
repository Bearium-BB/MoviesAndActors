using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndActors
{
    internal class Movie
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Category { get; set; }
        public List<Role> Roles { get; set; }
        public List<Rating> Ratings { get; set; }
        public float CostToRent { get; set; }


        public Movie(string title, int year, string category, float cost)
        {
            Title = title;
            ReleaseYear = year;
            Category = category;
            Roles = new List<Role>();
            Ratings = new List<Rating>();
            CostToRent = cost;
        }

        public float CalculateOverallRating()
        {
            return (float)Ratings.Average(r => r.RatingValue);
        }
    }
}
