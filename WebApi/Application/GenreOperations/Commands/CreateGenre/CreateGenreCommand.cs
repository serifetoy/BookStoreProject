using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreCommandViewModel Model { get; set; }
        private readonly IBookStoreDbContext _context;


        public CreateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
            
        }

        public void Handle()
        {
            var genres = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genres is not null)
            {
                throw new InvalidOperationException("Genre is already exist!");
            }

            //mapleme kullanmadım
            genres = new Genre();
            genres.Name = Model.Name;
            _context.Genres.Add(genres); //Genre entitisine genrayı ver diyorum
            _context.SaveChanges();



        }
    }

    public class CreateGenreCommandViewModel
    {
        public string Name { get; set; }
    }
}