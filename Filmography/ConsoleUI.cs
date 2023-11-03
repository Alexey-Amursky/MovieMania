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
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить фильм");
                Console.WriteLine("2. Показать все фильмы");
                Console.WriteLine("3. Сохранить данные в файл");
                Console.WriteLine("4. Выйти");

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
                            movieApp.AddMovie(title, director, year);
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат года.");
                        }
                        break;

                    case "2":
                        movieApp.DisplayAllMovies();
                        break;

                    case "3":
                        movieApp.SaveDataToFile();
                        break;

                    case "4":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}
