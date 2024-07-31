using Microsoft.AspNetCore.Mvc;

namespace library.Controllers
{
	public class LibraryController : Controller
	{
		private readonly ILibraryService _libraryService;

		public LibraryController(ILibraryService libraryService)
		{
			_libraryService = libraryService;
		}
		public async Task<IActionResult> Index =>
			await _libraryService.GetAllLibraris.view();
		
	}
}
