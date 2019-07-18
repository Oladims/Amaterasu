using Amaterasu.Dtos;
using Amaterasu.Models;
using AutoMapper;

namespace Amaterasu.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<CustomerDto, Customer>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}