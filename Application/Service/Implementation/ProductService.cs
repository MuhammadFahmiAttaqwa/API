using Application.DTO.Response.Product;
using Application.Repository.Interfaces;
using Application.Service.Interface;
using AutoMapper;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repostitoy, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repostitoy;
        }

        public async Task<List<ProductResponseAll>> GetAll()
        {
            List<Product> products =await _repository.GetAll();
            return _mapper.Map<List<ProductResponseAll>>(products);
        }
    }
}
