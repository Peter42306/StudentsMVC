using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StudentsMVC.Models;

namespace StudentsMVC.Controllers
{
    public class MovieController : Controller
    {        
        ///////////////////////////////////////////////////////////////////////////////////////////
                
        // Объявление контекста базы данных фильмов
        MovieContext _movieContext;

		// IWebHostEnvironment предоставляет информацию об окружении, в котором запущено приложение
		IWebHostEnvironment _webHostEnvironment;
                
        // Внедряем ссылки через конструктор
        public MovieController(MovieContext movieContext, IWebHostEnvironment webHostEnvironment)
        {
            _movieContext = movieContext;
            _webHostEnvironment = webHostEnvironment;
        }

		///////////////////////////////////////////////////////////////////////////////////////////

		// GET запрос
		public async Task<IActionResult> Index()
        {
            return View( await _movieContext.Movies.ToListAsync());
        }

		///////////////////////////////////////////////////////////////////////////////////////////

		// GET
		public async Task<IActionResult>Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var movie=await _movieContext.Movies.FirstOrDefaultAsync(item=>item.Id == id);

            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        // Get запрос на Create

        /*
        public IActionResult Create()
		{
            return View(_movieContext.Movies.ToList());
		}
        */

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,Director,Genre,ReleaseYear,Description")] Movie movie, IFormFile posterFile)
        {
            if (ModelState.IsValid)
            {
                if (posterFile != null && posterFile.Length > 0)
                {
                    string fileName = Path.GetFileName(posterFile.FileName);
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Image", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await posterFile.CopyToAsync(fileStream);
                    }
                    movie.PosterPath = "/Image/" + fileName;
                }
                _movieContext.Add(movie);
                await _movieContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        

        //[HttpPost]
        //public async Task<IActionResult> AddFile(IFormFile uploadedFile, Movie movie)
        //{
        //    if (uploadedFile != null && movie != null)
        //    {
        //        string fileName = Path.GetFileName(uploadedFile.FileName);
        //        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Image", fileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await uploadedFile.CopyToAsync(fileStream);
        //        }
        //        movie.PosterPath = "/Image/" + fileName;

        //        _movieContext.Movies.Add(movie);
        //        await _movieContext.SaveChangesAsync();

        //        //string posterPath = "/Image/" + uploadedFile.FileName;

        //        //using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + posterPath, FileMode.Create))
        //        //{
        //        //    await uploadedFile.CopyToAsync(fileStream);
        //        //}

        //        //Movie posterFile = new Movie { Title = movie, PosterPath = posterPath };
        //        //_movieContext.Movies.Add(posterFile);
        //        //_movieContext.SaveChanges();
        //    }
        //    return RedirectToAction("Index");
        //}



        //// Post запрос на Create
        //[HttpPost] // получение данных от клиента, при нажатии СОХРАНИТЬ данные сохраняются в БД
        //[ValidateAntiForgeryToken] // проверка данных перед тем как они отправятся в базу данных

        //// Bind - инициализация полей объекта, происходит напрямую через форму html
        //public async Task<IActionResult> Create([Bind("Id,Title,Director,Genre,ReleaseYear,PosterPath,Description")] Movie movie, IFormFile posterFile)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (posterFile != null && posterFile.Length > 0)
        //        {
        //            string fileName = Path.GetFileName(posterFile.FileName);
        //            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Image", fileName);

        //            using (var fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await posterFile.CopyToAsync(fileStream);
        //            }
        //        }

        //        _movieContext.Add(movie);
        //        await _movieContext.SaveChangesAsync(); // синхронизация с БД
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movie);
        //}

        // !!! c этим методом сохраняется и отображается новый фильм, но нет постера !!!
        // Bind - инициализация полей объекта, происходит напрямую через форму html
        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("Id,Title,Director,Genre,ReleaseYear,PosterPath,Description")] Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _movieContext.Add(movie);
        //        await _movieContext.SaveChangesAsync(); // синхронизация с БД
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movie);
        //}


        ///////////////////////////////////////////////////////////////////////////////////////////

        // Get запрос на Edit
        public async Task<IActionResult>Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var movie=await _movieContext.Movies.FindAsync(id);

            if(movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, [Bind("Id,Title,Director,Genre,ReleaseYear,PosterPath,Description")] Movie movie)
        {
            if(id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _movieContext.Update(movie);
                    await _movieContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }					
				}
				return RedirectToAction(nameof(Index));
			}
            return View(movie);
        }

		///////////////////////////////////////////////////////////////////////////////////////////
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie=await _movieContext.Movies.FirstOrDefaultAsync(item => item.Id == id);

            if(movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // почему пропало подчёркивание когда я написал return RedirectToAction(nameof(Index));
		{
            var movie = await _movieContext.Movies.FindAsync(id);

            if (movie!=null)
            {
                _movieContext.Movies.Remove(movie);
            }

            await _movieContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


		///////////////////////////////////////////////////////////////////////////////////////////

		private bool MovieExists(int id)
        {
            return _movieContext.Movies.Any(item => item.Id == id);
        }

        //// Действие (action) для отображения списка фильмов
        //public async Task<IActionResult> Index()
        //{
        //    // Получение списка фильмов из базы данных
        //    IEnumerable<Movie>movies=await Task.Run(()=>_movieContext.Movies);

        //    // Передача списка фильмов в представление через ViewBag
        //    ViewBag.Movies = movies;

        //    // Возвращение представления Index
        //    return View();
        //}
    }
}
