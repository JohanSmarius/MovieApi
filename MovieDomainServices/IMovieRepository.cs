using System;
using System.Collections;
using System.Collections.Generic;
using MovieDomain;

namespace MovieDomainServices
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();

        Movie GetMovie(int id);

        void AddMovie(Movie newMovie);

        void SaveMovie(Movie movie);

        void DeleteMovie(Movie movie);
    }
}
