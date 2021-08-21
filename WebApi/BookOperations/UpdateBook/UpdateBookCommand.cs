using System;
using System.Linq;
using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model {get;set;}
        public int Id { get; set; }
        private readonly BookStoreDbContext _context;
        public  UpdateBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
        var book = _context.Books.SingleOrDefault(x=>x.Id == Id);
        if(book is null)
        {
            throw new InvalidOperationException("Kitap ");
        }
        book.GenreId = Model.GenreId != default ?Model.GenreId : book.GenreId;
        book.PageCount = Model.PageCount !=default ? Model.PageCount : book.PageCount;
        book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
        book.Title = Model.Title != default ? Model.Title : book.Title;
        _context.SaveChanges();
        }

        public class UpdateBookModel
        {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        }
    }
}