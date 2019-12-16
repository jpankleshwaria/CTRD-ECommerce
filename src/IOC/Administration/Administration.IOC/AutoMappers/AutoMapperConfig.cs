using AutoMapper;

namespace Administration.IOC.AutoMappers
{
    public static class AutoMapperConfig
    {

        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToDomainMappingProfile());
                cfg.AddProfile(new EntityToDtoMappingProfile());
            });
        }
    }
}
