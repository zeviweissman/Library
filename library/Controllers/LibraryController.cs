using Microsoft.AspNetCore.Mvc;
using library.Service;

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
		
	}
}
