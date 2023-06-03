using AutoMapper;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.BookOperations.Queries.GetBookDetail;
using WebApi.Application.BookOperations.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenreDetail;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile//bu inheritancedan sonra burası automapper için bir class oluyor
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>(); //source-target, bookmodel objesi book objesine maplenebilir olsun
            CreateMap<Book, GetBookDetailModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Genre, GetGenresQueryViewModel>();
            CreateMap<Genre, GenreDetailQueryViewModel>();
        }

    }

}