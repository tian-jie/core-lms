using AutoMapper;
using CoreLMS.Core.DataTransferObjects;
using CoreLMS.Core.Entities;

namespace CoreLMS.Core
{
    public class AutoMapperInstance
    {
        private static IMapper _mapper;
        private readonly AutoMapperInstance _autoMapperInstance = new AutoMapperInstance();

        private AutoMapperInstance()
        {
        }

        public static IMapper GetMapper()
        {
            if (_mapper == null)
            {
                AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<EntityMappingProfile>();
                });
                _mapper = config.CreateMapper();
            }
            return _mapper;
        }
    }
}
