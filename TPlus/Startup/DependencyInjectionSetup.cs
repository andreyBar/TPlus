using TPlus.Core.Services;
using TPlus.Domain.Services;
using TPlusDrive;
using TPlusDrive.InputRequest;

namespace TPlus.Startup
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection RegisterTPlusServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<InputHandler<FilesInputRequest, bool>, FilesInputHandler>();
            services.AddTransient<IFilesService, FilesService>();
            return services;
        }
    }
}
