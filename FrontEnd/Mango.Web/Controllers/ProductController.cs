using System.Collections.Generic;
using System.Threading.Tasks;
using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            List<ProductDto> products = new List<ProductDto>();
            var response = await _productService.GetAllProductsAsync<ResponseDto>();

            if (response?.Result != null && response.IsSuccess)
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(response.Result.ToString()!)!;
            }

            return View(products);
        }

        [HttpGet("Item")]
        public async Task<IActionResult> Item(int? productId)
        {
            if (productId != null)
            {
                var response = await _productService.GetProductByIdAsync<ResponseDto>(productId.Value);
                if (response?.Result != null && response.IsSuccess)
                {
                    ProductDto model = JsonConvert.DeserializeObject<ProductDto>(response.Result.ToString()!)!;
                    return View(model);
                }

                return NotFound();
            }

            return View();
        }

        [HttpPost("Item")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Item(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var response = model.ProductId > 0
                    ? await _productService.UpdateProductAsync<ResponseDto>(model)
                    : await _productService.CreateProductAsync<ResponseDto>(model);

                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }

        [HttpGet("Delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int productId)
        {
            var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);
            if (response?.Result != null && response.IsSuccess)
            {
                ProductDto model = JsonConvert.DeserializeObject<ProductDto>(response.Result.ToString()!)!;
                return View(model);
            }

            return NotFound();
        }

        [HttpPost("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(model);
        }
    }
}