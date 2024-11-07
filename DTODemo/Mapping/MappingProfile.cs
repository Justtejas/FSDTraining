using AutoMapper;
using DTODemo.Models;
using static DTODemo.Models.Book;

namespace DTODemo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }

    }
}
