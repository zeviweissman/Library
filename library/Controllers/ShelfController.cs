using library.Service;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfService _shlfService;

        public ShelfController(IShelfService shlfService)
        {
            _shlfService = shlfService;
        }

        //public IActionResult Index(long id) => 
        //    View(_shlfService.AllShelves(long id));
       
    }
}
