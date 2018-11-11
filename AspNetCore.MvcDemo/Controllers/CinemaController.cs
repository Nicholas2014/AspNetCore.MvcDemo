using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.MvcDemo.Models;
using AspNetCore.MvcDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.MvcDemo.Controllers
{
    public class CinemaController:Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
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

        public IActionResult Edit(int cinemaId)
        {
            return RedirectToAction("Index");
        }
    }
}
