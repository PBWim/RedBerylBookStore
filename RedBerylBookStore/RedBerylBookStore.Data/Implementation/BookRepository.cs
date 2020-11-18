namespace RedBerylBookStore.Data.Implementation
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Contract;
    using Microsoft.Extensions.Logging;
    using ServiceModels;
    using DO = DataModels;

    public class BookRepository : IBookRepository
    {
        private readonly ILogger<BookRepository> logger;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext context;

        public BookRepository(IMapper mapper, ApplicationDbContext context, ILogger<BookRepository> logger)
        {
            this.mapper = mapper;
            this.context = context;
            this.logger = logger;
        }

        public IQueryable<Book> Get()
        {
            this.logger.LogInformation($"Get books on {nameof(Get)} in BookRepository");
            var books = this.context.Books;
            var booksList = books.ProjectTo<Book>(this.mapper.ConfigurationProvider);
            return booksList;
        }

        public Book Create(Book book)
        {
            this.logger.LogInformation($"Create book on {nameof(Create)} in BookRepository with book details : {book}");
            var bookObj = this.mapper.Map<DO.Book>(book);
            bookObj.LastModifiedBy = book.UserId;
            bookObj.LastModifiedOn = DateTime.UtcNow;
            var result = this.context.Books.Add(bookObj);
            var status = this.context.SaveChanges();
            if(status > 0)
            {
                this.logger.LogInformation($"Created book with details : {book}");
                var returnBook = this.mapper.Map<Book>(result.Entity);
                return returnBook;
            }
            this.logger.LogInformation($"Book did not get created : {book}");
            return default;
        }
    }
}