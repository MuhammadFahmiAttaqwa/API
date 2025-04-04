using Application.DTO;
using Application.DTO.Response.Product;
using Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<ProductResponseAll>>> GetAll()
        {
            List<ProductResponseAll> products = await _productService.GetAll();


            ApiResponse<List<ProductResponseAll>> response = new ApiResponse<List<ProductResponseAll>>()
            {
                Message = "Success",
                Code = 200,
                ResultData = products
            };
            return response;
        }
    }
}
