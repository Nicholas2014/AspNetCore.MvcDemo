using AspNetCore.MvcDemo.Models;
using AspNetCore.MvcDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AspNetCore.MvcDemo.Settings;
using Microsoft.Extensions.Options;

namespace AspNetCore.MvcDemo.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IOptions<ConnectionOptions> _options;

        public CinemaController(ICinemaService cinemaService,IOptions<ConnectionOptions> options)
        {
            _cinemaService = cinemaService;
            _options = options;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "电影院";
            var model = await _cinemaService.GetAllAsync();

            return View(model);
        }

        public IActionResult Add()
        {
            ViewBag.Title = "添加电影院";
            return View(new Cinema());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.AddAsync(cinema);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            if (cinema == null)
            {
                return NotFound();
            }
            ViewBag.Title = $"编辑电影院 - {cinema.Name}";

            return View(cinema);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cinema model)
        {
            var cinema = await _cinemaService.GetByIdAsync(model.Id);
            if (cinema == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                cinema.Name = model.Name;
                cinema.Location = model.Location;
                cinema.Capacity = model.Capacity;
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromQuery]int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            if (cinema == null)
            {
                return NotFound();
            }

            await _cinemaService.DeleteAsync(cinemaId);

            return RedirectToAction("Index");
        }
    }
}
