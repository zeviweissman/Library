using library.Service;
using Microsoft.AspNetCore.Mvc;

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

        
    }
}
