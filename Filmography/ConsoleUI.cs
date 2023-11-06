using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class ConsoleUI
    {
        private MovieApp movieApp;

        public ConsoleUI()
        {
            movieApp = new MovieApp();
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Нажмите Enter для продолжения");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить фильм");
                Console.WriteLine("2. Показать все фильмы");
                Console.WriteLine("3. Сохранить данные в файл");
                Console.WriteLine("4. Редактировать фильм");
                Console.WriteLine("5. Удалить фильм");
                Console.WriteLine("6. Поиск по названию");
                Console.WriteLine("7. Поиск по режиссеру");
                Console.WriteLine("8. Поиск по году");
                Console.WriteLine("9. Поиск по жанру");
                Console.WriteLine("10. Показать все жанры");
                Console.WriteLine("0. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название фильма: ");
                        string title = Console.ReadLine();
                        Console.Write("Введите режиссера: ");
                        string director = Console.ReadLine();
                        Console.Write("Введите год выпуска: ");
                        if (int.TryParse(Console.ReadLine(), out int year))
                        {
                            Console.Write("Введите жанры (через запятую): ");
                            string genresInput = Console.ReadLine();
                            List<Genre> genres = genresInput.Split(',')
                                                              .Select(s => Enum.Parse<Genre>(s.Trim()))
                                                              .ToList();
                            movieApp.AddMovie(title, director, year, genres);
                            Console.WriteLine("Фильм успешно добавлен.");
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат года.");
                        }
                        break;

                    case "2":
                        DisplayAllMovies(movieApp.GetAllMovies());
                        break;

                    case "3":
                        movieApp.SaveDataToFile();
                        Console.WriteLine("Данные сохранены в файл.");
                        break;

                    case "4":
                        Console.WriteLine("Введите индекс фильма, который вы хотите отредактировать:");
                        if (int.TryParse(Console.ReadLine(), out int editIndex))
                        {
                            if (editIndex >= 0 && editIndex < movieApp.GetMovieCount())
                            {
                                Console.Write("Введите новое название фильма: ");
                                string newTitle = Console.ReadLine();
                                Console.Write("Введите нового режиссера: ");
                                string newDirector = Console.ReadLine();
                                Console.Write("Введите новый год выпуска: ");
                                if (int.TryParse(Console.ReadLine(), out int newYear))
                                {
                                    Console.Write("Введите жанры (через запятую): ");
                                    string newGenresInput = Console.ReadLine();
                                    List<Genre> newGenres = newGenresInput.Split(',')
                                                                        .Select(s => Enum.Parse<Genre>(s.Trim()))
                                                                        .ToList();
                                    movieApp.EditMovie(editIndex, newTitle, newDirector, newYear, newGenres);
                                    Console.WriteLine("Фильм успешно отредактирован.");
                                }
                                else
                                {
                                    Console.WriteLine("Неверный формат года.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Неверный индекс фильма.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат индекса.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Введите индекс фильма, который вы хотите удалить:");
                        if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                        {
                            if (deleteIndex >= 0 && deleteIndex < movieApp.GetMovieCount())
                            {
                                movieApp.DeleteMovie(deleteIndex);
                                Console.WriteLine("Фильм успешно удален.");
                            }
                            else
                            {
                                Console.WriteLine("Неверный индекс фильма.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат индекса.");
                        }
                        break;
                    case "6":
                        Console.Write("Введите часть названия фильма для поиска: ");
                        string searchTitle = Console.ReadLine().ToLower();
                        var searchResults1 = movieApp.SearchMoviesByTitle(searchTitle);
                        if (searchResults1.Any())
                        {
                            DisplayAllMovies(searchResults1);
                        }
                        else
                        {
                            Console.WriteLine("Фильмы не найдены.");
                        }
                        break;
                    case "7":
                        Console.Write("Введите часть имени режиссера для поиска: ");
                        string searchDirector = Console.ReadLine().ToLower();
                        var searchResults2 = movieApp.SearchMoviesByDirector(searchDirector);
                        if (searchResults2.Any())
                        {
                            DisplayAllMovies(searchResults2);
                        }
                        else
                        {
                            Console.WriteLine("Фильмы не найдены.");
                        }
                        break;

                    case "8":
                        Console.Write("Введите год выпуска фильма для поиска: ");
                        if (int.TryParse(Console.ReadLine(), out int searchYear))
                        {
                            var searchResults3 = movieApp.SearchMoviesByYear(searchYear);
                            if (searchResults3.Any())
                            {
                                DisplayAllMovies(searchResults3);
                            }
                            else
                            {
                                Console.WriteLine("Фильмы не найдены.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат года.");
                        }
                        break;
                    case "9":
                        Console.Write("Введите жанр для поиска: ");
                        string searchGenreInput = Console.ReadLine();
                        if (Enum.TryParse(searchGenreInput, out Genre searchGenre))
                        {
                            var searchResult4 = movieApp.SearchMoviesByGenre(searchGenre);
                            DisplayAllMovies(searchResult4);
                        }
                        else
                        {
                            Console.WriteLine("Неверный жанр.");
                        }
                        break;
                    case "10":
                        var allGenres = movieApp.GetAllGenres();
                        if (allGenres.Any())
                        {
                            Console.WriteLine("Все доступные жанры:");
                            foreach (Genre genre in allGenres)
                            {
                                Console.WriteLine(genre);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Жанры не найдены.");
                        }
                        break;

                    case "0":
                        Console.WriteLine("До свидания!");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неверная команда. Попробуйте еще раз.");
                        break;
                }
            }
        }

        public void DisplayAllMovies(List<Movie> movies)
        {
            if (movies.Any())
            {
                foreach (var movie in movies)
                {
                    Console.WriteLine($"Название: {movie.Title}");
                    Console.WriteLine($"Режиссер: {movie.Director}");
                    Console.WriteLine($"Год: {movie.Year}");
                    Console.WriteLine("Жанры: " + string.Join(", ", movie.Genres));
                    Console.WriteLine();
                }
            }
            else 
            { 
                Console.WriteLine("Фильмотека пуста."); 
            }
        }

    }
}
