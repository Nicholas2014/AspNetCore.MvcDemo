using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore.MvcDemo.Models;

namespace AspNetCore.MvcDemo.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);
        //Task<Sales> GetSalesAsync();
        Task AddAsync(Cinema cinema);
    }
}