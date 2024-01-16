using System;
using System.Collections.Generic;
using System.IO;
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
                Menu();

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateMovie(movieApp);
                        break; // ok

                    case "2":
                        DisplayAllMovies(movieApp.GetAllMovies());
                        break; // ok

                    case "3":
                        movieApp.SaveDataToFile();
                        Console.WriteLine("Данные сохранены в файл.");
                        break; // ok

                    case "4":
                        EditMovieById(movieApp);
                        break; // ok

                    case "5":
                        DeleteFilmById(movieApp);
                        break; // ok

                    case "6":
                        SearchMovieByTitle(movieApp);
                        break; // ok

                    case "7":
                        SearchMovieByDirector(movieApp);
                        break; // ok

                    case "8":
                        SearchMovieByYear(movieApp);
                        break; // ok

                    case "9":
                        SearchMovieByGenre(movieApp);
                        break; // ok

                    case "10":
                        ShowAllGenres(movieApp); // ok
                        break;

                    case "0":
                        Console.WriteLine("До свидания!");
                        exit = true;
                        break;

                    case "start":
                        RunMovieById();
                        break;

                    default:
                        Console.WriteLine("Неверная команда. Попробуйте еще раз.");
                        break;
                }
            }
        }

        private void Menu()
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
            Console.WriteLine("Введите 'start' для запуска фильма по id");
            Console.WriteLine("0. Выйти");
        }

        private void CreateMovie(MovieApp movieApp)
        {
            MovieBuilder movieBuilder = new MovieBuilder();

            Console.Write("Введите название фильма: ");
            string title = Console.ReadLine();
            Console.Write("Введите режиссера: ");
            string director = Console.ReadLine();
            Console.Write("Введите год выпуска: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                Console.Write("Введите жанры (через запятую): ");// Необходимо вводить точное название жанров как в Genre (нужно этот момент доработать)
                string genresInput = Console.ReadLine();
                List<Genre> genres = genresInput.Split(',')
                                              .Select(s => Enum.Parse<Genre>(s.Trim()))
                                              .ToList();

                Console.Write("Введите рейтинг: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal rating))
                {
                    Console.Write("Введите актеров (через запятую): ");
                    string actorsInput = Console.ReadLine();
                    List<Actor> actors = actorsInput.Split(',')
                                                  .Select(actor => actor.Split(' '))
                                                  .Select(name => new Actor(name[0], name[1]))
                                                  .ToList();

                    Console.Write("Введите возрастной рейтинг: "); // Необходимо вводить точное название возрастных рейтингов как в AgeRating (нужно этот момент доработать)
                    if (Enum.TryParse(Console.ReadLine(), out AgeRating ageRating))
                    {
                        Console.Write("Введите описание: ");
                        string description = Console.ReadLine();

                        Console.Write("Введите путь к файлу: ");
                        string path = Console.ReadLine();

                        movieBuilder
                            .SetTitle(title)
                            .SetDirector(director)
                            .SetYear(year)
                            .SetGenres(genres)
                            .SetRating(rating)
                            .SetActors(actors)
                            .SetAgeRating(ageRating)
                            .SetDescription(description)
                            .SetPath(path);

                        if (movieBuilder != null)
                        {
                            Movie newMovie = movieBuilder.Build();
                            movieApp.AddMovie(newMovie);
                            Console.WriteLine("Фильм успешно добавлен.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат возрастного рейтинга.");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат рейтинга.");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат года.");
            }
        } // ok

        private void DisplayAllMovies(List<Movie> movies)
        {
            if (movies.Any())
            {
                foreach (var movie in movies)
                {
                    Console.WriteLine($"Id:  {movie.Id}");
                    Console.WriteLine($"Название: {movie.Title}");
                    Console.WriteLine($"Рейтинг: {movie.Rating}");
                    Console.WriteLine($"Год: {movie.Year}");
                    Console.WriteLine($"Описание: {movie.Description}");
                    Console.WriteLine("Жанры: " + string.Join(", ", movie.Genres));
                    Console.WriteLine("Возрастной рейтинг: " + string.Join(", ", movie.AgeRating));
                    ShowActors(movie.Actors);
                    Console.WriteLine($"Режиссер: {movie.Director}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Фильмотека пуста.");
            }
        } // ok

        private void ShowActors(List<Actor> actors)
        {
            Console.Write("Актёры: [");
            foreach (var actor in actors)
            {
                Console.WriteLine($"|{actor.FirstName} {actor.LastName}|");
            }
            Console.WriteLine("]");
        } // ok

        private void EditMovieById(MovieApp movieApp)
        {
            Console.WriteLine("Введите ID фильма, который вы хотите отредактировать:");
            if (int.TryParse(Console.ReadLine(), out int editId))
            {
                if (editId >= 0 && editId < movieApp.GetMovieCount())
                {
                    MenuForEditMovie();
                    bool exitEditing = false;
                    while (!exitEditing)
                    {
                        MovieBuilder movieBuilder = new MovieBuilder();

                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                Console.Write("Введите новое название фильма: ");
                                string newTitle = Console.ReadLine();
                                movieBuilder.SetTitle(newTitle);
                                CheckAndAdd(movieBuilder);
                                break;

                            case "2":
                                Console.Write("Введите рейтинг: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal rating))
                                {
                                    movieBuilder.SetRating(rating);
                                    CheckAndAdd(movieBuilder);
                                }
                                else
                                {
                                    Console.WriteLine("Неверный формат рейтинга.");
                                }
                                break;

                            case "3":
                                Console.Write("Введите новый год выпуска: ");
                                if (int.TryParse(Console.ReadLine(), out int newYear))
                                {
                                    movieBuilder.SetYear(newYear);
                                    CheckAndAdd(movieBuilder);
                                }
                                else
                                {
                                    Console.WriteLine("Неверный формат года.");
                                }                               
                                break;

                            case "4":
                                Console.Write("Введите описание: ");
                                string description = Console.ReadLine();
                                movieBuilder.SetDescription(description);
                                CheckAndAdd(movieBuilder);
                                break;

                            case "5":
                                Console.Write("Введите жанры (через запятую): ");
                                string newGenresInput = Console.ReadLine();
                                List<Genre> newGenres = newGenresInput.Split(',')
                                                                    .Select(s => Enum.Parse<Genre>(s.Trim()))
                                                                    .ToList();
                                movieBuilder.SetGenres(newGenres);
                                CheckAndAdd(movieBuilder);
                                break;

                            case "6":
                                Console.Write("Введите возрастной рейтинг: ");
                                if (Enum.TryParse(Console.ReadLine(), out AgeRating ageRating))
                                {
                                    movieBuilder.SetAgeRating(ageRating);
                                    CheckAndAdd(movieBuilder);
                                }
                                else
                                {
                                    Console.WriteLine("Неверный формат возрастного рейтинга.");
                                }                                
                                break;

                            case "7":
                                Console.Write("Введите актеров (через запятую): ");
                                string actorsInput = Console.ReadLine();
                                List<Actor> actors = actorsInput.Split(',')
                                                              .Select(actor => actor.Split(' '))
                                                              .Select(name => new Actor(name[0], name[1]))
                                                              .ToList();
                                movieBuilder.SetActors(actors);
                                CheckAndAdd(movieBuilder);
                                break;

                            case "8":
                                Console.Write("Введите нового режиссера: ");
                                string newDirector = Console.ReadLine();
                                movieBuilder.SetDirector(newDirector);
                                CheckAndAdd(movieBuilder);
                                break;

                            case "9":
                                Console.Write("Введите путь к файлу: ");
                                string path = Console.ReadLine();
                                movieBuilder.SetPath(path);
                                CheckAndAdd(movieBuilder);
                                break;

                            case "0":
                                exitEditing = true;
                                break;
                        }


                    }


                    /*Console.Write("Введите новое название фильма: ");
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
                        movieApp.EditMovie(editId, newTitle, newDirector, newYear, newGenres);
                        Console.WriteLine("Фильм успешно отредактирован.");
                    }
                    else
                    {
                        Console.WriteLine("Неверный формат года.");
                    }*/
                }
                else
                {
                    Console.WriteLine("Неверный ID фильма.");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ID.");
            }

            void CheckAndAdd(MovieBuilder movieBuilder)
            {
                if (movieBuilder != null)
                {
                    Movie newMovie = movieBuilder.Build();
                    movieApp.AddMovie(newMovie);
                    Console.WriteLine("Фильм успешно отредактирован.");
                }
            } // ок

            void MenuForEditMovie()
            {
                Console.WriteLine("Нажмите Enter для продолжения");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Что вы хотите отредактировать?\n");
                Console.WriteLine("1 - Название фильма");
                Console.WriteLine("2 - Рейтинг");
                Console.WriteLine("3 - Год");
                Console.WriteLine("4 - Описание");
                Console.WriteLine("5 - Жанры");
                Console.WriteLine("6 - Возрастной рейтинг");
                Console.WriteLine("7 - Актёров");
                Console.WriteLine("8 - Режисёра");
                Console.WriteLine("9 - Путь к файлу");
                Console.WriteLine("0 - Ничего! Вернуться в главное меню");
            } // ok

        } // ok

        
        private void DeleteFilmById(MovieApp movieApp)
        {
            Console.WriteLine("Введите ID фильма, который вы хотите удалить:");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                if (deleteId >= 0 && deleteId < movieApp.GetMovieCount())
                {
                    movieApp.DeleteMovie(deleteId);
                    Console.WriteLine("Фильм успешно удален.");
                }
                else
                {
                    Console.WriteLine("Неверный ID фильма.");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ID.");
            }
        } // ok

        private void SearchMovieByTitle(MovieApp movieApp)
        {
            Console.Write("Введите названия фильма или его часть для поиска: ");
            string searchFilm = Console.ReadLine().ToLower();
            var searchResults1 = movieApp.SearchMoviesByTitle(searchFilm);
            if (searchResults1.Any())
            {
                DisplayAllMovies(searchResults1);
            }
            else
            {
                Console.WriteLine("Фильмы не найдены.");
            }
        } // ok

        private void SearchMovieByDirector(MovieApp movieApp)
        {
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
        } // ok

        private void SearchMovieByYear(MovieApp movieApp)
        {
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
        } // ok

        private void SearchMovieByGenre(MovieApp movieApp)
        {
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
        } // ok

        private void ShowAllGenres(MovieApp movieApp)
        {
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
        } // ok

        private void RunMovieById()
        {
            Console.WriteLine("Введите ID фильма, который вы хотите запустить:");
            if (int.TryParse(Console.ReadLine(), out int runId))
            {
                if (runId >= 0 && runId < movieApp.GetMovieCount())
                {
                    Movie selectedMovie = movieApp.GetMovieById(runId);

                    Console.WriteLine($"Сейчас запущен: {selectedMovie.Title}");

                    Procedure.RunMovie(selectedMovie);
                }
                else
                {
                    Console.WriteLine("Неверный ID фильма.");
                }
            }
            else
            {
                Console.WriteLine("Неверный формат ID.");
            }
        } // ok
    }
}
