using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class Movie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Genre> Genres { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public decimal Rating { get; set; }
        public List<Actor> Actors { get; set; }
        public AgeRating AgeRating { get; set; }

        public Movie() { }
        public Movie(string title, string director, int year, List<Genre>? genres, decimal rating, List<Actor> actors, AgeRating ageRating)
        {
            Title = title;
            Director = director;
            Year = year;
            Genres = genres ?? new List<Genre>();
            Rating = rating;
            Actors = actors;
            AgeRating = ageRating;
        }
    }
}
// можно добавить рейтинг / описание фильма / возрастной рейтинг / актёрский состав / пользователь(история просмотров) / 