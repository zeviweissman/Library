using library.Service;
using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShlfService _shlfService;

        public ShelfController(IShlfService shlfService)
        {
            _shlfService = shlfService;
        }

        //public IActionResult Index(long id) => 
        //    View(_shlfService.AllShelves(long id));
       
    }
}
