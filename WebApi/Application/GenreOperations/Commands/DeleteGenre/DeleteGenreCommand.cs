using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {

        public int GenreId { get; set; }
        private readonly IBookStoreDbContext _context;
        public DeleteGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.Id == GenreId);
            if (genre is null)
            {
                throw new InvalidOperationException("Cannot find the genre to delete");
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();


        }
    }

    public class DeleteGenreViewModel
    {
        public string Name { get; set; }
    }
}