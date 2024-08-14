using ECommerce.Shared.Dtos.CatalogServiceDtos.CategoryDto;
using ECommerce.Shared.Dtos.CatalogServiceDtos.FeatureDtos;

namespace ECommerce.Shared.Dtos.CatalogServiceDtos.CourseDtos
{
    public class CourseResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedTime { get; set; }
        public FeatureResponseDto FeatureResponse { get; set; }
        public string CategoryId { get; set; }
        public CategoryResponseDto CategoryResponse { get; set; }
    }
}
