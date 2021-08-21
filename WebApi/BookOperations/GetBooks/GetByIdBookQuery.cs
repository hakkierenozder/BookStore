using System.Linq;
using AutoMapper;
using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetByIdBookQuery
    {
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetByIdBookQuery(BookStoreDbContext context,IMapper mapper)
        {
            _context =context;
            _mapper = mapper;

        }

        public BooksByIdViewModel Handle()
        {
            var book = _context.Books.Where(x=>x.Id == Id).SingleOrDefault();
            BooksByIdViewModel vm = _mapper.Map<BooksByIdViewModel>(book);
            
            return vm;
        }

        public class BooksByIdViewModel
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public int PageCount { get; set; }
            public string PublishDate { get; set; }
        }
    }
}