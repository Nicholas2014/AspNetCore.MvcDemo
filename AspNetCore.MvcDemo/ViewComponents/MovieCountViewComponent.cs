﻿using System.Linq;
using System.Threading.Tasks;
using AspNetCore.MvcDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.MvcDemo.ViewComponents
{
    public class MovieCountViewComponent : ViewComponent
    {
        private readonly IMovieService _movieService;

        public MovieCountViewComponent(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int cinemaId)
        {
            var movies = await _movieService.GetByCinemaAsync(cinemaId);
            var count = movies.Count();
            //var movies2 = await _movieService.GetByCinemaAsync(cinemaId);
            //count += movies2.Count();

            return View(count);
        }
    }
}
