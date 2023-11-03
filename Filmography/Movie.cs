using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        public List<string> Genres { get; set; }
        public Movie() { }
        public Movie(string title, string director, int year, List<string> genres)
        {
            Title = title;
            Director = director;
            Year = year;
            Genres = genres;
        }
    }
}
