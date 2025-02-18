using AutoMapper;
using HDLand.Logic.Entities;
using HDLand.Logic.Models;
using Newtonsoft.Json;

namespace HDLand.Persistance.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
           
            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.FavoriteMovies, opt => opt.MapFrom(src =>
                    src.FavoriteMovies));  

            
            CreateMap<User, UserEntity>()
                .ForMember(dest => dest.FavoriteMovies, opt => opt.MapFrom(src =>
                    src.FavoriteMovies));  
        }
    }
}
