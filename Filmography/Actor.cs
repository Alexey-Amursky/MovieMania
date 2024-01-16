using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class Actor
    {
        private static int id = 0;
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Actor(string firstName, string lastName)
        {
            Id = ++id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int GetActorId() => Id;
    }
}
