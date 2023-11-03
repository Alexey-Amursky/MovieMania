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

        public void AddMovie(string title, string director, int year)
        {
            Movie movie = new Movie { Title = title, Director = director, Year = year };
            movieLibrary.AddMovie(movie);
            Console.WriteLine("Фильм успешно добавлен.");
        }

        public void DisplayAllMovies()
        {
            List<Movie> movies = movieLibrary.GetAllMovies();

            if (movies.Any())
            {
                Console.WriteLine("Список фильмов:");
                foreach (var movie in movies)
                {
                    Console.WriteLine($"Название: {movie.Title}, Режиссер: {movie.Director}, Год: {movie.Year}");
                }
            }
            else
            {
                Console.WriteLine("Фильмотека пуста.");
            }
        }

        public void SaveDataToFile()
        {
            List<Movie> movies = movieLibrary.GetAllMovies();
            fileHandler.SaveMovies(filePath, movies);
            Console.WriteLine("Данные сохранены в файл.");
        }
    }
}
