using App.Services.Categories;
using App.Services.Categories.Create;
using App.Services.Categories.Update;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class CategoriesController(ICategoryService categoryService) : CustomBaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await categoryService.GetAllListAsync());

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await categoryService.GetByIdAsync(id));

        [HttpGet("products")]
        public async Task<IActionResult> GetAllWithProducts() => CreateActionResult(await categoryService.GetCategoryWithProductsAsync());

        [HttpGet("{id:int}/products")]
        public async Task<IActionResult> GetAllWithProducts(int id) => CreateActionResult(await categoryService.GetCategoryWithProductsAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request) => CreateActionResult(await categoryService.CreateAsync(request));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateCategoryRequest request) => CreateActionResult(await categoryService.UpdateAsync(id, request));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await categoryService.DeleteAsync(id));
    }
}
