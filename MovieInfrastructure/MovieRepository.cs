using System;
using System.Collections.Generic;
using System.Linq;
using MovieDomain;
using MovieDomainServices;

namespace MovieInfrastructure
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> _movies = new List<Movie>(new[]
        {
            new Movie()
            {
                Id = 1,
                Name = "The Beginning"
            },
            new Movie()
            {
                Id = 2,
                Name = "The life of a developer"
            }
        });

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }

        public Movie GetMovie(int id)
        {
            return _movies.SingleOrDefault(movie => movie.Id == id);
        }

        public void AddMovie(Movie newMovie)
        {
            if (newMovie == null) throw new ArgumentNullException(nameof(newMovie));

            var maxId = _movies.Max(movie => movie.Id);
            newMovie.Id = maxId++;

            _movies.Add(newMovie);
        }

        public void SaveMovie(Movie movie)
        {
            //NOP;
        }

        public void DeleteMovie(Movie movie)
        {
            _movies.Remove(movie);
        }
    }
}
