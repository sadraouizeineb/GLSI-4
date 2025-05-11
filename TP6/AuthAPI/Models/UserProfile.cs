using AuthAPI.DTOS;
using AutoMapper;

namespace AuthAPI.Models
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Category, CategorieDTO>();
            CreateMap<CategorieDTO, Category>();
        }
    }
}
