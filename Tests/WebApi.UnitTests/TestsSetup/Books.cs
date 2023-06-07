using WebApi.DBOperations;
using WebApi.Entities;
using System;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
            new Book { Title = "Lean Startup", GenreId = 1, PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
            new Book { Title = "Herland", GenreId = 2, PageCount = 350, PublishDate = new DateTime(2010, 08, 22) },
            new Book { Title = "Dune", GenreId = 2, PageCount = 540, PublishDate = new DateTime(2015, 12, 21) });
        }

    }

}