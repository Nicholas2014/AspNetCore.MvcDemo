using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.MvcDemo.Models;

namespace AspNetCore.MvcDemo.Services
{
    public interface IMovieService
    {
        Task AddAsync(Movie movie);
        Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId);
    }
}