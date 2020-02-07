using AutoMapper;
using TestProj.BLL.Models;
using TestProj.DAL.Entities;

namespace TestProj.BLL.Services
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
