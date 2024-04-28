using Microsoft.AspNetCore.Mvc;
using StudentsMVC.Models;

namespace StudentsMVC.Controllers
{
    public class MovieController : Controller
    {
        MovieContext _movieContext;

        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie>movies=await Task.Run(()=>_movieContext.Movies);
            ViewBag.Movies = movies;
            return View();
        }
    }
}
