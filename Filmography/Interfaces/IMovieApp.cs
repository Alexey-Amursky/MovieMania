using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography.Interfaces
{
    public interface IMovieApp
    {
        void AddMovie(string title, string director, int year, List<Genre> genres);
        void DisplayAllMovies();
    }
}
