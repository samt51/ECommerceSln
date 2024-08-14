using ECommerce.Shared.Dtos.CatalogServiceDtos.FeatureDtos;

namespace ECommerce.Shared.Dtos.CatalogServiceDtos.CourseDtos
{
    public class CourseRequestDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedTime { get; set; }
        public FeatureRequestDto FeatureRequest { get; set; }
        public string CategoryId { get; set; }
    }
}
