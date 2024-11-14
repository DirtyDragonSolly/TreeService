using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using TreeService.Data;
using TreeService.MappingProfiles;
using TreeService.Repositories.Implementations;
using TreeService.Repositories.Interfaces;
using TreeService.Services.Implementations;
using TreeService.Services.Interfaces;

namespace TreeService.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder ConfigureDIContainer(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Logging.ClearProviders();
            applicationBuilder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

            applicationBuilder.Services.AddControllers();

            applicationBuilder.AddSwaggerConfiguration();
            applicationBuilder.AddDbContext();
            applicationBuilder.AddLogic();
            applicationBuilder.AddRepositories();
            applicationBuilder.AddMapping();
            
            return applicationBuilder;
        }

        private static WebApplicationBuilder AddLogic(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddScoped<IFolderManager, FolderManager>();

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddRepositories(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddScoped<IFolderRepository, FolderRepository>();

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddDbContext(this WebApplicationBuilder applicationBuilder)
        {
            var connectionString = applicationBuilder.Configuration.GetConnectionString("DefaultConnection");

            applicationBuilder.Services.AddDbContext<FoldersContext>((options) => options.UseNpgsql(connectionString));

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddSwaggerConfiguration(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Folder.Service.Api"
                });
            });

            return applicationBuilder;
        }

        private static WebApplicationBuilder AddMapping(this WebApplicationBuilder applicationBuilder)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;

                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            applicationBuilder.Services.AddSingleton(mapper);

            return applicationBuilder;
        }
    }
}
