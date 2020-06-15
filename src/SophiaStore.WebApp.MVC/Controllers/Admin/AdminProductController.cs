using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SophiaStore.Catalog.Application.Dtos;
using SophiaStore.Catalog.Application.Services;

namespace SophiaStore.WebApp.MVC.Controllers.Admin
{
    public class AdminProductController : Controller
    {
        private IProductAppService _productAppService;

        public AdminProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpGet]
        [Route("admin-product")]
        public async Task<IActionResult> Index()
        {
            return View(await _productAppService.GetAll());
        }



        [Route("new-product")]
        public async Task<IActionResult> NewProduct()
        {
            return View(await GetAllCategories(new ProductDto()));
        }

        [HttpPost]
        [Route("new-product")]
        public async Task<IActionResult> NewProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid) return View(await GetAllCategories(productDto));

            await _productAppService.Update(productDto);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("update-product-stock")]
        public async Task<IActionResult> UpdateStock(Guid id, int quantity)
        {
            if (quantity > 0)
                await _productAppService.Replace(id, quantity);
            else
                await _productAppService.Debit(id, quantity);

            return RedirectToAction("Index", await _productAppService.GetAll());
        }

        private async Task<ProductDto> GetAllCategories(ProductDto productDto)
        {
            productDto.Categories = await _productAppService.GetAllCategories();
            return productDto;
        }


    }
}
