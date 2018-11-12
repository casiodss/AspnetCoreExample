using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace AspNetCoreExample.Automapper
{
    public class MapperProfile: Profile 
    {
        public MapperProfile()
        {
            CreateMap<SqlData.Northwind.Products, Domain.Northwind.Product>()
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.ProductId)
                )
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.ProductName)
                )
                .ForMember(dest => dest.Category,
                            opt => opt.MapFrom(src => src.Category)
                )
                .ReverseMap();

            CreateMap<SqlData.Northwind.Categories, Domain.Northwind.Category>()
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.CategoryId)
                )
                .ForMember(dest => dest.Name,
                            opt => opt.MapFrom(src => src.CategoryName)
                )
                .ReverseMap();
        }
    }
}
