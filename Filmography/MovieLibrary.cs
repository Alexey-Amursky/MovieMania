using Filmography.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class MovieLibrary : IMovieEditor, ISearchMovies
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
        public List<Movie> SearchMoviesByTitle(string title) => movies.Where(movie => movie.Title.ToLower().Contains(title)).ToList();
        public List<Movie> SearchMoviesByDirector(string director) => movies.Where(movie => movie.Director.ToLower().Contains(director)).ToList();
        public List<Movie> SearchMoviesByYear(int year) => movies.Where(movie => movie.Year == year).ToList();
        public List<Movie> SearchMoviesByGenre(Genre genre) => movies.Where(movie => movie.Genres.Contains(genre)).ToList();
        public List<Movie> GetAllMovies() => movies;
        public int GetMovieCount() => movies.Count;

    }
}
