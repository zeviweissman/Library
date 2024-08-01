using library.Models;
using library.Service;
using Microsoft.AspNetCore.Mvc;
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

            return RedirectToAction("AddBooks", new {setName});
            
        }

        public IActionResult AddBooks(string? setName)
        {
            
            ViewBag.SetName = setName;
            return View();

        }
        [HttpPost]

        public async Task<IActionResult> AddBooks(SetBookVM model)
        {
            SetModel set = new () { SetName = model.SetName};
            BookModel book = new () 
            { BookName = model.BookName,
            GenreName = model.GenreName,
            Height = model.Height,
            Width = model.Width};
            set.Books.Add(book);
            try
            {
               var res = await _setService.InsertSet(set);
                if (res.message != null)
                {
                    ModelState.AddModelError("create error", res.message);
                }
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("create error", ex.Message);
                return View();

            }

            
            
        
        }

        public IActionResult Details(SetModel set) =>
            View(set);
    }

}
