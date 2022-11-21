using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesAndActors
{
    internal class Actor
    {
        public string Name { get; set; }
        public List<Role> Roles { get; set; }

        public Actor(string name)
        {
            Name = name;
            Roles = new List<Role>();
        }
    }
}
