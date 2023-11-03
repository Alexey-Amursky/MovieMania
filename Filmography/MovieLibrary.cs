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
        public void EditMovie(int index, Movie newMovie)
        {
            if (index >= 0 && index < movies.Count)
            {
                movies[index] = newMovie;
            }
        }
        public void DeleteMovie(int index)
        {
            if (index >= 0 && index < movies.Count)
            {
                movies.RemoveAt(index);
            }
        }
        public List<Movie> SearchMoviesByTitle(string title)
        {
            return movies.Where(movie => movie.Title.Contains(title)).ToList();
        }
        public List<Movie> SearchMoviesByDirector(string director)
        {
            return movies.Where(movie => movie.Director.Contains(director)).ToList();
        }
        public List<Movie> SearchMoviesByYear(int year)
        {
            return movies.Where(movie => movie.Year == year).ToList();
        }
        public List<Movie> GetAllMovies()
        {
            return movies;
        }
        public int GetMovieCount()
        {
            return movies.Count;
        }
    }
}
