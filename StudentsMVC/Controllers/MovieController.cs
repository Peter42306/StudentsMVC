using Microsoft.AspNetCore.Mvc;
using StudentsMVC.Models;

namespace StudentsMVC.Controllers
{
    public class MovieController : Controller
    {
        // Объявление контекста базы данных фильмов
        MovieContext _movieContext;

        // Конструктор контроллера с инъекцией контекста базы данных фильмов
        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }

        // Действие (action) для отображения списка фильмов
        public async Task<IActionResult> Index()
        {
            // Получение списка фильмов из базы данных
            IEnumerable<Movie>movies=await Task.Run(()=>_movieContext.Movies);

            // Передача списка фильмов в представление через ViewBag
            ViewBag.Movies = movies;

            // Возвращение представления Index
            return View();
        }
    }
}
