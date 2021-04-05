using System;
using MarsRover.Contract.Interfaces;
using MarsRover.Contract.Models;

namespace MarsRover.Business.Services.VehicleSection.Imp
{
    public class VehicleContextFactory : IVehicleContextFactory
    {
        public IVehicleContext Generate(Surface surface, Vehicle vehicle)
        {
            surface = surface ?? throw new Exception($"{nameof(surface)} should not be null");
            vehicle = vehicle ?? throw new Exception($"{nameof(vehicle)} should not be null");

            IVehicleContext vehicleContext;
            if (vehicle is Rover)
                vehicleContext = new RoverContext(vehicle, surface);
            else
            {
                throw new Exception($"Vehicle is not defined [{vehicle.GetType().Name}]");
            }

            return vehicleContext;
        }
    }
}