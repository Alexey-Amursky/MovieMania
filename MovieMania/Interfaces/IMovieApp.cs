using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography.Interfaces
{
    public interface IMovieApp
    {
        void AddMovie(string title, string description, string director, int year, List<Genre>? genres, decimal rating, List<Actor> actors, AgeRating ageRating);
        void EditMovie(int index, string newTitle, string newDirector, int newYear, List<Genre> genre);
        void DeleteMovie(int index);
        void DisplayAllMovies();
    }
}
