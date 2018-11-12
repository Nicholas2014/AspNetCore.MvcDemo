using AspNetCore.MvcDemo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.MvcDemo.Services
{
    public class CinemaMemoryService : ICinemaService
    {
        private readonly List<Cinema> _cinemas = new List<Cinema>();

        public CinemaMemoryService()
        {
            _cinemas.Add(new Cinema()
            {
                Id = 1,
                Name = "City Cinema",
                Location = "Road ABC, NO.123",
                Capacity = 1000
            });
            _cinemas.Add(new Cinema()
            {
                Id = 2,
                Name = "Fly Cinema",
                Location = "Road Hello, NO.123",
                Capacity = 500
            });
        }
        public Task<IEnumerable<Cinema>> GetAllAsync()
        {
            return Task.FromResult(_cinemas.AsEnumerable());
        }

        public Task<Cinema> GetByIdAsync(int id)
        {
            return Task.FromResult(_cinemas.FirstOrDefault(x => x.Id == id));
        }



        public Task AddAsync(Cinema cinema)
        {
            cinema.Id = _cinemas.Max(x => x.Id) + 1;
            _cinemas.Add(cinema);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int cinemaId)
        {
            var cinema = _cinemas.Find(r => r.Id == cinemaId);
            _cinemas.Remove(cinema);

            return Task.CompletedTask;
        }
    }
}
