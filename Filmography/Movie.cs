using Filmography.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class Movie
    {
        private static int id = 0;
        public int Id { get; }
        public string? Title { get; set; }
        public decimal? Rating { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
        public List<Genre>? Genres { get; set; }
        public AgeRating? AgeRating { get; set; }
        public List<Actor> Actors { get; private set; }
        public string? Director { get; set; }
        public string? Path { get; set; }

        public Movie() { }
        public Movie(string? title, string? description, string? director, int? year, List<Genre>? genres, decimal? rating, List<Actor>? actors, AgeRating? ageRating)
        {
            Id = ++id;
            Title = title;
            Description = description;
            Director = director;
            Year = year;
            Genres = genres ?? new List<Genre>();
            Rating = rating;
            Actors = actors ?? new List<Actor>();
            AgeRating = ageRating;
        }

        public void SetActors(List<Actor> actors)
        {
            Actors = actors;
        }
        public void AddActor(Actor actor)
        {
                Actors?.Add(actor);
        }

        public void EditActor(int actorId, Actor updatedActor)
        {
            if (actorId >= 0 && actorId < Actors.Count)
            {
                updatedActor = Actors.FirstOrDefault<Actor>(a => a.Id == actorId);
            }
        }

        public void DeleteActor(int actorId)
        {
            if (actorId >= 0 && actorId < Actors.Count)
            {
                Actors.Remove(Actors.FirstOrDefault<Actor>(a => a.Id == actorId));
            }
        }
    }
}
// можно добавить рейтинг / описание фильма / возрастной рейтинг / актёрский состав / пользователь(история просмотров) / 