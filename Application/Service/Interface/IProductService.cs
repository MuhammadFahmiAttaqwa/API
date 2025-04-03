using Application.DTO.Response.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interface
{
    public interface IProductService
    {
        Task<List<ProductResponseAll>> GetAll();
    }
}
