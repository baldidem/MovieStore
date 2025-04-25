using AutoMapper;
using MovieStore.Domain;
using MovieStore.DTOs.Actor;
using MovieStore.DTOs.Customer;
using MovieStore.DTOs.Director;
using MovieStore.DTOs.Movie;
using MovieStore.DTOs.Purchase;

namespace MovieStore.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Movie, MovieResponseDto>()
          .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName))
          .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor.FirstName + " " + ma.Actor.LastName).ToList()))
          .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<MovieDto, Movie>();

            CreateMap<Actor, ActorResponseDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<ActorDto, Actor>();

            CreateMap<Director, DirectorResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<DirectorDto, Director>();

            CreateMap<Customer, CustomerResponseDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));
            CreateMap<CustomerDto, Customer>();

            CreateMap<Purchase, PurchaseResponseDto>()
                .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Name));
        }
      
    }
}
