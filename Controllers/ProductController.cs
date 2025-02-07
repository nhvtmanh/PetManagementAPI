using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetManagementAPI.DTOs.ProductDTOs;
using PetManagementAPI.Services.Abstraction;
using System.Security.Claims;
using PetManagementAPI.DTOs.FavoriteDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            return Ok(product);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetByName([FromQuery] string name)
        {
            var products = await _productService.GetByName(name);
            return Ok(products);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByCategory([FromQuery] string name)
        {
            var products = await _productService.GetByCategory(name);
            return Ok(products);
        }

        [HttpGet("get-favorite")]
        public async Task<IActionResult> GetFavorite([FromQuery] string customerId)
        {
            var favoriteProducts = await _productService.GetFavorite(customerId);
            return Ok(favoriteProducts);
        }

        [HttpPost("add-favorite")]
        public async Task<IActionResult> AddFavorite([FromBody] AddFavoriteDTO addFavoriteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var favoriteProduct = await _productService.AddFavorite(addFavoriteDTO);
                return Ok(favoriteProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("delete-favorite")]
        public async Task<IActionResult> DeleteFavorite([FromBody] DeleteFavoriteDTO deleteFavoriteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var favoriteProduct = await _productService.DeleteFavorite(deleteFavoriteDTO);
                return Ok(favoriteProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productDTO.Image == null || productDTO.Image.Length == 0)
            {
                return BadRequest(new { message = "No file uploaded" });
            }

            var product = await _productService.Create(productDTO);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromForm] UpdateProductDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.Update(id, productDTO);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productService.Delete(id);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            return Ok(product);
        }
    }
}
