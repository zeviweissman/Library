using library.Models;
using library.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;

namespace library.Controllers
{

    public class SetController : Controller
    {



        private readonly ISetService _setService;

        public SetController(ISetService setService)
        {
            _setService = setService;

        }

        public async Task<IActionResult> Index() =>
            View(await _setService
                .GetAllSets()
                );


        public async Task<IActionResult> Create() =>
            View();
        [HttpPost]
        public async Task<IActionResult> Create(string setName)
        {

            return RedirectToAction("AddBooks", new { setName });

        }

        public IActionResult AddBooks(string? setName)
        {

            ViewBag.SetName = setName;
            return View();

        }
        [HttpPost]

        public async Task<IActionResult> AddBooks(SetBookVM model)
        {
            BookModel book = new()
            {
                BookName = model.BookName,
                GenreName = model.GenreName,
                Height = model.Height,
                Width = model.Width
            };
            SetModel set = new() { SetName = model.SetName };
            set.Books.Add(book);


            try
            {
                var res = await _setService.InsertSet(set);

                ModelState.AddModelError("create error", res.message);

                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("create error", ex.Message);
                return View();

            }
        }

    
        

        public IActionResult CreateSet()
        {
            return View();
        }


        public IActionResult Details(SetModel set) =>
            View(set);
    }

}
