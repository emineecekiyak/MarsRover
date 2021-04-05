using System;
using MarsRover.Business.Services.InputSection;
using MarsRover.Business.Services.Providers;
using MarsRover.Business.Services.SurfaceSection;
using MarsRover.Business.Services.VehicleSection;
using MarsRover.Common;
using MarsRover.Contract.Enums;
using MarsRover.Contract.Models;
using MarsRover.Modules;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover
{
    internal static class Program
    {
        private static void Main()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddApplicationServices();

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var surfaceBuilderFactory = serviceProvider.GetRequiredService<ISurfaceBuilderFactory>();
            var vehicleFactory = serviceProvider.GetRequiredService<IVehicleFactory>();
            var vehicleContextFactory = serviceProvider.GetRequiredService<IVehicleContextFactory>();
            var vehicleActionProvider = serviceProvider.GetRequiredService<IVehicleActionProvider>();
            var inputProviderFactory = serviceProvider.GetRequiredService<IInputProviderFactory>();

            var inputProvider = inputProviderFactory.Generate(InputProviderTypes.Console);
            var inputArguments = GetInputArgument(inputProvider);

            var input = inputProvider.Provide(inputArguments);

            var surfaceBuilder = surfaceBuilderFactory.Generate(typeof(Plateau));
            var surface = surfaceBuilder.Build(input.SurfaceParameter);

            foreach (var (vehicleParameter, commandParameter) in input.VehicleAndCommandParameterCollection)
            {
                var vehicle = vehicleFactory.Generate(VehicleTypes.Rover, vehicleParameter);
                var vehicleContext = vehicleContextFactory.Generate(surface, vehicle);
                    
                var vehicleActions = vehicleActionProvider.Provide(commandParameter);
                foreach (var action in vehicleActions)
                {
                    vehicleContext.Move(action);
                }

                Console.WriteLine(vehicleContext.Vehicle.ToString());
            }

            Console.WriteLine(StringResources.PressAnyKeyForExit);
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static string GetInputArgument(IInputProvider inputProvider)
        {
            var argument = string.Empty;
            if (inputProvider is IConsoleInputProvider)
            {
                Console.WriteLine(StringResources.ParametersWillBeTakenUntilEmptyLine);
                while (true)
                {
                    var line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        break;
                    argument = $"{argument} | {line}";
                }
            }
            else
            {
                throw new Exception($"{nameof(GetInputArgument)} executed for not supported provider");
            }

            return argument;
        }
    }
}