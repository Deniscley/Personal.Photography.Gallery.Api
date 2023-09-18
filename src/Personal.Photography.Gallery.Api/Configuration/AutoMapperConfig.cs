using Personal.Photography.Gallery.Data.MappingsProfile;

namespace Personal.Photography.Gallery.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ClientMappingProfile));
        }
    }
}
