namespace ECommerce.Shared.Bases
{
    public class BaseHandler
    {
        public readonly ECommerce.Shared.AllShared.Interfaces.Mapper.IMapper mapper;
      
        public BaseHandler(ECommerce.Shared.AllShared.Interfaces.Mapper.IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
