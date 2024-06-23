using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServive _ProductsService;

        public ProductsController(IProductServive ProductsService)
        {
            _ProductsService = ProductsService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductsList()
        {
            var values = await _ProductsService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsByID(string id)
        {
            var values =await _ProductsService.GetByIDProductAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProducts(CreateProductDto createProductsDto)
        {
            await _ProductsService.CreateProductAsync(createProductsDto);
            return Ok("Ürün Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProducts(string id)
        {
            await _ProductsService.DeleteProductAsync(id);
            return Ok("Ürün Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProducts(UpdateProductDto updateProductsDto)
        {
            await _ProductsService.UpdateProductAsync(updateProductsDto);
            return Ok("Ürün Başarıyla Güncellendi");
        }
    }
}
