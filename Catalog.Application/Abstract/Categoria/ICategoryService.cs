using ECommerce.Shared.Dtos;
using ECommerce.Shared.Dtos.CatalogServiceDtos.CategoryDto;

namespace CatalogService.Application.Abstract.Categoria
{
    public interface ICategoryService
    {
        Task<ResponseDto<IList<CategoryResponseDto>>> GetListAsync();

        Task<ResponseDto<CategoryResponseDto>> GetByIdAsync(string id);

        Task<ResponseDto<CategoryResponseDto>> CreateAsync(CategoryRequestDto request);
    }
}
