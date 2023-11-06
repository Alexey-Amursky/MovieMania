using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography.Interfaces
{
    public interface ISearchMovies
    {
        List<Movie> SearchMoviesByTitle(string title);
        List<Movie> SearchMoviesByDirector(string director);
        List<Movie> SearchMoviesByYear(int year);
        List<Movie> SearchMoviesByGenre(Genre genre);
    }
}
