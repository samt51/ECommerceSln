using CatalogService.Application.Abstract.Categoria;
 
using ECommerce.Shared.Dtos;
using ECommerce.Shared.Dtos.CatalogServiceDtos.CategoryDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers.Categoria
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;    
        }
        //[HttpGet]
        //public async Task<ResponseDto<IList<GetAllCategoryQueryResponse>>> GetAllAsync()
        //{
        //    return await this._mediator.Send(new GetAllCategoryQueryRequest());
        //}

        [HttpPost]
        public async Task<ResponseDto<CategoryResponseDto>> AddAsync(CategoryRequestDto request)
        {
            return await _categoryService.CreateAsync(request);
        }
    }
}
