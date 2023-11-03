using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class MovieLibrary
    {
        private List<Movie> movies = new List<Movie>();

        public void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
        public void EditMovie(int index, Movie updatedMovie)
        {
            if (index >= 0 && index < movies.Count)
            {
                movies[index] = updatedMovie;
            }
        }
        public void DeleteMovie(int index)
        {
            if (index >= 0 && index < movies.Count)
            {
                movies.RemoveAt(index);
            }
        }
        public List<Movie> GetAllMovies()
        {
            return movies;
        }
    }
}
