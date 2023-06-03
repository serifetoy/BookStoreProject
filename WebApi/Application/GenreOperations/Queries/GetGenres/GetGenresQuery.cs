using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly BookStoreDbContext _context;

        public readonly IMapper _mapper;

        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetGenresQueryViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive).OrderBy(x => x.Id);
            List<GetGenresQueryViewModel> vm = _mapper.Map<List<GetGenresQueryViewModel>>(genres);//genreyı modele maple
            return vm;
        }
    }
    public class GetGenresQueryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}