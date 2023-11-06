using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class MovieApp
    {
        private MovieLibrary movieLibrary;
        private FileHandler fileHandler;
        private string filePath = "movies.json";

        public MovieApp()
        {
            movieLibrary = new MovieLibrary();
            fileHandler = new FileHandler();

            List<Movie> movies = fileHandler.LoadMovies(filePath);
            foreach (var movie in movies)
            {
                movieLibrary.AddMovie(movie);
            }
        }
        public void AddMovie(string title, string director, int year, List<Genre> genres)
        {
            Movie movie = new Movie(title, director, year, genres);
            movieLibrary.AddMovie(movie);
        }
        public int GetMovieCount()
        {
            return movieLibrary.GetMovieCount();
        }
        public void EditMovie(int index, string newTitle, string newDirector, int newYear, List<Genre> genre)
        {
            if (index >= 0 && index < movieLibrary.GetMovieCount())
            {
                movieLibrary.EditMovie(index, new Movie {Title = newTitle,Director = newDirector,Year = newYear, Genres = genre });
            }
        }
        public void DeleteMovie(int index)
        {
            if (index >= 0 && index < movieLibrary.GetMovieCount())
            {
                movieLibrary.DeleteMovie(index);
            }
        }
        public List<Movie> SearchMoviesByTitle(string title)
        {
            return movieLibrary.SearchMoviesByTitle(title);
        }
        public List<Movie> SearchMoviesByDirector(string director)
        {
            return movieLibrary.SearchMoviesByDirector(director);
        }
        public List<Movie> SearchMoviesByYear(int year)
        {
            return movieLibrary.SearchMoviesByYear(year);
        }
        public List<Movie> SearchMoviesByGenre(Genre genre)
        {
            return movieLibrary.SearchMoviesByGenre(genre);
        }
        public List<Movie> GetAllMovies() => movieLibrary.GetAllMovies();

        public void SaveDataToFile()
        {
            List<Movie> movies = movieLibrary.GetAllMovies();
            fileHandler.SaveMovies(filePath, movies);
        }

        public List<Genre> GetAllGenres()
        {
            List<Genre> allGenres = new List<Genre>();

            foreach (var movie in movieLibrary.GetAllMovies())
            {
                allGenres.AddRange(movie.Genres);
            }

            List<Genre> uniqueGenres = allGenres.Distinct().ToList();

            return uniqueGenres;
        }
    }
}