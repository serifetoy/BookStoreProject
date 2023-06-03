using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int GenreId { get; set; }
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailQueryViewModel Handle()
        {
            var genres = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
            if (genres is null)
            {
                throw new InvalidOperationException("Genre is not exist");
            }
            GenreDetailQueryViewModel vm = _mapper.Map<GenreDetailQueryViewModel>(genres);
            return vm;
            
        }
    }
    public class GenreDetailQueryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}