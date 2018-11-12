using AspNetCore.MvcDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.MvcDemo.Services
{
    public class MovieMemoryService : IMovieService
    {
        private readonly List<Movie> _movies = new List<Movie>();
        public MovieMemoryService()
        {
            _movies.AddRange(new List<Movie>()
            {
                new Movie()
                {
                    Id = 1,
                    CinemaId = 1,
                    Name = "Superman",
                    ReleaseDate = new DateTime(2018, 10, 1),
                    Starring = "Nick"
                },
                new Movie()
                {
                    Id = 2,
                    CinemaId = 1,
                    Name = "Ghost",
                    ReleaseDate = new DateTime(2013, 10, 1),
                    Starring = "Michael Jackson"
                },
                new Movie()
                {
                    Id = 3,
                    CinemaId = 2,
                    Name = "Fight",
                    ReleaseDate = new DateTime(2008, 10, 1),
                    Starring = "Tommy"
                }
            });
        }
        public Task AddAsync(Movie movie)
        {
            movie.Id = _movies.Max(x => x.Id) + 1;
            _movies.Add(movie);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            return Task.FromResult(_movies.Where(r => r.CinemaId == cinemaId));
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            return Task.FromResult(_movies.SingleOrDefault(r => r.Id == id));
        }

        public Task DeleteAsync(int movieId)
        {
            var movie = _movies.Find(r => r.Id == movieId);
            _movies.Remove(movie);

            return Task.CompletedTask;
        }
    }
}
