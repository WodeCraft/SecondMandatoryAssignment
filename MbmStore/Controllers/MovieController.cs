﻿using MbmStore.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MbmStore.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            Random rnd = new Random();
            // create a new Movie object with instance name jungleBook
            Movie jungleBook = new Movie(rnd.Next(1000, 50000), "Jungle Book", 160.50m, "junglebook.jpg", "Jon Favreau");

            Movie bladeRunner = new Movie(rnd.Next(1000, 50000), "Blade Runner", 198.95m, "bladerunner.jpg", "Ridley Scott");

            Movie subway = new Movie(rnd.Next(1000, 50000), "Subway", 89.50m, "subway.jpg", "Luc Besson");

            // Step 1
            List<Movie> movies = new List<Movie>();
            movies.Add(jungleBook);
            movies.Add(bladeRunner);
            movies.Add(subway);

            // assign a viewbag property to the new Movie object
            ViewBag.JungleBook = jungleBook;
            ViewBag.BladeRunner = bladeRunner;
            ViewBag.Subway = subway;
            // Add the movies from the repository as well. This is currently not used in the view!
            ViewBag.Movies = movies;

            return View();
        }
    }
}