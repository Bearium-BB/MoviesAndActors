using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndActors
{
    internal class User
    {
        public string Name { get; set; }
        public List<Rating> Ratings { get; set; }

        public User(string name)
        {
            Name = name;
            Ratings = new List<Rating>();
        }
    }
}
