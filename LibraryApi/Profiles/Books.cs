using AutoMapper;
using LibraryApi.Domain;
using LibraryApi.Models.Books;


namespace LibraryApi.Profiles
{
    public class Books : Profile
    {
        public Books()
        {
            // Book -> GetBooksResponseItem
            CreateMap<Book, GetBooksResponseItem>();
            CreateMap<Book, GetBookDetailsResponse>();
        }
    }
}
