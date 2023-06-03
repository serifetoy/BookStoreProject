using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public UpdateBookViewModel Model { get; set; }

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Book is not found");

            // genreid defaulttan farklıysa değiştirilmişse, updated kullan değilse kendi değerini kullan
            //güncelleme yoksa mevcut değeri koru

            book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
            book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
            book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
            book.Title = Model.Title != default ? Model.Title : book.Title;
   
            _dbContext.SaveChanges();

        }

    }

    public class UpdateBookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }

    }
}