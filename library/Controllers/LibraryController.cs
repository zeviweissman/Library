using Microsoft.AspNetCore.Mvc;
using library.Service;
using library.Models;
using library.View_Model;

namespace library.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        public async Task<IActionResult> Index() =>
            View(await _libraryService
                .GetAllLibraries()
                );

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string genre)
        {
            try
            {
                await _libraryService.InsertLibrary(genre);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("createError", ex.Message);
                return View();

            }
        }
        public async Task<IActionResult> InsertShelf()
        {
            return View();
        }

        
    }
}
