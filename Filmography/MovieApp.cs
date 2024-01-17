using Filmography.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class MovieApp : ISearchMovies
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
        public int GetMovieCount() => movieLibrary.GetMovieCount();

        #region EditMovies
        public void AddMovie(Movie movie)
        {
            movieLibrary.AddMovie(movie);
        } // ok
        public void AddMovie(string title, string description, string director, int year, List<Genre>? genres, decimal rating, List<Actor> actors, AgeRating ageRating)
        {
            Movie movie = new Movie(title, description, director, year, genres, rating, actors, ageRating);
            movieLibrary.AddMovie(movie);
        } // ok
        public void DeleteMovie(int id)
        {
            if (id >= 0 && id < movieLibrary.GetMovieCount())
            {
                movieLibrary.DeleteMovie(id);
            }
        } // ok
        #endregion

        #region SearchMovies
        public List<Movie> SearchMoviesByTitle(string title) => movieLibrary.SearchMoviesByTitle(title);

        public List<Movie> SearchMoviesByDirector(string director) => movieLibrary.SearchMoviesByDirector(director);

        public List<Movie> SearchMoviesByYear(int year) => movieLibrary.SearchMoviesByYear(year);

        public List<Movie> SearchMoviesByGenre(Genre genre) => movieLibrary.SearchMoviesByGenre(genre);

        #endregion

        #region Getters
        public List<Movie> GetAllMovies() => movieLibrary.GetAllMovies(); // ok

        public Movie? GetMovieById(int movieId) => movieLibrary.GetMovieById(movieId);        

        public List<Genre> GetAllGenres()
        {
            List<Genre> allGenres = new List<Genre>();

            foreach (var movie in movieLibrary.GetAllMovies())
            {
                allGenres.AddRange(movie?.Genres);
            }

            List<Genre> uniqueGenres = allGenres.Distinct().ToList();

            return uniqueGenres;
        } // ok

        #endregion

        public void SaveDataToFile()
        {
            List<Movie> movies = movieLibrary.GetAllMovies();
            fileHandler.SaveMovies(filePath, movies);
        } // ok

        #region Actors
        public void AddActor(int movieIndex, Actor actor)
        {
            if (movieIndex >= 0 && movieIndex < movieLibrary.GetMovieCount())
            {
                movieLibrary.GetMovieById(movieIndex).AddActor(actor);
            }
        } // ok

        public void EditActor(int movieId, int actorId, Actor updatedActor)
        {
            if (movieId >= 0 && movieId < movieLibrary.GetMovieCount())
            {
                movieLibrary.GetMovieById(movieId).EditActor(actorId, updatedActor);
            }
        } // ok

        public void DeleteActor(int movieId, int actorId)
        {
            if (movieId >= 0 && movieId < movieLibrary.GetMovieCount())
            {
                movieLibrary.GetMovieById(movieId).DeleteActor(actorId);
            }
        } // ok
        #endregion
    }
}