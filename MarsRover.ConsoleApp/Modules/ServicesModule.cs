using MarsRover.Business.Services.InputSection;
using MarsRover.Business.Services.InputSection.Imp;
using MarsRover.Business.Services.Providers;
using MarsRover.Business.Services.Providers.Imp;
using MarsRover.Business.Services.SurfaceSection;
using MarsRover.Business.Services.SurfaceSection.Imp;
using MarsRover.Business.Services.VehicleSection;
using MarsRover.Business.Services.VehicleSection.Imp;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Modules
{
    public static class ServicesModule
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IVehicleFactory, VehicleFactory>();
            services.AddSingleton<IVehicleBuilder, RoverBuilder>();
            services.AddSingleton<IVehicleContextFactory, VehicleContextFactory>();
            
            services.AddSingleton<ISurfaceBuilderFactory, SurfaceBuilderFactory>();
            services.AddSingleton<ISurfaceBuilder, PlateauBuilder>();
            services.AddSingleton<IVehicleActionProvider, VehicleActionProvider>();
            
            services.AddTransient<IInputProviderFactory, InputProviderFactory>();
            services.AddTransient<IInputProvider, ConsoleInputProvider>();
        }
    }
}