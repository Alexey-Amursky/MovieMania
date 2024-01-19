using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmography
{
    public class MovieBuilder
    {
        private Movie movie;

        public MovieBuilder()
        {
            movie = new Movie();
        }

        public Movie Build()
        {
            return movie;
        }

        public MovieBuilder SetTitle(string? title)
        {
            movie.Title = title;
            return this;
        }

        public MovieBuilder SetDirector(string? director)
        {
            movie.Director = director;
            return this;
        }

        public MovieBuilder SetYear(int? year)
        {
            movie.Year = year;
            return this;
        }

        public MovieBuilder SetGenres(List<Genre>? genres)
        {
            movie.Genres = genres;
            return this;
        }

        public MovieBuilder SetRating(decimal? rating)
        {
            movie.Rating = rating;
            return this;
        }

        public MovieBuilder SetActors(List<Actor>? actors)
        {
            movie.SetActors(actors);
            return this;
        }

        public MovieBuilder SetAgeRating(AgeRating? ageRating)
        {
            movie.AgeRating = ageRating;
            return this;
        }

        public MovieBuilder SetDescription(string? description)
        {
            movie.Description = description;
            return this;
        }

        public MovieBuilder SetPath(string? path)
        {
            movie.Path = path;
            return this;
        }
    }
}
