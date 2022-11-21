using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndActors
{
    internal class Role
    {
        public string Character { get; set; }
        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
        public double Salary { get; set; }

        public Role(string character, Actor actor, Movie movie, double salary)
        {
            Character = character;
            Actor = actor;
            Movie = movie;
            Salary = salary;
        }
    }
}
