using AutoMapper;
using TestProj.BLL.Models;
using TestProj.DAL.Entities;

namespace TestProj.BLL.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Operation, OperationDTO>()
                .ForMember(dest=>dest.AppUserName, opt=> opt.MapFrom(src=>src.AppUser.UserName));
            CreateMap<OperationDTO,Operation>();
        }
    }
}
