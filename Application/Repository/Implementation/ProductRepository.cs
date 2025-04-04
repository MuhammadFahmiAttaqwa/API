using Application.Repository.Interfaces;
using Data.Entity;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepository<Product, int> _repository;
        public ProductRepository(IRepository<Product, int> repository) 
        {
            _repository = repository;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _repository.FindAll(c => c.ProductCategory).ToListAsync();
        }
    }
}
