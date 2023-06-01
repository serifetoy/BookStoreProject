using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;

namespace WebApi.Common
{
    public class MappingProfile : Profile//bu inheritancedan sonra burası automapper için bir class oluyor
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>(); //source-target, bookmodel objesi book objesine maplenebilir olsun
            CreateMap<Book,GetBookDetailModel>().ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BooksViewModel>().ForMember(dest=> dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        }

    }

}