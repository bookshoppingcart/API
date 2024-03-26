using Microsoft.AspNetCore.Mvc;

namespace BookShopingCart_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBooksRepository _bookRepository;
        private readonly IGenreRepository _genreRepository;

        public HomeController(ILogger<HomeController> logger, IBooksRepository bookRepository, IGenreRepository genreRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _genreRepository = genreRepository;
        }

        [HttpGet("Home", Name = "Home")]
        public async Task<IActionResult> Index(string sterm = "", int genreId = 0)
        {
            IEnumerable<Book> books = await _bookRepository.GetBooks(sterm, genreId);
            IEnumerable<Genre> genres = await _genreRepository.Genres();
            BookDisplayModel bookModel = new BookDisplayModel
            {
                Books = books,
                Genres = genres,
                STerm = sterm,
                GenreId = genreId
            };
            return Ok(bookModel);
        }

        [HttpGet("Privacy", Name = "Privacy")]
        public IActionResult Privacy()
        {
            return Ok("Welcome to Privicy");
        }


        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        //    var exception = context?.Error; // The exception that caused the error

        //    var errorInfo = new
        //    {
        //        RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
        //        Message = "An error occurred while processing your request.",
        //        Detailed = exception?.Message // Optional: include detailed error message only in development environment
        //    };

        //    return Problem(detail: errorInfo.Detailed, title: errorInfo.Message, statusCode: 500);
        //}
    }
}