using CatalogService.Application.Abstract.Categoria;
using CatalogService.Application.Settings;
using CatalogService.Domain.Entities;
using ECommerce.Shared.AllShared.Interfaces.Mapper;
using ECommerce.Shared.Dtos;
using ECommerce.Shared.Dtos.CatalogServiceDtos.CategoryDto;
using MongoDB.Driver;

namespace CatalogService.Persistence.Concrete.Services.Categoria
{
    public class CategoriaService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoriaService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }
        public async Task<ResponseDto<IList<CategoryResponseDto>>> GetListAsync()
        {
            var data = _categoryCollection.Find(x => true).ToList();

            var mapData = _mapper.Map<CategoryResponseDto, Category>(data.ToList());

            return ResponseDto<IList<CategoryResponseDto>>.Success(mapData);
        }

        public async Task<ResponseDto<CategoryResponseDto>> GetByIdAsync(string id)
        {
            var data = await _categoryCollection.Find(y => y.Id == id).FirstOrDefaultAsync();

            var mapData = _mapper.Map<CategoryResponseDto, Category>(data);

            return ResponseDto<CategoryResponseDto>.Success(mapData);
        }

        public async Task<ResponseDto<CategoryResponseDto>> CreateAsync(CategoryRequestDto request)
        {
            var map = _mapper.Map<Category, CategoryRequestDto>(request);

            await _categoryCollection.InsertOneAsync(map);

            return ResponseDto<CategoryResponseDto>.Success();
        }
    }
}
