namespace RedBerylBookStore.Controllers
{
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Common.Enums;
    using Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using ServiceModels;
    using Service.Contract;
    using Shared.Domain;

    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;
        private readonly ILogger<BooksController> logger;

        public BooksController(IBookService bookService, IMapper mapper, ILogger<BooksController> logger)
        {
            this.bookService = bookService;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("api/Books/GetBooks")]
        public IActionResult GetBooks([FromQuery] string search)
        {
            this.logger.LogInformation($"The Books {nameof(this.GetBooks)} action has been accessed");
            var books = this.bookService.Get(search);
            var booksObj = books.ProjectTo<BookModel>(this.mapper.ConfigurationProvider);
            return Ok(ApiResponse.OK(new { booksObj }));
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRole.Author))]
        [Route("api/Books/GetBooksByAuthor")]
        public IActionResult GetBooksByAuthor([FromQuery]int userId)
        {
            if (userId <= 0)
            {
                this.logger.LogWarning($"The Account {nameof(this.GetBooks)} action has been accessed with Invalid User Id : {userId}");
                return BadRequest(ApiResponse.BadRequest("Invalid User Id"));
            }

            this.logger.LogInformation($"The Books {nameof(this.GetBooks)} action has been accessed");
            var result = this.bookService.Get().Where(x => x.UserId == userId);
            var booksObj = result.ProjectTo<BookModel>(this.mapper.ConfigurationProvider);
            return Ok(ApiResponse.OK(new { booksObj }));
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRole.Author))]
        [Route("api/Books/CreateBook")]
        public IActionResult CreateBook([FromBody]BookModel model)
        {
            if (model == null)
            {
                this.logger.LogWarning($"The Books {nameof(this.CreateBook)} action has been accessed with Invalid Book Model");
                return BadRequest("Invalid Book Model");
            }

            if (ModelState.IsValid)
            {
                var bookObj = this.mapper.Map<Book>(model);
                var result = this.bookService.Create(bookObj);
                var resultObj = this.mapper.Map<BookModel>(result);
                return Ok(ApiResponse.OK(new { bookObj }));
            }

            this.logger.LogWarning($"The Account {nameof(this.CreateBook)} action has been accessed with Invalid Book Model");
            return BadRequest(ApiResponse.BadRequest("Invalid Book Model"));
        }
    }
}