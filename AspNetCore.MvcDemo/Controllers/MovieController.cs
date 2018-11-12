using AspNetCore.MvcDemo.Models;
using AspNetCore.MvcDemo.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNetCore.MvcDemo.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICinemaService _cinemaService;

        public MovieController(IMovieService movieService, ICinemaService cinemaService)
        {
            _movieService = movieService;
            _cinemaService = cinemaService;
        }

        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await _cinemaService.GetByIdAsync(cinemaId);
            ViewBag.Title = $"{cinema.Name} 上映的电影有：";
            ViewBag.CinemaId = cinemaId;

            return View(await _movieService.GetByCinemaAsync(cinemaId));
        }

        public IActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";

            return View(new Movie()
            {
                CinemaId = cinemaId
            });
        }
        [HttpPost]
        public async Task<IActionResult> Add(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieService.AddAsync(movie);
            }

            return RedirectToAction("Index", new { cinemaId = movie.CinemaId });
        }
        public async Task<IActionResult> Edit(int movieId)
        {
            var movie = await _movieService.GetByIdAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }
            ViewBag.Title = $"编辑电影 - {movie.Name}";

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Movie model)
        {
            var movie = await _movieService.GetByIdAsync(model.Id);
            if (movie == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                movie.Name = model.Name;
                movie.CinemaId = model.CinemaId;
                movie.ReleaseDate = model.ReleaseDate;
                movie.Starring = model.Starring;
            }

            return RedirectToAction("Index", new { cinemaId = model.CinemaId });
        }

        public async Task<IActionResult> Delete(int? movieId)
        {
            if (movieId == null)
            {
                return NotFound();
            }

            var movie = await _movieService.GetByIdAsync(movieId.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int movieId)
        {
            var movie = await _movieService.GetByIdAsync(movieId);
            await _movieService.DeleteAsync(movieId);

            return RedirectToAction("Index", new { cinemaId = movie.CinemaId });
        }
    }
}
