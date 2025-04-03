using Application.DTO.Response;
using Application.DTO.Response.Product;
using AutoMapper;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Function, SidebarResponse>();
            CreateMap<Product, ProductResponseAll>();
        }
    }
}
